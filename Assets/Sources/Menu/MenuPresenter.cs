using System;

public class MenuPresenter : PresenterBase<Menu, MenuView>, IDisposable
{
    public MenuPresenter(Menu model, MenuView view) : base(model, view)
    {
        View.ClickOnSettings += Model.GoToSettings;
        View.ClickOnDaily += Model.GoToDaily;
        View.ClickOnShop += Model.GoToShop;
        View.ClickOnPlay += Model.GoToLevels;
    }

    public void Dispose()
    {
        View.ClickOnSettings -= Model.GoToSettings;
        View.ClickOnDaily -= Model.GoToDaily;
        View.ClickOnShop -= Model.GoToShop;
        View.ClickOnPlay -= Model.GoToLevels;
    }
}