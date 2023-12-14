using System;
using System.Collections.Generic;
using System.Linq;

public class LevelSelector : IModel, IPopup
{
    private SaveData _saveData;

    private List<Level> _levels;

    public event Action Opened;
    public event Action Closed;

    public LevelSelector(IEnumerable<Level> levels, SaveData saveData)
    {
        _saveData = saveData;
        _levels = levels.ToList();

        for (var i = 0; i < _levels.Count; i++)
        {
            var i1 = i;
            _levels[i].LevelStateChanged += _ =>
            {
                if (_.LevelState == LevelState.Complete)
                {
                    var nextLevel = i1 + 1;
                    _levels[nextLevel].TryOpen();
                }

                _saveData.LevelStateDictionary[_levels[i1].LevelNumber] = _levels[i1].LevelState;
            };
        }

        foreach (var level in _levels)
            level.InitState(_saveData.LevelStateDictionary[level.LevelNumber]);
    }

    private void OnLevelComplete()
    {
    }

    public void Open()
    {
        Opened?.Invoke();
    }

    public void Close()
    {
        Closed?.Invoke();
    }
}