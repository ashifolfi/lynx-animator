using System.Numerics;
using SkiaSharp;

namespace UIKit.Controls;

public class Button : Widget
{
    public enum ButtonState
    {
        Normal,
        Hovered,
        Pressed
    }
    
    public string Text = "";
    public ButtonState State = ButtonState.Normal;
    public EventHandler? OnPressed;

    public Button(Widget? parent) : base(parent)
    {
    }

    public Button(Widget? parent, string text) : base(parent)
    {
        Text = text;
    }
    
    protected override bool OnMouseButtonEvent(MbEventData data)
    {
        switch (data)
        {
            case { Button: MbEventData.LeftButton, Pressed: true }:
                State = ButtonState.Pressed;
                return true;
            case { Button: MbEventData.LeftButton, Pressed: false }:
                if (State == ButtonState.Pressed)
                    OnPressed?.Invoke(this, EventArgs.Empty);
                State = IsHovered ? ButtonState.Hovered : ButtonState.Normal;
                return true;
        }

        return false;
    }

    protected override void OnUpdateEvent()
    {
        State = IsHovered switch
        {
            // keep the value if we fail this check, retains the pressed state
            true when State != ButtonState.Pressed => ButtonState.Hovered,
            false when State != ButtonState.Pressed => ButtonState.Normal,
            _ => State
        };
    }

    protected override void OnPaintEvent()
    {
        using var canvas = Surface.Canvas;

        var aSize = Size - new Vector2(4.0f, 4.0f);
        
        canvas.DrawRoundRect(2, 2, aSize.X, aSize.Y, 4, 4, new SKPaint
        {
            StrokeWidth = 2.0f,
            Color = SKColors.DarkGray,
            Style = SKPaintStyle.Stroke,
            IsAntialias = true
        });

        // rider why are you asking me to add default, I have a case for every value in ButtonState?
        switch (State)
        {
            case ButtonState.Normal:
                canvas.DrawRoundRect(2, 2, aSize.X, aSize.Y, 4, 4, new SKPaint
                {
                    Color = new SKColor(50, 50, 50),
                    Style = SKPaintStyle.Fill,
                    IsAntialias = true
                });
                break;
            case ButtonState.Pressed:
                canvas.DrawRoundRect(2, 2, aSize.X, aSize.Y, 4, 4, new SKPaint
                {
                    Color = new SKColor(20, 20, 20),
                    Style = SKPaintStyle.Fill,
                    IsAntialias = true
                });
                break;
            case ButtonState.Hovered:
                canvas.DrawRoundRect(2, 2, aSize.X, aSize.Y, 4, 4, new SKPaint
                {
                    Color = new SKColor(80, 80, 80),
                    Style = SKPaintStyle.Fill,
                    IsAntialias = true
                });
                break;
        }
        
        canvas.DrawText(Text, Size.X / 2, Size.Y / 2, new SKPaint
        {
            Color = SKColors.White,
            TextSize = 16.0f,
            TextAlign = SKTextAlign.Center,
            IsStroke = false,
            IsAntialias = true
        });
    }
}
