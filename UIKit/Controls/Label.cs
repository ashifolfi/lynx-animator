using SkiaSharp;
using UIKit.Styles;
using UIKit.Extentions;

namespace UIKit.Controls;

public class Label : Widget
{
    public string Text = "";

    public Label(Widget? parent) : base(parent)
    {
    }

    public Label(Widget? parent, string text) : base(parent)
    {
        Text = text;
    }
    
    protected override void OnPaintEvent()
    {
        using var canvas = Surface.Canvas;
        
        canvas.DrawTextExt(Text, Position.X, Position.Y,
            UIKitApplication.Style.DefaultTypeface.ToFont(14.0f),
            new SKPaint
            {
                IsAntialias = true,
                IsStroke = false,
                Color = UIKitApplication.Style.GetStyleColor(UIKitStyle.StyleColor.Text)
            }
        );
    }
}
