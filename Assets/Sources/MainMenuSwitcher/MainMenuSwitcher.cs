using System;
using System.Collections.Generic;
using System.Linq;

public class MainMenuSwitcher
{
    private List<IPopup> _windows;

    private Stack<IPopup> _history;

    public MainMenuSwitcher(Settings settings, DailyRewarder daily, LevelSelector levelSelector, Shop shop)
    {
        _windows = new List<IPopup> {settings, daily, levelSelector, shop};
    }

    public void SwitchTo(Type type)
    {
        CloseAllWindows();
        OpenWithType(type);
    }

    private void CloseAllWindows()
    {
        foreach (var window in _windows)
            window.Close();
    }

    private void OpenWithType(Type type)
    {
        IPopup window = _windows.FirstOrDefault(x => x.GetType() == type);

        if (window == null)
            return;

        window.Open();
    }
}