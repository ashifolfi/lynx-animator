namespace LibXfl;

public struct SolidSwatchItem
{
    /// <summary>
    /// Hex Code
    /// </summary>
    public byte[] Color;
    public int Hue;
    public int Saturation;
    public int Brightness;
}

public enum GradientType
{
    Linear,
    Radial
}

public struct GradientEntry
{
    /// <summary>
    /// Hex Code
    /// </summary>
    public byte[] Color;
    public float Ratio;
}

public struct GradientSwatchItem
{
    public GradientType Type;
    public List<GradientEntry> Entries;
}
