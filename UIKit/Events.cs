using Silk.NET.SDL;

namespace UIKit;

public struct MbEventData
{
    public const int LeftButton = 1;
    public const int MiddleButton = 2;
    public const int RightButton = 3;
    
    public int Button;
    public int X, Y;
    public bool Pressed;
}

public struct MmEventData
{
    public int X, Y;
    public int Dx, Dy;
}

public struct KbEventData
{
    public bool Pressed;
    public KeyCode Key;
    public bool Repeat;
}
