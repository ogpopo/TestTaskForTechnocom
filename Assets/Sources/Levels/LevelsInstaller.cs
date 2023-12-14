using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class LevelsInstaller : MonoInstaller
{
    [SerializeField] private LevelsView _levelsView;

    [SerializeField] private List<LevelView> _levelViews;

    private SaveData _saveData;

    [Inject]
    public void Construct(SaveData saveData)
    {
        _saveData = saveData;
    }

    public override void InstallBindings()
    {
        var factory = new LevelsFactory(_saveData.LevelStateDictionary);
        List<Level> levels = factory.Create(20).ToList();

        var i = 0;

        foreach (var level in levels)
        {
            LevelView view = _levelViews[i];
            view.Init(level.LevelNumber);
            var presenter = new LevelPresenter(level, view);
            i++;
        }

        Container.Bind<IEnumerable<Level>>().To<List<Level>>().FromInstance(levels).AsSingle();
        Container.Bind<LevelSelector>().AsSingle().NonLazy();
        Container.Bind<LevelsView>().FromInstance(_levelsView).AsSingle();
        Container.Bind<LevelsPresenter>().AsSingle().NonLazy();
    }
}