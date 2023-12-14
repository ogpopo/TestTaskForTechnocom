using System;

[Serializable]
public enum RewardState
{
    Close,
    Open,
    Collect
}

public class Reward : IModel
{
    public event Action<Reward> RewardStateChanged;

    public Reward(WeeklyBonusData data, RewardState state)
    {
        RewardData = data;
        InitState(state);
    }

    public WeeklyBonusData RewardData { get; }

    public RewardState RewardState { get; private set; } = RewardState.Close;

    public void InitState(RewardState state)
    {
        RewardState = state;
        RewardStateChanged?.Invoke(this);
    }

    public void TryCollect()
    {
        if (RewardState != RewardState.Open)
            return;

        RewardState = RewardState.Collect;
        RewardStateChanged?.Invoke(this);
    }
}