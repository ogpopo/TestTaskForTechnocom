using System;
using UniRx;
using UnityEngine;

public class MusicController : IModel, IDisposable
{
    private float _maxVolume;

    private ISoundPlayer _soundPlayer;

    private SaveData _saveData;

    private readonly CompositeDisposable _disposable = new CompositeDisposable();

    public MusicController(AudioSource source, SaveData saveData)
    {
        _soundPlayer = new MusicPlayer(source);
        _saveData = saveData;

        _maxVolume = source.volume;

        _saveData.PlayingMusic.Subscribe(Toggling).AddTo(_disposable);
    }

    public void InitMusic(AudioClip sound)
    {
        if (_saveData.PlayingMusic.Value)
            _soundPlayer.ChangeVolume(_maxVolume);

        _soundPlayer.PlaySound(sound);
    }

    private void Toggling(bool on)
    {
        if (on)
            OnMusic();
        else
            OffMusic();
    }

    private void OnMusic()
    {
        _soundPlayer.ChangeVolume(_maxVolume);
        _saveData.PlayingMusic.Value = true;
    }

    private void OffMusic()
    {
        _soundPlayer.ChangeVolume(0);
        _saveData.PlayingMusic.Value = false;
    }

    public void Dispose()
    {
        _disposable?.Clear();
    }
}