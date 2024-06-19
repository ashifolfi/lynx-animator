using SkiaSharp;

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
        
        using var paint = new SKPaint();
        paint.TextSize = 16.0f;
        paint.IsAntialias = true;
        paint.Color = SKColors.White;
        paint.IsStroke = false;

        canvas.DrawText(Text, Position.X, Position.Y, paint);
    }
}
