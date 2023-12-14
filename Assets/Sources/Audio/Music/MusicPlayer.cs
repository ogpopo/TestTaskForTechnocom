using DG.Tweening;
using UnityEngine;

public class MusicPlayer : ISoundPlayer
{
    public MusicPlayer(AudioSource source)
    {
        SoundSource = source;
        Volume = SoundSource.volume;
    }

    public AudioSource SoundSource { get; }
    public float Volume { get; private set; }

    public void PlaySound(AudioClip sound)
    {
        SoundSource.volume = 0;
        SoundSource.PlayOneShot(sound);
        SoundSource.DOFade(Volume, .5f);
    }

    public void ChangeVolume(float volume)
    {
        Volume = volume;
        SoundSource.DOFade(Volume, .3f);
    }
}