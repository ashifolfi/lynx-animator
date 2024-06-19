using UIKit.Styles;

namespace UIKit;

/// <summary>
/// UIKit Application class
///
/// Holds Application wide variables and state, such as styling.
/// </summary>
public static class UIKitApplication
{
    public static UIKitStyle Style;

    public static void Init()
    {
        Style = new UIKSpectrumStyle();
    }

    public static void Run()
    {
        var done = false;
        
        while (!done)
        {
            if (m_Windows.Count == 0)
            {
                done = true;
            }
            
            var windowGone = new bool[m_Windows.Count];
            for (var i = 0; i < m_Windows.Count; i++)
            {
                if (m_Windows[i].TryGetTarget(out var window) && !window.Done)
                {
                    window.Update();
                }
                else
                {
                    windowGone[i] = true;
                }
            }

            for (var i = 0; i < m_Windows.Count; i++)
            {
                if (windowGone[i])
                {
                    if (m_Windows[i].TryGetTarget(out var window))
                    {
                        window.Dispose();
                    }
                    m_Windows.RemoveAt(i);
                }
            }
        }
    }
    
    #region Internal Methods and Members

    private static List<WeakReference<Window>> m_Windows = [];

    internal static void AddWindow(Window window)
    {
        m_Windows.Add(new WeakReference<Window>(window));
    }
    
    #endregion
}
