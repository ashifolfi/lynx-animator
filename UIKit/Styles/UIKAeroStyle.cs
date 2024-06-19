using System.Numerics;
using SkiaSharp;
using UIKit.Controls;

namespace UIKit.Styles;

public class UIKAeroStyle : UIKitStyle
{
    private static readonly SKColor ButtonFace = SKColor.Parse("#f2f2f2");
    private static readonly SKColor ButtonFaceHover = SKColor.Parse("#eaf6fd");
    private static readonly SKColor ButtonFaceActive = SKColor.Parse("#c4e5f6");
    private static readonly SKColor ButtonShadeLight = SKColor.Parse("#ebebeb");
    private static readonly SKColor ButtonShadeLightHover = SKColor.Parse("#bee6fd");
    private static readonly SKColor ButtonShadeLightActive = SKColor.Parse("#98d1ef");
    private static readonly SKColor ButtonShadeDark = SKColor.Parse("#cfcfcf");
    private static readonly SKColor ButtonShadeDarkHover = SKColor.Parse("#a7d9f5");
    private static readonly SKColor ButtonShadeDarkActive = SKColor.Parse("#68b3db");
    
    public override SKTypeface DefaultTypeface { get; }

    public UIKAeroStyle()
    {
        DefaultTypeface = SKTypeface.Default;
    }
    
    public override void DrawPrimitive(SKCanvas canvas, PrimitiveType primitiveType, StyleState state, Widget widget)
    {
        switch (primitiveType)
        {
            case PrimitiveType.ButtonFrame:
                // 1px border size
                var padSize = widget.Size - new Vector2(2.0f, 2.0f);

                switch (state)
                {
                    case StyleState.Normal:
                    {
                        var shader = SKShader.CreateLinearGradient(
                            new SKPoint(0, 0), new SKPoint(0, padSize.Y),
                            [ButtonFace, ButtonShadeLight, ButtonShadeDark],
                            [0.45f, 0.45f, 1.0f], SKShaderTileMode.Clamp
                        );
                        canvas.DrawRoundRect(1, 1, padSize.X, padSize.Y, 3.0f, 3.0f, new SKPaint
                        {
                            Style = SKPaintStyle.Fill,
                            Shader = shader
                        });
                        break;
                    }
                    case StyleState.Hovered:
                    {
                        var shader = SKShader.CreateLinearGradient(
                            new SKPoint(0, 0), new SKPoint(0, padSize.Y),
                            [ButtonFaceHover, ButtonShadeLightHover, ButtonShadeDarkHover],
                            [0.45f, 0.45f, 1.0f], SKShaderTileMode.Clamp
                        );
                        canvas.DrawRoundRect(1, 1, padSize.X, padSize.Y, 3.0f, 3.0f, new SKPaint
                        {
                            Style = SKPaintStyle.Fill,
                            Shader = shader
                        });
                        break;
                    }
                    case StyleState.Pressed:
                    {
                        var shader = SKShader.CreateLinearGradient(
                            new SKPoint(0, 0), new SKPoint(0, padSize.Y),
                            [ButtonFaceActive, ButtonShadeLightActive, ButtonShadeDarkActive],
                            [0.45f, 0.45f, 1.0f], SKShaderTileMode.Clamp
                        );
                        canvas.DrawRoundRect(1, 1, padSize.X, padSize.Y, 3.0f, 3.0f, new SKPaint
                        {
                            Style = SKPaintStyle.Fill,
                            Shader = shader
                        });
                        break;
                    }
                }
                
                // draw button border
                canvas.DrawRoundRect(1, 1, padSize.X, padSize.Y, 3.0f, 3.0f, new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 1.0f,
                    IsAntialias = true,
                    Color = SKColor.Parse("#8e8f8f")
                });
                
                break;
        }
    }

    public override void DrawControl(SKCanvas canvas, ControlType control, StyleState state, Widget widget)
    {
        switch (control)
        {
            case ControlType.Button:
                DrawPrimitive(
                    canvas,
                    PrimitiveType.ButtonFrame,
                    state,
                    widget
                );

                var widgetButton = (Button)widget;

                var font = DefaultTypeface.ToFont(14.0f);
                canvas.DrawText(widgetButton?.Text,
                    widget.Size.X / 2, (widget.Size.Y / 2) + ((font.Metrics.CapHeight - font.Metrics.Descent) / 2), font,
                    new SKPaint
                    {
                        Color = UIKitApplication.Style.GetStyleColor(StyleColor.Text),
                        TextAlign = SKTextAlign.Center,
                        IsStroke = false,
                        IsAntialias = true
                    }
                );
                
                break;
        }
    }

    public override SKColor GetStyleColor(StyleColor color)
    {
        return color switch
        {
            StyleColor.BackgroundBase => SKColors.White,
            StyleColor.BackgroundLayer1 => SKColors.White,
            StyleColor.BackgroundLayer2 => SKColors.White,
            StyleColor.Border => SKColors.Black,
            StyleColor.Text => SKColors.Black,
            StyleColor.DisabledText => SKColors.Gray
        };
    }
}
