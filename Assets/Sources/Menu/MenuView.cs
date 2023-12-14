using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour, IView
{
    [SerializeField] private Button _settingButton;
    [SerializeField] private Button _dailyButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _levelsButton;

    public event Action ClickOnSettings;
    public event Action ClickOnDaily;
    public event Action ClickOnShop;
    public event Action ClickOnPlay;

    private void Awake()
    {
        _settingButton.onClick.AddListener(() => ClickOnSettings?.Invoke());
        _dailyButton.onClick.AddListener(() => ClickOnDaily?.Invoke());
        _shopButton.onClick.AddListener(() => ClickOnShop?.Invoke());
        _levelsButton.onClick.AddListener(() => ClickOnPlay?.Invoke());
    }

    private void OnDestroy()
    {
        _settingButton.onClick.RemoveListener(() => ClickOnSettings?.Invoke());
        _dailyButton.onClick.RemoveListener(() => ClickOnDaily?.Invoke());
        _shopButton.onClick.RemoveListener(() => ClickOnShop?.Invoke());
        _levelsButton.onClick.RemoveListener(() => ClickOnPlay?.Invoke());
    }
}