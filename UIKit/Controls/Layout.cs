using SkiaSharp;
using UIKit.Styles;

namespace UIKit.Controls;

/// <summary>
/// Base class for all layouts
/// </summary>
public abstract class Layout : Widget
{
    protected Layout(Widget? parent) : base(parent)
    {
    }

    public abstract void ArrangeChildren();
    
    protected override void OnUpdateEvent()
    {
        ArrangeChildren();
    }
}

/// <summary>
/// A layout allowing for absolute positioning of widgets
/// </summary>
public class AbsoluteLayout : Layout
{
    public AbsoluteLayout(Widget? parent) : base(parent)
    {
    }

    public override void ArrangeChildren()
    {
    }
}
