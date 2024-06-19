using System.Numerics;
using Silk.NET.SDL;
using SkiaSharp;
using UIKit.Styles;

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
        
        UIKitApplication.Style.DrawPrimitive(canvas, UIKitStyle.PrimitiveType.Field, UIKitStyle.StyleState.Normal, this);

        if (Text == string.Empty)
        {
            var lineHeight = SKTypeface.Default.ToFont().Metrics.XHeight;
            
            canvas.DrawText(Placeholder, 6, (Size.Y / 2) + (lineHeight / 2), new SKPaint
            {
                Color = UIKitApplication.Style.GetStyleColor(UIKitStyle.StyleColor.DisabledText),
                TextSize = 16.0f,
                TextAlign = SKTextAlign.Left,
                IsStroke = false,
                IsAntialias = true
            });
        }
        else
        {
            var lineHeight = SKTypeface.Default.ToFont().Metrics.XHeight;
            
            canvas.DrawText(Text, 6, (Size.Y / 2) + (lineHeight / 2), new SKPaint
            {
                Color = UIKitApplication.Style.GetStyleColor(UIKitStyle.StyleColor.Text),
                TextSize = 16.0f,
                TextAlign = SKTextAlign.Left,
                IsStroke = false,
                IsAntialias = true
            });
        }
    }

    // we don't implement OnFocusEvent as we don't do anything special when focused
}
