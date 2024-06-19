using System.Numerics;
using SkiaSharp;
using UIKit.Styles;

namespace UIKit.Controls;

public class Button : Widget
{
    public enum ButtonState
    {
        Normal,
        Hovered,
        Pressed
    }
    
    public string Text = "";
    public ButtonState State = ButtonState.Normal;
    public EventHandler? OnPressed;

    public Button(Widget? parent) : base(parent)
    {
    }

    public Button(Widget? parent, string text) : base(parent)
    {
        Text = text;
    }
    
    protected override bool OnMouseButtonEvent(MbEventData data)
    {
        switch (data)
        {
            case { Button: MbEventData.LeftButton, Pressed: true }:
                State = ButtonState.Pressed;
                return true;
            case { Button: MbEventData.LeftButton, Pressed: false }:
                if (State == ButtonState.Pressed)
                    OnPressed?.Invoke(this, EventArgs.Empty);
                State = IsHovered ? ButtonState.Hovered : ButtonState.Normal;
                return true;
        }

        return false;
    }

    protected override void OnMouseEnterEvent()
    {
        IsHovered = true;
    }
    
    protected override void OnMouseExitEvent()
    {
        IsHovered = false;
    }
    
    protected override void OnUpdateEvent()
    {
        State = IsHovered switch
        {
            // keep the value if we fail this check, retains the pressed state
            true when State != ButtonState.Pressed => ButtonState.Hovered,
            false when State != ButtonState.Pressed => ButtonState.Normal,
            _ => State
        };
    }

    protected override void OnPaintEvent()
    {
        using var canvas = Surface.Canvas;

        // rider why are you asking me to add default, I have a case for every value in ButtonState?
        switch (State)
        {
            case ButtonState.Normal:
                UIKitApplication.Style.DrawControl(
                    canvas,
                    UIKitStyle.ControlType.Button,
                    UIKitStyle.StyleState.Normal,
                    this
                );
                break;
            case ButtonState.Pressed:
                UIKitApplication.Style.DrawControl(
                    canvas,
                    UIKitStyle.ControlType.Button,
                    UIKitStyle.StyleState.Pressed,
                    this
                );
                break;
            case ButtonState.Hovered:
                UIKitApplication.Style.DrawControl(
                    canvas,
                    UIKitStyle.ControlType.Button,
                    UIKitStyle.StyleState.Hovered,
                    this
                );
                break;
        }
    }
}
