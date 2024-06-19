using System.Numerics;
using SkiaSharp;

namespace UIKit.Controls;

public class VerticalListLayout : Layout
{
    public float Separation = 2.0f;

    public VerticalListLayout(Widget? parent) : base(parent)
    {
    }
    
    public override void ArrangeChildren()
    {
        var yOffset = 0.0f;
        foreach (var widget in Children)
        {
            // change position to match up with list
            widget.Position = new Vector2(0, yOffset);
            yOffset += Separation + widget.Size.Y;
        }
    }
}

public class HorizontalListLayout : Layout
{
    public float Separation = 2.0f;

    public HorizontalListLayout(Widget? parent) : base(parent)
    {
    }
    
    public override void ArrangeChildren()
    {
        var xOffset = 0.0f;
        foreach (var widget in Children)
        {
            // change position to match up with list
            widget.Position = new Vector2(xOffset, 0.0f);
            
            // adjust size based on policy
            switch (widget.HorizontalSizePolicy)
            {
                case SizePolicy.Maximum:
                    break;
            }
            
            xOffset += Separation + widget.Size.X;
        }
    }
}
