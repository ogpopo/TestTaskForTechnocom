using System;

public class LevelPresenter : PresenterBase<Level, LevelView>, IDisposable
{
    public LevelPresenter(Level model, LevelView view) : base(model, view)
    {
        View.CompleteButton.onClick.AddListener(Model.TryComplete);
        Model.LevelStateChanged += ModelOnRewardStateChanged;
    }

    public void Dispose()
    {
        View.CompleteButton.onClick.RemoveListener(Model.TryComplete);
        Model.LevelStateChanged -= ModelOnRewardStateChanged;
    }

    private void ModelOnRewardStateChanged(Level level)
    {
        if (level.LevelState == LevelState.Open)
            View.OnOpen(level);
        else if (level.LevelState == LevelState.Complete)
            View.OnComplete(level);
    }
}