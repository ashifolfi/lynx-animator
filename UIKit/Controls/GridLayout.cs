using System.Numerics;
using SkiaSharp;
using UIKit.Styles;

namespace UIKit.Controls;

public class GridLayout : Layout
{
    public float Separation = 2.0f;

    public GridLayout(Widget? parent) : base(parent)
    {
    }

    public override void ArrangeChildren()
    {
        var tallestY = 0.0f;
        var offset = Vector2.Zero;
        foreach (var child in Children)
        {
            if (child.Size.Y > tallestY)
                tallestY = child.Size.Y;

            // change position to match up with list
            if (offset.X + child.Size.X + Separation > Size.X)
            {
                offset.X = 0.0f;
                offset.Y += Separation + tallestY;
                tallestY = 0.0f;
            }

            child.Position = offset;
            offset.X += child.Size.X;
        }
    }
    
    protected override void OnPaintEvent()
    {
        using var canvas = Surface.Canvas;
        
        canvas.DrawRect(0, 0, Size.X, Size.Y, new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = UIKitApplication.Style.GetStyleColor(UIKitStyle.StyleColor.BackgroundLayer1)
        });
    }
}
