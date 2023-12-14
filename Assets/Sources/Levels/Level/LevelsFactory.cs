using System.Collections.Generic;

public class LevelsFactory
{
    private Dictionary<int, LevelState> _levelData;

    public LevelsFactory(Dictionary<int, LevelState> levelsData)
    {
        _levelData = levelsData;
    }

    public IEnumerable<Level> Create(int count)
    {
        var levels = new List<Level>();

        for (var i = 0; i < count; i++)
        {
            var levelNum = i + 1;

            levels.Add(new Level(levelNum, _levelData[levelNum]));
        }

        return levels;
    }
}