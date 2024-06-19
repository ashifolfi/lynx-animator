using SkiaSharp;
using UIKit.Controls;

namespace UIKit.Styles;

/// <summary>
/// Base class inherited by all control styles for UIKit
/// </summary>
public abstract class UIKitStyle
{
    public enum PrimitiveType
    {
        Button
    }
    
    public abstract void DrawPrimitive(SKCanvas canvas, PrimitiveType primitiveType, Widget widget);
}
