using System.Collections.Generic;

public class RewardsFactory
{
    private WeeklyBonus _config;
    private DailyRewardData _rewardData;

    public RewardsFactory(WeeklyBonus config, DailyRewardData dailyRewardData)
    {
        _config = config;
        _rewardData = dailyRewardData;
    }

    public IEnumerable<Reward> Create()
    {
        var rewards = new List<Reward>();

        foreach (var dayData in _config.WeeklyBonusPerDays)
        {
            rewards.Add(new Reward(dayData, _rewardData.RewardStatePerDaysDictionary[dayData.Day]));
        }

        return rewards;
    }
}