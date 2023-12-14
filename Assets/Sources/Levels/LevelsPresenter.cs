using System;

public class LevelsPresenter : PresenterBase<LevelSelector, LevelsView>, IDisposable
{
    public LevelsPresenter(LevelSelector model, LevelsView view) : base(model, view)
    {
        Model.Opened += View.OnOpen;
        Model.Closed += View.OnClose;

        View.CloseButton.onClick.AddListener(Model.Close);
    }

    public void Dispose()
    {
        Model.Opened -= View.OnOpen;
        Model.Closed -= View.OnClose;

        View.CloseButton.onClick.AddListener(Model.Close);
    }
}