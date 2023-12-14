using System;

[Serializable]
public enum LevelState
{
    Close,
    Open,
    Complete
}

public class Level : IModel
{
    public event Action<Level> LevelStateChanged;

    public Level(int levelNumber, LevelState state)
    {
        LevelNumber = levelNumber;
        InitState(state);
    }

    public int LevelNumber { get; }

    public LevelState LevelState { get; private set; } = LevelState.Close;

    public void InitState(LevelState state)
    {
        LevelState = state;
        LevelStateChanged?.Invoke(this);
    }

    public void TryOpen()
    {
        if (LevelState != LevelState.Close)
            return;

        InitState(LevelState.Open);
    }

    public void TryComplete()
    {
        if (LevelState != LevelState.Open)
            return;

        InitState(LevelState.Complete);
    }
}