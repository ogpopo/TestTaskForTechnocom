using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingsView : MonoBehaviour, IView
{
    [field: SerializeField] public Toggle MusicToggle { get; private set; }
    [field: SerializeField] public Toggle SoundToggle { get; private set; }

    [SerializeField] private Button _closeButton;

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
}