using UnityEngine;

public interface ISoundPlayer
{
    public AudioSource SoundSource { get; }

    public float Volume { get; }

    public void PlaySound(AudioClip sound);
    public void ChangeVolume(float volume);
}