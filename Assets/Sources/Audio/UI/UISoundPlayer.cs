using UnityEngine;

public class UISoundPlayer : ISoundPlayer
{
    public UISoundPlayer(AudioSource source)
    {
        SoundSource = source;
        Volume = SoundSource.volume;
    }

    public AudioSource SoundSource { get; }
    public float Volume { get; private set; }

    public void PlaySound(AudioClip sound)
    {
        SoundSource.PlayOneShot(sound);
    }

    public void ChangeVolume(float volume)
    {
        Volume = volume;
        SoundSource.volume = volume;
    }
}