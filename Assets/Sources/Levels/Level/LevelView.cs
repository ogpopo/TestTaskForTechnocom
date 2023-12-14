using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour, IView
{
    [SerializeField] private TextMeshProUGUI _numberText;

    [SerializeField] private List<LevelPlateData> _plates = new List<LevelPlateData>();

    [field: SerializeField] public Button CompleteButton { get; private set; }

    public void Init(int dayNum)
    {
        _numberText.text = dayNum.ToString();
    }

    public void OnOpen(Level level)
    {
        SetPlate(LevelState.Open);
    }

    public void OnComplete(Level level)
    {
        SetPlate(LevelState.Complete);
    }

    private void SetPlate(LevelState state)
    {
        foreach (var plateData in _plates)
        {
            plateData.Plate.transform.localScale = Vector3.zero;
            plateData.Plate.gameObject.SetActive(false);
        }

        var plate = _plates.FirstOrDefault(x => x.State == state);
        plate.Plate.gameObject.SetActive(true);
        plate.Plate.transform.DOScale(Vector3.one, .1f);
    }
}

[Serializable]
public class LevelPlateData
{
    public LevelState State;
    public Plate Plate;
}