using System;
using UniRx;
using UnityEngine;

public class UISoundController : IModel, IDisposable
{
    private float _maxVolume;

    private ISoundPlayer _soundPlayer;

    private SaveData _saveData;

    private readonly CompositeDisposable _disposable = new CompositeDisposable();

    public UISoundController(AudioSource source, SaveData saveData)
    {
        _soundPlayer = new UISoundPlayer(source);
        _saveData = saveData;

        _maxVolume = source.volume;

        _saveData.PlayingUISound.Subscribe(Toggling).AddTo(_disposable);
    }

    public void TryPlayButtonSound(SoundButton button, AudioClip sound)
    {
        if (_saveData.PlayingUISound.Value == true)
            _soundPlayer.PlaySound(sound);
    }

    private void Toggling(bool on)
    {
        if (on)
            OnSound();
        else
            OffSound();
    }

    private void OnSound()
    {
        _soundPlayer.ChangeVolume(_maxVolume);
        _saveData.PlayingUISound.Value = true;
    }

    private void OffSound()
    {
        _soundPlayer.ChangeVolume(0);
        _saveData.PlayingUISound.Value = false;
    }

    public void Dispose()
    {
        _disposable?.Dispose();
    }
}