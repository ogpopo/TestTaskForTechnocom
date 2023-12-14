using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CollectScreen : MonoBehaviour, IPopup
{
    [SerializeField] private TextMeshProUGUI _dayText;
    [SerializeField] private TextMeshProUGUI _rewardText;

    public event Action Opened;
    public event Action Closed;

    public void Open()
    {
        gameObject.SetActive(true);
        transform.DOScale(Vector3.one, .15f).OnComplete(() => Opened?.Invoke());
    }

    public void Close()
    {
        transform.DOScale(Vector3.one, .15f).OnComplete(() =>
        {
            gameObject.SetActive(false);
            Closed?.Invoke();
        });
    }

    public void Init(WeeklyBonusData data)
    {
        _dayText.text = data.Day.ToString();
        _rewardText.text = data.RewardValue.ToString();
    }
}