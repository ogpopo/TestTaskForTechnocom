using System;

public class RewardPresenter : PresenterBase<Reward, RewardView>, IDisposable
{
    public RewardPresenter(Reward model, RewardView view) : base(model, view)
    {
        View.CollectButton.onClick.AddListener(Model.TryCollect);
        Model.RewardStateChanged += ModelOnRewardStateChanged;
    }

    public void Dispose()
    {
        View.CollectButton.onClick.RemoveListener(Model.TryCollect);
        Model.RewardStateChanged -= ModelOnRewardStateChanged;
    }

    private void ModelOnRewardStateChanged(Reward reward)
    {
        if (reward.RewardState == RewardState.Open)
            View.OnOpen(reward);
        else if (reward.RewardState == RewardState.Collect)
            View.OnCollect(reward);
    }
}