using System;

public class UISoundPresenter : PresenterBase<UISoundController, UISoundView>, IDisposable
{
    public UISoundPresenter(UISoundController model, UISoundView view) : base(model, view)
    {
        View.ButtonClicked += Model.TryPlayButtonSound;
    }

    public void Dispose()
    {
        View.ButtonClicked -= Model.TryPlayButtonSound;
    }
}