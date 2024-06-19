using System.Numerics;
using SkiaSharp;
using UIKit.Controls;

namespace UIKit.Styles;

/// <summary>
/// A UI Style based heavily around the Adobe Spectrum UI Guidelines.
/// Originally Built for LynxAnimator.
/// </summary>
public class UIKSpectrumStyle : UIKitStyle
{
    #region Colors

    // even if not used we need them in case they DO get used later on.
    // ReSharper disable UnusedMember.Local
    private static readonly SKColor DarkGray50 = SKColor.Parse("#252525");
    private static readonly SKColor DarkGray75 = SKColor.Parse("#2F2F2F");
    private static readonly SKColor DarkGray100 = SKColor.Parse("#323232");
    private static readonly SKColor DarkGray200 = SKColor.Parse("#393939");
    private static readonly SKColor DarkGray300 = SKColor.Parse("#3E3E3E");
    private static readonly SKColor DarkGray400 = SKColor.Parse("#4D4D4D");
    private static readonly SKColor DarkGray500 = SKColor.Parse("#5C5C5C");
    private static readonly SKColor DarkGray600 = SKColor.Parse("#7B7B7B");
    private static readonly SKColor DarkGray700 = SKColor.Parse("#999999");
    private static readonly SKColor DarkGray800 = SKColor.Parse("#CDCDCD");
    private static readonly SKColor DarkGray900 = SKColor.Parse("#FFFFFF");
    private static readonly SKColor DarkBlue400 = SKColor.Parse("#2680EB");
    private static readonly SKColor DarkBlue500 = SKColor.Parse("#378EF0");
    private static readonly SKColor DarkBlue600 = SKColor.Parse("#4B9CF5");
    private static readonly SKColor DarkBlue700 = SKColor.Parse("#5AA9FA");
    private static readonly SKColor DarkRed400 = SKColor.Parse("#E34850");
    private static readonly SKColor DarkRed500 = SKColor.Parse("#EC5B62");
    private static readonly SKColor DarkRed600 = SKColor.Parse("#F76D74");
    private static readonly SKColor DarkRed700 = SKColor.Parse("#FF7B82");
    private static readonly SKColor DarkOrange400 = SKColor.Parse("#E68619");
    private static readonly SKColor DarkOrange500 = SKColor.Parse("#F29423");
    private static readonly SKColor DarkOrange600 = SKColor.Parse("#F9A43F");
    private static readonly SKColor DarkOrange700 = SKColor.Parse("#FFB55B");
    private static readonly SKColor DarkGreen400 = SKColor.Parse("#2D9D78");
    private static readonly SKColor DarkGreen500 = SKColor.Parse("#33AB84");
    private static readonly SKColor DarkGreen600 = SKColor.Parse("#39B990");
    private static readonly SKColor DarkGreen700 = SKColor.Parse("#3FC89C");
    private static readonly SKColor DarkIndigo400 = SKColor.Parse("#6767EC");
    private static readonly SKColor DarkIndigo500 = SKColor.Parse("#7575F1");
    private static readonly SKColor DarkIndigo600 = SKColor.Parse("#8282F6");
    private static readonly SKColor DarkIndigo700 = SKColor.Parse("#9090FA");
    private static readonly SKColor DarkCelery400 = SKColor.Parse("#44B556");
    private static readonly SKColor DarkCelery500 = SKColor.Parse("#4BC35F");
    private static readonly SKColor DarkCelery600 = SKColor.Parse("#51D267");
    private static readonly SKColor DarkCelery700 = SKColor.Parse("#58E06F");
    private static readonly SKColor DarkMagenta400 = SKColor.Parse("#D83790");
    private static readonly SKColor DarkMagenta500 = SKColor.Parse("#E2499D");
    private static readonly SKColor DarkMagenta600 = SKColor.Parse("#EC5AAA");
    private static readonly SKColor DarkMagenta700 = SKColor.Parse("#F56BB7");
    private static readonly SKColor DarkYellow400 = SKColor.Parse("#DFBF00");
    private static readonly SKColor DarkYellow500 = SKColor.Parse("#EDCC00");
    private static readonly SKColor DarkYellow600 = SKColor.Parse("#FAD900");
    private static readonly SKColor DarkYellow700 = SKColor.Parse("#FFE22E");
    private static readonly SKColor DarkFuchsia400 = SKColor.Parse("#C038CC");
    private static readonly SKColor DarkFuchsia500 = SKColor.Parse("#CF3EDC");
    private static readonly SKColor DarkFuchsia600 = SKColor.Parse("#D951E5");
    private static readonly SKColor DarkFuchsia700 = SKColor.Parse("#E366EF");
    private static readonly SKColor DarkSeafoam400 = SKColor.Parse("#1B959A");
    private static readonly SKColor DarkSeafoam500 = SKColor.Parse("#20A3A8");
    private static readonly SKColor DarkSeafoam600 = SKColor.Parse("#23B2B8");
    private static readonly SKColor DarkSeafoam700 = SKColor.Parse("#26C0C7");
    private static readonly SKColor DarkChartreuse400 = SKColor.Parse("#85D044");
    private static readonly SKColor DarkChartreuse500 = SKColor.Parse("#8EDE49");
    private static readonly SKColor DarkChartreuse600 = SKColor.Parse("#9BEC54");
    private static readonly SKColor DarkChartreuse700 = SKColor.Parse("#A3F858");
    private static readonly SKColor DarkPurple400 = SKColor.Parse("#9256D9");
    private static readonly SKColor DarkPurple500 = SKColor.Parse("#9D64E1");
    private static readonly SKColor DarkPurple600 = SKColor.Parse("#A873E9");
    private static readonly SKColor DarkPurple700 = SKColor.Parse("#B483F0");
    // ReSharper enable UnusedMember.Local

