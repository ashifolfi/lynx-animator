using System.Numerics;
using Silk.NET.SDL;
using SkiaSharp;

namespace UIKit.Controls;

public class InputField : Widget, IFocusable
{
    public string Placeholder = "";
    public string Text = "";
    public bool IsFocused { get; set; }

    public EventHandler<string>? OnTextChanged;
    public EventHandler<string>? OnSubmit;

    private bool ShiftMode = false;

    public InputField(Widget? parent) : base(parent)
    {
    }

    protected override bool OnMouseButtonEvent(MbEventData data)
    {
        switch (data)
        {
            case { Button: MbEventData.LeftButton, Pressed: true }:
                // fuck ass line of code
                ((IFocusable)this).Focus();
                return true;
        }

        return false;
    }

    protected override bool OnKeyboardEvent(KbEventData data)
    {
        if (data.Key is KeyCode.KRshift or KeyCode.KLshift)
        {
            ShiftMode = data.Pressed;
            return true;
        }

        if (data.Pressed)
        {
            switch (data.Key)
            {
                case KeyCode.KBackspace or KeyCode.KKPBackspace:
                {
                    if (Text.Length > 0)
                        Text = Text.Remove(Text.Length - 1);
                    break;
                }
            }
        }
        return true;
    }

    protected override bool OnTextInputEvent(string text)
    {
        Text = Text.Insert(Text.Length, text);
        return true;
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
        
        canvas.DrawRoundRect(2, 2, aSize.X, aSize.Y, 4, 4, new SKPaint
        {
            Color = new SKColor(20, 20, 20),
            Style = SKPaintStyle.Fill,
            IsAntialias = true
        });

        if (Text == string.Empty)
        {
            canvas.DrawText(Placeholder, 6, Size.Y / 2, new SKPaint
            {
                Color = SKColors.Gray,
                TextSize = 16.0f,
                TextAlign = SKTextAlign.Left,
                IsStroke = false,
                IsAntialias = true
            });
        }
        else
        {
            canvas.DrawText(Text, 6, Size.Y / 2, new SKPaint
            {
                Color = SKColors.White,
                TextSize = 16.0f,
                TextAlign = SKTextAlign.Left,
                IsStroke = false,
                IsAntialias = true
            });
        }
    }

    // we don't implement OnFocusEvent as we don't do anything special when focused
}
