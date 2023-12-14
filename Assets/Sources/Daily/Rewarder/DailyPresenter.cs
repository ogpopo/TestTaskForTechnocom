using System;

public class DailyPresenter : PresenterBase<DailyRewarder, DailyView>, IDisposable
{
    public DailyPresenter(DailyRewarder model, DailyView view) : base(model, view)
    {
        Model.Opened += View.OnOpen;
        Model.Closed += View.OnClose;
        View.ClickOnCloseButton += Model.Close;

        Model.RewardClamped += View.OnClamped;

        Model.RewardStatusUpdated += View.OnProgress;

        Model.UpdateProgress();
    }

    public void Dispose()
    {
        Model.Opened -= View.OnOpen;
        Model.Closed -= View.OnClose;
        View.ClickOnCloseButton -= Model.Close;

        Model.RewardStatusUpdated -= View.OnProgress;
    }
}