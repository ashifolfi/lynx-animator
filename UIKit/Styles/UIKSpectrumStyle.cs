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

    // todo: these colors feel off.
    // even if not used we need them in case they DO get used later on.
    // ReSharper disable UnusedMember.Local
    private static readonly SKColor DarkGray50 = new(29, 29, 29);
    private static readonly SKColor DarkGray75 = new(38, 38, 38);
    private static readonly SKColor DarkGray100 = new(50, 50, 50);
    private static readonly SKColor DarkGray200 = new(63, 63, 63);
    private static readonly SKColor DarkGray300 = new(84, 84, 84);
    private static readonly SKColor DarkGray400 = new(112, 112, 112);
    private static readonly SKColor DarkGray500 = new(144, 144, 144);
    private static readonly SKColor DarkGray600 = new(178, 178, 178);
    private static readonly SKColor DarkGray700 = new(209, 209, 209);
    private static readonly SKColor DarkGray800 = new(235, 235, 235);
    private static readonly SKColor DarkGray900 = new(255, 255, 255);
    private static readonly SKColor DarkBlue100 = new(0, 56, 119);
    private static readonly SKColor DarkBlue200 = new(0, 65, 138);
    private static readonly SKColor DarkBlue300 = new(0, 77, 163);
    private static readonly SKColor DarkBlue400 = new(0, 89, 194);
    private static readonly SKColor DarkBlue500 = new(3, 103, 224);
    private static readonly SKColor DarkBlue600 = new(19, 121, 243);
    private static readonly SKColor DarkBlue700 = new(52, 143, 244);
    private static readonly SKColor DarkBlue800 = new(84, 163, 246);
    private static readonly SKColor DarkBlue900 = new(114, 183, 249);
    private static readonly SKColor DarkBlue1000 = new(143, 202, 252);
    private static readonly SKColor DarkBlue1100 = new(174, 219, 254);
    private static readonly SKColor DarkBlue1200 = new(204, 233, 255);
    private static readonly SKColor DarkBlue1300 = new(232, 246, 255);
    private static readonly SKColor DarkBlue1400 = new(255, 255, 255);
    private static readonly SKColor DarkRed100 = new(123, 0, 0);
    private static readonly SKColor DarkRed200 = new(141, 0, 0);
    private static readonly SKColor DarkRed300 = new(165, 0, 0);
    private static readonly SKColor DarkRed400 = new(190, 4, 3);
    private static readonly SKColor DarkRed500 = new(215, 25, 19);
    private static readonly SKColor DarkRed600 = new(234, 56, 41);
    private static readonly SKColor DarkRed700 = new(246, 88, 67);
    private static readonly SKColor DarkRed800 = new(255, 117, 94);
    private static readonly SKColor DarkRed900 = new(255, 149, 129);
    private static readonly SKColor DarkRed1000 = new(255, 176, 161);
    private static readonly SKColor DarkRed1100 = new(255, 201, 189);
    private static readonly SKColor DarkRed1200 = new(255, 222, 216);
    private static readonly SKColor DarkRed1300 = new(255, 241, 238);
    private static readonly SKColor DarkRed1400 = new(255, 255, 255);
    private static readonly SKColor DarkOrange100 = new(102, 37, 0);
    private static readonly SKColor DarkOrange200 = new(117, 45, 0);
    private static readonly SKColor DarkOrange300 = new(137, 55, 0);
    private static readonly SKColor DarkOrange400 = new(158, 66, 0);
    private static readonly SKColor DarkOrange500 = new(180, 78, 0);
    private static readonly SKColor DarkOrange600 = new(202, 93, 0);
    private static readonly SKColor DarkOrange700 = new(225, 109, 0);
    private static readonly SKColor DarkOrange800 = new(244, 129, 12);
    private static readonly SKColor DarkOrange900 = new(254, 154, 46);
    private static readonly SKColor DarkOrange1000 = new(255, 181, 88);
    private static readonly SKColor DarkOrange1100 = new(253, 206, 136);
    private static readonly SKColor DarkOrange1200 = new(255, 225, 179);
    private static readonly SKColor DarkOrange1300 = new(255, 242, 221);
    private static readonly SKColor DarkOrange1400 = new(255, 253, 249);
    private static readonly SKColor DarkYellow100 = new(76, 54, 0);
    private static readonly SKColor DarkYellow200 = new(88, 64, 0);
    private static readonly SKColor DarkYellow300 = new(103, 76, 0);
    private static readonly SKColor DarkYellow400 = new(119, 89, 0);
    private static readonly SKColor DarkYellow500 = new(136, 104, 0);
    private static readonly SKColor DarkYellow600 = new(155, 120, 0);
    private static readonly SKColor DarkYellow700 = new(174, 137, 0);
    private static readonly SKColor DarkYellow800 = new(192, 156, 0);
    private static readonly SKColor DarkYellow900 = new(211, 174, 0);
    private static readonly SKColor DarkYellow1000 = new(228, 194, 0);
    private static readonly SKColor DarkYellow1100 = new(244, 213, 0);
    private static readonly SKColor DarkYellow1200 = new(249, 232, 92);
    private static readonly SKColor DarkYellow1300 = new(252, 246, 187);
    private static readonly SKColor DarkYellow1400 = new(255, 255, 255);
    private static readonly SKColor DarkChartreuse100 = new(48, 64, 0);
    private static readonly SKColor DarkChartreuse200 = new(55, 74, 0);
    private static readonly SKColor DarkChartreuse300 = new(65, 87, 0);
    private static readonly SKColor DarkChartreuse400 = new(76, 102, 0);
    private static readonly SKColor DarkChartreuse500 = new(89, 118, 0);
    private static readonly SKColor DarkChartreuse600 = new(102, 136, 0);
    private static readonly SKColor DarkChartreuse700 = new(117, 154, 0);
    private static readonly SKColor DarkChartreuse800 = new(132, 173, 1);
    private static readonly SKColor DarkChartreuse900 = new(148, 192, 8);
    private static readonly SKColor DarkChartreuse1000 = new(166, 211, 18);
    private static readonly SKColor DarkChartreuse1100 = new(184, 229, 37);
    private static readonly SKColor DarkChartreuse1200 = new(205, 245, 71);
    private static readonly SKColor DarkChartreuse1300 = new(231, 254, 154);
    private static readonly SKColor DarkChartreuse1400 = new(255, 255, 255);
    private static readonly SKColor DarkCelery100 = new(0, 69, 10);
    private static readonly SKColor DarkCelery200 = new(0, 80, 12);
    private static readonly SKColor DarkCelery300 = new(0, 94, 14);
    private static readonly SKColor DarkCelery400 = new(0, 109, 15);
    private static readonly SKColor DarkCelery500 = new(0, 127, 15);
    private static readonly SKColor DarkCelery600 = new(0, 145, 18);
    private static readonly SKColor DarkCelery700 = new(4, 165, 30);
    private static readonly SKColor DarkCelery800 = new(34, 184, 51);
    private static readonly SKColor DarkCelery900 = new(68, 202, 73);
    private static readonly SKColor DarkCelery1000 = new(105, 220, 99);
    private static readonly SKColor DarkCelery1100 = new(142, 235, 127);
    private static readonly SKColor DarkCelery1200 = new(180, 247, 162);
    private static readonly SKColor DarkCelery1300 = new(221, 253, 211);
    private static readonly SKColor DarkCelery1400 = new(255, 255, 255);
    private static readonly SKColor DarkGreen100 = new(4, 67, 41);
    private static readonly SKColor DarkGreen200 = new(0, 78, 47);
    private static readonly SKColor DarkGreen300 = new(0, 92, 56);
    private static readonly SKColor DarkGreen400 = new(0, 108, 67);
    private static readonly SKColor DarkGreen500 = new(0, 125, 78);
    private static readonly SKColor DarkGreen600 = new(0, 143, 93);
    private static readonly SKColor DarkGreen700 = new(18, 162, 108);
    private static readonly SKColor DarkGreen800 = new(43, 180, 125);
    private static readonly SKColor DarkGreen900 = new(67, 199, 143);
    private static readonly SKColor DarkGreen1000 = new(94, 217, 162);
    private static readonly SKColor DarkGreen1100 = new(129, 233, 184);
    private static readonly SKColor DarkGreen1200 = new(177, 244, 209);
    private static readonly SKColor DarkGreen1300 = new(223, 250, 234);
    private static readonly SKColor DarkGreen1400 = new(254, 255, 252);
    private static readonly SKColor DarkSeafoam100 = new(18, 65, 63);
    private static readonly SKColor DarkSeafoam200 = new(14, 76, 73);
    private static readonly SKColor DarkSeafoam300 = new(4, 90, 87);
    private static readonly SKColor DarkSeafoam400 = new(0, 105, 101);
    private static readonly SKColor DarkSeafoam500 = new(0, 122, 117);
    private static readonly SKColor DarkSeafoam600 = new(0, 140, 135);
    private static readonly SKColor DarkSeafoam700 = new(0, 158, 152);
    private static readonly SKColor DarkSeafoam800 = new(3, 178, 171);
    private static readonly SKColor DarkSeafoam900 = new(54, 197, 189);
    private static readonly SKColor DarkSeafoam1000 = new(93, 214, 207);
    private static readonly SKColor DarkSeafoam1100 = new(132, 230, 223);
    private static readonly SKColor DarkSeafoam1200 = new(176, 242, 236);
    private static readonly SKColor DarkSeafoam1300 = new(223, 249, 246);
    private static readonly SKColor DarkSeafoam1400 = new(254, 255, 254);
    private static readonly SKColor DarkCyan100 = new(0, 61, 98);
    private static readonly SKColor DarkCyan200 = new(0, 71, 111);
    private static readonly SKColor DarkCyan300 = new(0, 85, 127);
    private static readonly SKColor DarkCyan400 = new(0, 100, 145);
    private static readonly SKColor DarkCyan500 = new(0, 116, 162);
    private static readonly SKColor DarkCyan600 = new(0, 134, 180);
    private static readonly SKColor DarkCyan700 = new(0, 153, 198);
    private static readonly SKColor DarkCyan800 = new(14, 173, 215);
    private static readonly SKColor DarkCyan900 = new(44, 193, 230);
    private static readonly SKColor DarkCyan1000 = new(84, 211, 241);
    private static readonly SKColor DarkCyan1100 = new(127, 228, 249);
    private static readonly SKColor DarkCyan1200 = new(167, 241, 255);
    private static readonly SKColor DarkCyan1300 = new(215, 250, 255);
    private static readonly SKColor DarkCyan1400 = new(255, 255, 255);
    private static readonly SKColor DarkIndigo100 = new(40, 44, 140);
    private static readonly SKColor DarkIndigo200 = new(47, 52, 163);
    private static readonly SKColor DarkIndigo300 = new(57, 63, 187);
    private static readonly SKColor DarkIndigo400 = new(70, 75, 211);
    private static readonly SKColor DarkIndigo500 = new(85, 91, 231);
    private static readonly SKColor DarkIndigo600 = new(104, 109, 244);
    private static readonly SKColor DarkIndigo700 = new(124, 129, 251);
    private static readonly SKColor DarkIndigo800 = new(145, 149, 255);
    private static readonly SKColor DarkIndigo900 = new(167, 170, 255);
    private static readonly SKColor DarkIndigo1000 = new(188, 190, 255);
    private static readonly SKColor DarkIndigo1100 = new(208, 210, 255);
    private static readonly SKColor DarkIndigo1200 = new(226, 228, 255);
    private static readonly SKColor DarkIndigo1300 = new(243, 243, 254);
    private static readonly SKColor DarkIndigo1400 = new(255, 255, 255);
    private static readonly SKColor DarkPurple100 = new(76, 13, 157);
    private static readonly SKColor DarkPurple200 = new(89, 17, 177);
    private static readonly SKColor DarkPurple300 = new(105, 28, 200);
    private static readonly SKColor DarkPurple400 = new(122, 45, 218);
    private static readonly SKColor DarkPurple500 = new(140, 65, 233);
    private static readonly SKColor DarkPurple600 = new(157, 87, 243);
    private static readonly SKColor DarkPurple700 = new(172, 111, 249);
    private static readonly SKColor DarkPurple800 = new(187, 135, 251);
    private static readonly SKColor DarkPurple900 = new(202, 159, 252);
    private static readonly SKColor DarkPurple1000 = new(215, 182, 254);
    private static readonly SKColor DarkPurple1100 = new(228, 204, 254);
    private static readonly SKColor DarkPurple1200 = new(239, 223, 255);
    private static readonly SKColor DarkPurple1300 = new(249, 240, 255);
    private static readonly SKColor DarkPurple1400 = new(255, 253, 255);
    private static readonly SKColor DarkFuchsia100 = new(107, 3, 106);
    private static readonly SKColor DarkFuchsia200 = new(123, 0, 123);
    private static readonly SKColor DarkFuchsia300 = new(144, 0, 145);
    private static readonly SKColor DarkFuchsia400 = new(165, 13, 166);
    private static readonly SKColor DarkFuchsia500 = new(185, 37, 185);
    private static readonly SKColor DarkFuchsia600 = new(205, 57, 206);
    private static readonly SKColor DarkFuchsia700 = new(223, 81, 224);
    private static readonly SKColor DarkFuchsia800 = new(235, 110, 236);
    private static readonly SKColor DarkFuchsia900 = new(244, 140, 242);
    private static readonly SKColor DarkFuchsia1000 = new(250, 168, 245);
    private static readonly SKColor DarkFuchsia1100 = new(254, 194, 248);
    private static readonly SKColor DarkFuchsia1200 = new(255, 219, 250);
    private static readonly SKColor DarkFuchsia1300 = new(255, 239, 252);
    private static readonly SKColor DarkFuchsia1400 = new(255, 253, 255);
    private static readonly SKColor DarkMagenta100 = new(118, 0, 58);
    private static readonly SKColor DarkMagenta200 = new(137, 0, 66);
    private static readonly SKColor DarkMagenta300 = new(160, 0, 77);
    private static readonly SKColor DarkMagenta400 = new(182, 18, 90);
    private static readonly SKColor DarkMagenta500 = new(203, 38, 109);
    private static readonly SKColor DarkMagenta600 = new(222, 61, 130);
    private static readonly SKColor DarkMagenta700 = new(237, 87, 149);
    private static readonly SKColor DarkMagenta800 = new(249, 114, 167);
    private static readonly SKColor DarkMagenta900 = new(255, 143, 185);
    private static readonly SKColor DarkMagenta1000 = new(255, 172, 202);
    private static readonly SKColor DarkMagenta1100 = new(255, 198, 218);
    private static readonly SKColor DarkMagenta1200 = new(255, 221, 233);
    private static readonly SKColor DarkMagenta1300 = new(255, 240, 245);
    private static readonly SKColor DarkMagenta1400 = new(255, 252, 253);

    // ReSharper enable UnusedMember.Local

    #endregion

    public override SKTypeface DefaultTypeface => m_SansFace;
    private SKTypeface m_SansFace;

    public UIKSpectrumStyle()
    {
        m_SansFace = SKTypeface.FromFile("./fonts/SourceSans3-Regular.ttf");
    }
    
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
            {
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
            case PrimitiveType.Field:
            {
                var paddedSize = widget.Size - new Vector2(4.0f, 4.0f);

                canvas.DrawRoundRect(2, 2, paddedSize.X, paddedSize.Y, 4, 4, new SKPaint
                {
                    Color = DarkGray50,
                    Style = SKPaintStyle.Fill,
                    IsAntialias = true
                });

                // todo: animate
                switch (state)
                {
                    default:
                    case StyleState.Normal:
                        canvas.DrawRoundRect(2, 2, paddedSize.X, paddedSize.Y, 4, 4, new SKPaint
                        {
                            Color = DarkGray500,
                            Style = SKPaintStyle.Stroke,
                            StrokeWidth = 1.0f,
                            IsAntialias = true
                        });
                        break;
                    case StyleState.Hovered:
                        canvas.DrawRoundRect(2, 2, paddedSize.X, paddedSize.Y, 4, 4, new SKPaint
                        {
                            Color = DarkGray600,
                            Style = SKPaintStyle.Stroke,
                            StrokeWidth = 1.0f,
                            IsAntialias = true
                        });
                        break;
                    case StyleState.Pressed:
                        canvas.DrawRoundRect(2, 2, paddedSize.X, paddedSize.Y, 4, 4, new SKPaint
                        {
                            Color = DarkGray800,
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

    public override void DrawControl(SKCanvas canvas, ControlType control, StyleState state, Widget widget)
    {
        switch (control)
        {
            case ControlType.Button:
                DrawPrimitive(
                    canvas,
                    PrimitiveType.Button,
                    state,
                    widget
                );

                var widgetButton = (Button)widget;

                var font = DefaultTypeface.ToFont(14.0f);
                canvas.DrawText(widgetButton?.Text,
                    widget.Size.X / 2, (widget.Size.Y / 2) + ((font.Metrics.CapHeight - font.Metrics.Descent) / 2), font,
                    new SKPaint
                    {
                        Color = UIKitApplication.Style.GetStyleColor(StyleColor.Text),
                        TextAlign = SKTextAlign.Center,
                        IsStroke = false,
                        IsAntialias = true
                    }
                );
                
                break;
        }
    }
}
