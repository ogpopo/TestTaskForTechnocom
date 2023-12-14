using UnityEngine;
using Zenject;

public class MusicInstaller : MonoInstaller
{
    private SaveData _saveData;

    [SerializeField] private AudioClip _musicClip;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private MusicView _musicView;

    [Inject]
    public void Construct(SaveData data)
    {
        _saveData = data;
    }

    public override void InstallBindings()
    {
        var model = new MusicController(_musicSource, _saveData);
        var presenter = new MusicPresenter(model, _musicView);
        
        model.InitMusic(_musicClip);
    }
}