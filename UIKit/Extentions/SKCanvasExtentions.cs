using SkiaSharp;

namespace UIKit.Extentions;

public static class SKCanvasExtentions
{
    /// <summary>
    /// Draws text with line break support
    /// </summary>
    /// <param name="canvas"></param>
    /// <param name="text">String to print</param>
    /// <param name="x">X Position</param>
    /// <param name="y">Y Position</param>
    /// <param name="font">Text Fontface</param>
    /// <param name="paint">Painter</param>
    public static void DrawTextExt(this SKCanvas canvas, string text, float x, float y, SKFont font, SKPaint paint)
    {
        using var strReader = new StringReader(text);
        
        var yOff = 0.0f;
        var lineHeight = font.Metrics.Ascent - font.Metrics.Descent;
        string line = strReader.ReadLine();
        while (line != null)
        {
            canvas.DrawText(line, x, y + yOff, font, paint);
            
            yOff -= lineHeight;
            line = strReader.ReadLine();
        }
    }

    /// <summary>
    /// Draws a SVG graphic to the screen at the given position and size
    /// </summary>
    /// <param name="canvas"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="w"></param>
    /// <param name="h"></param>
    /// <param name="paint"></param>
    public static void DrawSvg(this SKCanvas canvas, float x, float y, float w, float h, SKPaint paint)
    {
        
    }
}
