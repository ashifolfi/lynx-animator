using SkiaSharp;
using UIKit.Controls;

namespace UIKit.Styles;

/// <summary>
/// Base class inherited by all control styles for UIKit
/// </summary>
public abstract class UIKitStyle
{
    public enum ControlType
    {
        Button
    }
    
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
        ButtonFrame,
        FieldFrame
    }

    public enum StyleColor
    {
        BackgroundBase,
        BackgroundLayer1,
        BackgroundLayer2,
        Text,
        DisabledText,
        Border,
    }
    
    public abstract SKTypeface DefaultTypeface { get; }
    
    public abstract void DrawPrimitive(SKCanvas canvas, PrimitiveType primitiveType, StyleState state, Widget widget);
    public abstract void DrawControl(SKCanvas canvas, ControlType control, StyleState state, Widget widget);
    public abstract SKColor GetStyleColor(StyleColor color);
}
