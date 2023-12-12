public class Menu : IModel
{
    private MainMenuSwitcher _switcher;

    public Menu(MainMenuSwitcher switcher)
    {
        _switcher = switcher;
    }

    public void GoToSettings()
    {
        _switcher.SwitchTo(typeof(Settings));
    }

    public void GoToDaily()
    {
        _switcher.SwitchTo(typeof(DailyRewarder));
    }

    public void GoToShop()
    {
        _switcher.SwitchTo(typeof(Shop));
    }

    public void GoToLevels()
    {
        _switcher.SwitchTo(typeof(LevelSelector));
    }
}