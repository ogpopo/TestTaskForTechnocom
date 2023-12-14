using System;
using System.Collections.Generic;
using System.Linq;

public class DailyRewarder : IModel, IPopup, IDisposable
{
    private SaveData _saveData;

    private List<Reward> _rewards;
    private TicketAccount _ticketAccount;

    public event Action Opened;
    public event Action Closed;

    public event Action<float> RewardStatusUpdated;
    public event Action<Reward> RewardClamped;

    public DailyRewarder(IEnumerable<Reward> rewards, TicketAccount account, SaveData saveData)
    {
        _saveData = saveData;

        _rewards = rewards.ToList();
        _ticketAccount = account;

        foreach (var reward in _rewards)
        {
            reward.RewardStateChanged += _ =>
            {
                if (_.RewardState == RewardState.Collect)
                    OnRewardCollect(_);
            };
        }

        TimeSpan timePassed = DateTime.Now - _saveData.DailyRewardData.LastUpdateReward;
        int dayPassed = (int) timePassed.TotalDays;

        if (dayPassed == 1)
        {
            _saveData.DailyRewardData.PlayerStreak++;
            _saveData.DailyRewardData.RewardStatePerDaysDictionary[_saveData.DailyRewardData.PlayerStreak] =
                RewardState.Open;
            if (_saveData.DailyRewardData.PlayerStreak > _rewards.Count)
                ResetRewardData();
        }
        else if (dayPassed > 1)
        {
            ResetRewardData();
        }

        foreach (var reward in _rewards)
        {
            reward.InitState(_saveData.DailyRewardData.RewardStatePerDaysDictionary[reward.RewardData.Day]);
        }
    }

    public void ResetRewardData()
    {
        _saveData.DailyRewardData.PlayerStreak = 0;
        _saveData.DailyRewardData.RewardStatePerDaysDictionary = new Dictionary<int, RewardState>()
        {
            {1, RewardState.Open},
            {2, RewardState.Close},
            {3, RewardState.Close},
            {4, RewardState.Close},
            {5, RewardState.Close},
            {6, RewardState.Close}
        };
    }

    public void Open()
    {
        Opened?.Invoke();
    }

    public void Close()
    {
        Closed?.Invoke();
    }

    private void OnRewardCollect(Reward reward)
    {
        _ticketAccount.ChangeTickets(reward.RewardData.RewardValue);
        UpdateProgress();

        _saveData.DailyRewardData.RewardStatePerDaysDictionary[reward.RewardData.Day] = RewardState.Collect;

        RewardClamped?.Invoke(reward);
    }

    public void UpdateProgress()
    {
        RewardStatusUpdated?.Invoke((float) _rewards.Where(x => x.RewardState == RewardState.Collect).ToList().Count /
                                    _rewards.Count);
    }

    public void Dispose()
    {
        foreach (var reward in _rewards)
        {
            reward.RewardStateChanged += _ =>
            {
                if (_.RewardState == RewardState.Collect)
                    OnRewardCollect(_);
            };
        }
    }
}