    #endregion

    public override SKColor GetStyleColor(StyleColor color)
    {
        // don't add a default. we want a warning for when new values are added and we don't cover them.
        return color switch
        {
            StyleColor.BackgroundBase => DarkGray50,
            StyleColor.BackgroundLayer1 => DarkGray75,
            StyleColor.BackgroundLayer2 => DarkGray100,
            StyleColor.Border => DarkGray300,
            StyleColor.Text => DarkGray800,
            StyleColor.DisabledText => DarkGray500
        };
    }

    public override void DrawPrimitive(SKCanvas canvas, PrimitiveType primitiveType, StyleState state, Widget widget)
    {
        switch (primitiveType)
        {
            case PrimitiveType.Button:
                var paddedSize = widget.Size - new Vector2(4.0f, 4.0f);

                // todo: animate
                switch (state)
                {
                    default:
                    case StyleState.Normal:
                        canvas.DrawRoundRect(2, 2, paddedSize.X, paddedSize.Y, 4, 4, new SKPaint
                        {
                            Color = DarkGray75,
                            Style = SKPaintStyle.Fill,
                            IsAntialias = true
                        });
                        canvas.DrawRoundRect(2, 2, paddedSize.X, paddedSize.Y, 4, 4, new SKPaint
                        {
                            Color = DarkGray400,
                            Style = SKPaintStyle.Stroke,
                            StrokeWidth = 1.0f,
                            IsAntialias = true
                        });
                        break;
                    case StyleState.Hovered:
                        canvas.DrawRoundRect(2, 2, paddedSize.X, paddedSize.Y, 4, 4, new SKPaint
                        {
                            Color = DarkGray500,
                            Style = SKPaintStyle.Fill,
                            IsAntialias = true
                        });
                        canvas.DrawRoundRect(2, 2, paddedSize.X, paddedSize.Y, 4, 4, new SKPaint
                        {
                            Color = DarkGray300,
                            Style = SKPaintStyle.Stroke,
                            StrokeWidth = 1.0f,
                            IsAntialias = true
                        });
                        break;
                    case StyleState.Pressed:
                        canvas.DrawRoundRect(2, 2, paddedSize.X, paddedSize.Y, 4, 4, new SKPaint
                        {
                            Color = DarkGray300,
                            Style = SKPaintStyle.Fill,
                            IsAntialias = true
                        });
                        canvas.DrawRoundRect(2, 2, paddedSize.X, paddedSize.Y, 4, 4, new SKPaint
                        {
                            Color = DarkGray600,
                            Style = SKPaintStyle.Stroke,
                            StrokeWidth = 1.0f,
                            IsAntialias = true
                        });
                        break;
                }

                break;
        }
    }
}
