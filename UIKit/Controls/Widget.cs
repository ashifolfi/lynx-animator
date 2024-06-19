using System.Numerics;
using SkiaSharp;

namespace UIKit.Controls;

public abstract class Widget
{
    public Vector2 Position;
    public Vector2 GlobalPosition => Parent != null ? Position + Parent.GlobalPosition : Position;
    // reasonable defaults
    /// <summary>
    /// The absolute smallest size a widget can be
    /// </summary>
    public Vector2 MinimumSize = new(16, 16);
    /// <summary>
    /// The absolute largest size a widget can be
    /// </summary>
    public Vector2 MaximumSize = new(10000, 10000);
    public Vector2 Size
    {
        get => m_Size;
        set
        {
            m_Size = new Vector2(
                Math.Clamp(value.X, MinimumSize.X, MaximumSize.X),
                Math.Clamp(value.Y, MinimumSize.Y, MaximumSize.Y)
            );
            RecreateSurface();
        }
    }
    public SKSurface Surface
    {
        get
        {
            if (m_WSurface == null)
                RecreateSurface();
            // if this is null then I want to crash. because it shouldn't be.
            return m_WSurface;
        }
    }
    
    public bool IsHovered = false;
    public Widget? Parent;
    public IReadOnlyList<Widget> Children => m_Children;
    
    private Vector2 m_Size;
    private SKSurface? m_WSurface;
    private List<Widget> m_Children = [];

    public Widget(Widget? parent)
    {
        parent?.AddChild(this);
        
        m_WSurface = SKSurface.Create(new SKImageInfo((int)Size.X, (int)Size.Y));
    }

    public void AddChild(Widget widget)
    {
        // Unparent this widget if it's already parented
        widget.Parent?.RemoveChild(widget);

        m_Children.Add(widget);
        widget.Parent = this;
    }

    public void RemoveChild(Widget widget)
    {
        if (m_Children.Remove(widget))
            widget.Parent = null;
    }
    
    public void Update()
    {
        OnUpdateEvent();
        foreach (var widget in m_Children)
        {
            widget.Update();
        }
    }

    public void Paint(SKCanvas canvas)
    {
        if (m_WSurface == null)
            RecreateSurface(); // create surface if it doesn't exist yet

        m_WSurface?.Canvas.Clear(SKColor.Empty);
        OnPaintEvent();

        foreach (var child in m_Children)
        {
            child.Paint(Surface.Canvas);
        }
        
        m_WSurface?.Draw(canvas, Position.X, Position.Y, new SKPaint
        {
            Color = SKColors.White,
            Style = SKPaintStyle.Fill
        });
    }

    /// <summary>
    /// Mouse Button Event Handler
    /// </summary>
    /// <param name="eventData">Button Event</param>
    /// <returns>Handled or not</returns>
    public bool MouseButtonEvent(MbEventData eventData)
    {
        if (!OnMouseButtonEvent(eventData))
        {
            foreach (var widget in Children)
            {
                if (eventData.X > widget.GlobalPosition.X && eventData.X < widget.GlobalPosition.X + widget.Size.X
                    && eventData.Y > widget.GlobalPosition.Y && eventData.Y < widget.GlobalPosition.Y + widget.Size.Y)
                {
                    if (widget.MouseButtonEvent(eventData))
                    {
                        return true;
                    }
                }
            }
            // was not handled
            return false;
        }
        return true;
    }

    public bool KeyboardEvent(KbEventData eventData)
    {
        if (!OnKeyboardEvent(eventData))
        {
            foreach (var widget in Children)
            {
                if (widget is IFocusable { IsFocused: true })
                {
                    if (widget.KeyboardEvent(eventData))
                    {
                        return true;
                    }
                }
            }
            
            // was not handled
            return false;
        }
        
        return true;
    }

    public bool TextInputEvent(string text)
    {
        if (!OnTextInputEvent(text))
        {
            Console.WriteLine(text);
            foreach (var widget in Children)
            {
                if (widget is IFocusable { IsFocused: true })
                {
                    if (widget.TextInputEvent(text))
                    {
                        return true;
                    }
                }
            }
            
            // was not handled
            return false;
        }

        return true;
    }
    
    private void RecreateSurface()
    {
        m_WSurface?.Dispose();
        m_WSurface = SKSurface.Create(new SKImageInfo((int)Size.X, (int)Size.Y));
    }

    #region Events

    // Input Events
    
    /// <summary>
    /// Mouse Button Event Handler
    /// </summary>
    /// <param name="data">Button Event</param>
    /// <returns>Handled or not</returns>
    protected virtual bool OnMouseButtonEvent(MbEventData data)
    {
        return false;
    }

    protected virtual bool OnKeyboardEvent(KbEventData data)
    {
        return false;
    }

    protected virtual bool OnTextInputEvent(string text)
    {
        return false;
    }
    
    protected virtual void OnUpdateEvent()
    {
    }
    
    protected virtual void OnPaintEvent()
    {
    }

    #endregion
}
