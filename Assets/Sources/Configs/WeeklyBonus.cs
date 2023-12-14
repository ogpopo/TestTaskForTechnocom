using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weekly Bonus Data")]
public class WeeklyBonus : ScriptableObject
{
    [field: SerializeField]
    public List<WeeklyBonusData> WeeklyBonusPerDays { get; private set; } = new List<WeeklyBonusData>();
}

[Serializable]
public class WeeklyBonusData
{
    public int Day;
    public int RewardValue;
}