using SkiaSharp;
using UIKit.Controls;

namespace UIKit.Styles;

/// <summary>
/// Base class inherited by all control styles for UIKit
/// </summary>
public abstract class UIKitStyle
{
    public enum StyleState
    {
        Pressed,
        Hovered,
        Normal,
        Disabled,
        Selected
    }
    
    public enum PrimitiveType
    {
        Button,
        Field,
        Frame
    }
    
    public abstract void DrawPrimitive(SKCanvas canvas, PrimitiveType primitiveType, StyleState state, Widget widget);
}
