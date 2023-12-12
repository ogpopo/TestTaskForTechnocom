using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

[Serializable]
public class SaveData
{
    public int Tickets = 0;

    public BoolReactiveProperty PlayingMusic = new BoolReactiveProperty(true);
    public BoolReactiveProperty PlayingUISound = new BoolReactiveProperty(true);

    public Dictionary<int, LevelState> LevelStateDictionary = new Dictionary<int, LevelState>()
    {
        {1, LevelState.Open},
        {2, LevelState.Close},
        {3, LevelState.Close},
        {4, LevelState.Close},
        {5, LevelState.Close},
        {6, LevelState.Close},
        {7, LevelState.Close},
        {8, LevelState.Close},
        {9, LevelState.Close},
        {10, LevelState.Close},
        {11, LevelState.Close},
        {12, LevelState.Close},
        {13, LevelState.Close},
        {14, LevelState.Close},
        {15, LevelState.Close},
        {16, LevelState.Close},
        {17, LevelState.Close},
        {18, LevelState.Close},
        {19, LevelState.Close},
        {20, LevelState.Close},
    };

    public DailyRewardData DailyRewardData = new DailyRewardData();

    public int PlayerLevel => LevelStateDictionary.Where(x => x.Value == LevelState.Open).ToList().Count;
}

[Serializable]
public class DailyRewardData
{
    public int PlayerStreak = 1;
    public DateTime LastUpdateReward = DateTime.Now;

    public Dictionary<int, RewardState> RewardStatePerDaysDictionary = new Dictionary<int, RewardState>()
    {
        {1, RewardState.Open},
        {2, RewardState.Close},
        {3, RewardState.Close},
        {4, RewardState.Close},
        {5, RewardState.Close},
        {6, RewardState.Close}
    };
}