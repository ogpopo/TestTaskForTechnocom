using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardView : MonoBehaviour, IView
{
    [SerializeField] private TextMeshProUGUI _dayText;
    [SerializeField] private TextMeshProUGUI _rewardText;

    [SerializeField] private Plate _collectedPlate;

    [field: SerializeField] public Button CollectButton { get; private set; }

    public void Init(WeeklyBonusData data)
    {
        _dayText.text = data.Day.ToString();
        _rewardText.text = data.RewardValue.ToString();
    }

    public void OnOpen(Reward reward)
    {
    }

    public void OnCollect(Reward reward)
    {
        _collectedPlate.gameObject.SetActive(true);
        _collectedPlate.transform.DOScale(Vector3.one, .2f);
    }
}