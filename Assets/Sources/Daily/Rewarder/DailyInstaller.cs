using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DailyInstaller : MonoInstaller
{
    private RewardsFactory _factory;

    [SerializeField] private DailyView _dailyView;

    [SerializeField] private WeeklyBonus _config;
    [SerializeField] private RewardView _rewardViewTemplate;
    [SerializeField] private GridLayoutGroup _rewardsHolder;

    private SaveData _saveData;

    [Inject]
    public void Construct(SaveData saveData)
    {
        _saveData = saveData;
    }

    public override void InstallBindings()
    {
        _factory = new RewardsFactory(_config, _saveData.DailyRewardData);
        List<Reward> rewards = _factory.Create().ToList();

        foreach (var reward in rewards)
        {
            RewardView view = Container.InstantiatePrefabForComponent<RewardView>(_rewardViewTemplate, Vector3.one,
                Quaternion.identity, _rewardsHolder.transform);
            view.transform.localScale = Vector3.one;
            view.Init(reward.RewardData);

            var rewardPresenter = new RewardPresenter(reward, view);
        }

        Container.Bind<IEnumerable<Reward>>().To<List<Reward>>().FromInstance(rewards);
        Container.Bind<DailyRewarder>().AsSingle().NonLazy();
        Container.Bind<DailyView>().FromInstance(_dailyView).AsSingle().NonLazy();
        Container.Bind<DailyPresenter>().AsSingle().NonLazy();
    }
}