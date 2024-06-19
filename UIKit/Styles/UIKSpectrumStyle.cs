using SkiaSharp;
using UIKit.Controls;

namespace UIKit.Styles;

/// <summary>
/// A UI Style based heavily around the Adobe Spectrum UI Guidelines.
/// Originally Built for LynxAnimator.
/// </summary>
public class UIKSpectrumStyle : UIKitStyle
{
    public override void DrawPrimitive(SKCanvas canvas, PrimitiveType primitiveType, Widget widget)
    {
        switch(primitiveType)
        {
            case PrimitiveType.Button:
                break;
        }
    }
}
