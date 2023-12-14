using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UISoundView : MonoBehaviour, IView
{
    private List<SoundButton> _soundButtons;

    [SerializeField] private AudioClip _buttonClickSound;

    public event Action<SoundButton, AudioClip> ButtonClicked;

    private void Awake()
    {
        _soundButtons = FindObjectsOfType<SoundButton>().ToList();

        foreach (var button in _soundButtons)
            button.onClick.AddListener(() => ButtonClicked?.Invoke(button, _buttonClickSound));
    }

    private void OnDestroy()
    {
        foreach (var button in _soundButtons)
            button.onClick.AddListener(() => ButtonClicked?.Invoke(button, _buttonClickSound));
    }
}