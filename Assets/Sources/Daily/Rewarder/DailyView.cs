using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DailyView : MonoBehaviour, IView
{
    [SerializeField] private Button _closeButton;

    [SerializeField] private Slider _progressBar;

    [SerializeField] private CollectScreen _collectScreen;

    public event Action ClickOnCloseButton;

    private void Awake()
    {
        _closeButton.onClick.AddListener(() => ClickOnCloseButton?.Invoke());
    }

    private void OnDestroy()
    {
        _closeButton.onClick.RemoveListener(() => ClickOnCloseButton?.Invoke());
    }

    public void OnOpen()
    {
        transform.DOScale(Vector3.one, .1f);
    }

    public void OnClose()
    {
        transform.DOScale(Vector3.zero, .1f).OnComplete(() => gameObject.SetActive(true));
    }

    public void OnClamped(Reward reward)
    {
        _collectScreen.Open();
        _collectScreen.Init(reward.RewardData);
    }

    public void OnProgress(float progressValue)
    {
        _progressBar.DOValue(progressValue, .3f);
    }
}