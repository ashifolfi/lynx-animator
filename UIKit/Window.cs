using System.Numerics;
using Silk.NET.Maths;
using SkiaSharp;
using UIKit.Controls;
using Silk.NET.SDL;
using Silk.NET.OpenGL;
using UIKit.Styles;

namespace UIKit;

public class Window : IDisposable
{
    public string Title;
    public bool Visible = true;
    public bool Done;
    public Vector2D<int> Position
    {
        get
        {
            int w, h;
            unsafe
            {
                m_Sdl.GetWindowPosition(m_NativeWindow, &w, &h);
            }

            return new Vector2D<int>(w, h);
        }

        set
        {
            unsafe
            {
                m_Sdl.SetWindowPosition(m_NativeWindow, value.X, value.Y);
            }
        }
    }
    public Vector2D<int> Size
    {
        get => m_Size;

        set
        {
            unsafe
            {
                m_Size = value;
                Sdl.GetApi().SetWindowSize(m_NativeWindow, value.X, value.Y);
            }
        }
    }
    public Layout CentralLayout;
    private Vector2D<int> m_Size;

    // backend variables
    private readonly unsafe Silk.NET.SDL.Window* m_NativeWindow;
    private readonly SdlContext m_Context;
    private SKSurface m_Surface;
    private readonly GRContext m_GrContext;
    private readonly Sdl m_Sdl;

    public Window(string title, Vector2D<int> size, Vector2D<int> pos)
    {
        CentralLayout = new AbsoluteLayout(null);
        
        m_Sdl = Sdl.GetApi();
        Title = title;
        unsafe
        {
            m_NativeWindow = m_Sdl.CreateWindow(
                title,
                pos.X, pos.Y,
                size.X, size.Y,
                (uint)WindowFlags.Opengl | (uint)WindowFlags.Resizable
            );
            m_Size = size;
            
            m_Context = new SdlContext(m_Sdl, m_NativeWindow);
            m_Context.Create();
            m_Context.MakeCurrent();

            var glInterface = GRGlInterface.CreateOpenGl(name =>
            {
                var addr = m_Sdl.GLGetProcAddress(name);
                return (IntPtr)addr;
            });

            m_GrContext = GRContext.CreateGl(glInterface);
            var renderTarget = new GRBackendRenderTarget(
                size.X,
                size.Y,
                0,
                8,
                new GRGlFramebufferInfo(0u, 0x8058)
            );

            m_Surface = SKSurface.Create(m_GrContext, renderTarget, GRSurfaceOrigin.BottomLeft, SKColorType.Rgba8888);
        }
        
        UIKitApplication.AddWindow(this);
    }

    public void Update()
    {
        unsafe
        {
            m_Context.MakeCurrent();
            Event sdlEvent;
            while (m_Sdl.PollEvent(&sdlEvent) != 0)
            {
                switch (sdlEvent)
                {
                    case { Type: (uint)EventType.Quit }:
                    case { Type: (uint)EventType.Windowevent, Window.Event: (byte)WindowEventID.Close }:
                        Done = true;
                        break;
                    case { Type: (uint)EventType.Windowevent, Window.Event: (byte)WindowEventID.Resized }:
                        int w, h;
                        m_Sdl.GetWindowSize(m_NativeWindow, &w, &h);
                        m_Size = new Vector2D<int>(w, h);
                        
                        RecreateSurface();
                        break;
                    case {Type: (uint)EventType.Textinput}:
                        CentralLayout.TextInputEvent(System.Text.Encoding.UTF8.GetString([sdlEvent.Text.Text[0]]));
                        break;
                    case { Type: (uint)EventType.Keydown }:
                    case { Type: (uint)EventType.Keyup }:
                        CentralLayout.KeyboardEvent(new KbEventData
                        {
                            Key = (KeyCode)sdlEvent.Key.Keysym.Sym,
                            Repeat = sdlEvent.Key.Repeat > 0,
                            Pressed = sdlEvent.Key.State == Sdl.Pressed
                        });
                        break;
                    case { Type: (uint)EventType.Mousebuttonup }:
                    case { Type: (uint)EventType.Mousebuttondown }:
                        if (sdlEvent.Button.X > CentralLayout.GlobalPosition.X && sdlEvent.Button.X < CentralLayout.GlobalPosition.X + CentralLayout.Size.X
                            && sdlEvent.Button.Y > CentralLayout.GlobalPosition.Y && sdlEvent.Button.Y < CentralLayout.GlobalPosition.Y + CentralLayout.Size.Y)
                        {
                            CentralLayout.MouseButtonEvent(new MbEventData
                            {
                                Button = sdlEvent.Button.Button,
                                X = sdlEvent.Button.X,
                                Y = sdlEvent.Button.Y,
                                Pressed = sdlEvent.Button.State == Sdl.Pressed
                            });
                        }
                        break;
                    case { Type: (uint)EventType.Mousemotion }:
                        if (sdlEvent.Motion.X > CentralLayout.GlobalPosition.X && sdlEvent.Motion.X < CentralLayout.GlobalPosition.X + CentralLayout.Size.X
                            && sdlEvent.Motion.Y > CentralLayout.GlobalPosition.Y && sdlEvent.Motion.Y < CentralLayout.GlobalPosition.Y + CentralLayout.Size.Y)
                        {
                            CentralLayout.MouseMotionEvent(new MmEventData
                            {
                                X = sdlEvent.Motion.X,
                                Y = sdlEvent.Motion.Y,
                                Dx = sdlEvent.Motion.Xrel,
                                Dy = sdlEvent.Motion.Yrel
                            });
                        }
                        break;
                }
            }

            CentralLayout.Update();

            var gl = GL.GetApi(m_Context);
            gl.Viewport(0, 0, (uint)Size.X, (uint)Size.Y);
            CentralLayout.Size = new Vector2(m_Size.X, m_Size.Y);

            // render skia sharp
            using (var windowCanvas = m_Surface.Canvas)
            {
                windowCanvas.Clear(UIKitApplication.Style.GetStyleColor(UIKitStyle.StyleColor.BackgroundBase));

                CentralLayout.Paint(windowCanvas);

                windowCanvas.Flush();
            }

            m_Sdl.GLSwapWindow(m_NativeWindow);
        }
    }

    /// <summary>
    /// Recreates the surface, used when resizing the window.
    /// </summary>
    private void RecreateSurface()
    {
        m_Surface.Dispose();
        var renderTarget = new GRBackendRenderTarget(
            Size.X,
            Size.Y,
            0,
            8,
            new GRGlFramebufferInfo(0u, 0x8058)
        );

        m_Surface = SKSurface.Create(m_GrContext, renderTarget, GRSurfaceOrigin.BottomLeft, SKColorType.Rgba8888);
    }

    private void ReleaseUnmanagedResources()
    {
        unsafe
        {
            Sdl.GetApi().DestroyWindow(m_NativeWindow);
        }
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    ~Window()
    {
        ReleaseUnmanagedResources();
    }
}
