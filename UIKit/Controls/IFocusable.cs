namespace UIKit.Controls;

public interface IFocusable
{
    public bool IsFocused { get; set; }

    public void Focus()
    {
        IsFocused = true;
        OnFocusEvent();
    }

    public void Unfocus()
    {
        IsFocused = false;
        // todo: defocus event?
    }
    
    protected virtual void OnFocusEvent()
    {
    }
}
