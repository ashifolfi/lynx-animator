using LibXfl;
using SkiaSharp;
using UIKit;
using UIKit.Controls;

namespace LynxAnimator.GUI.Controls;

public class SolidSwatchGroupItem : Button
{
    public SolidSwatchItem SwatchItem;

    public SolidSwatchGroupItem(Widget? parent) : base(parent)
    {
    }

    public SolidSwatchGroupItem(Widget? parent, SolidSwatchItem swatchItem) : base(parent)
    {
        SwatchItem = swatchItem;
    }
    
    protected override bool OnMouseButtonEvent(MbEventData data)
    {
        switch (data)
        {
            case { Button: MbEventData.LeftButton, Pressed: true }:
                Console.WriteLine($"Color Pressed: {SwatchItem.Color[0]} {SwatchItem.Color[1]} {SwatchItem.Color[2]}");
                return true;
        }

        return false;
    }

    protected override void OnPaintEvent()
    {
        using var canvas = Surface.Canvas;
        canvas.DrawRect(0, 0, Size.X, Size.Y, new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = new SKColor(SwatchItem.Color[0], SwatchItem.Color[1], SwatchItem.Color[2])
        });
    }
}
