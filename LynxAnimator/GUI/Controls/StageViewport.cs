using Silk.NET.Maths;
using UIKit.Controls;

namespace LynxAnimator.GUI.Controls;

public class StageViewport : Widget, IFocusable
{
    public bool IsFocused { get; set; }

    private Vector2D<int> m_StageSize = new(320, 200);
    private float m_CameraZoom = 1.0f;
    
    public StageViewport(Widget? parent) : base(parent)
    {
    }

    protected override void OnPaintEvent()
    {
        using var canvas = Surface.Canvas;
        
        // create a new surface for the canvas
    }
}
