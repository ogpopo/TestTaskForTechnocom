using System;

public class ShopPresenter : PresenterBase<Shop, ShopView>, IDisposable
{
    public ShopPresenter(Shop model, ShopView view) : base(model, view)
    {
        Model.Opened += View.OnOpen;
        Model.Closed += View.OnClose;

        View.ClickOnCloseButton.onClick.AddListener(Model.Close);
    }

    public void Dispose()
    {
        Model.Opened -= View.OnOpen;
        Model.Closed -= View.OnClose;

        View.ClickOnCloseButton.onClick.RemoveListener(Model.Close);
    }
}