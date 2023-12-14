using UnityEngine;
using Zenject;

public class UISoundInstaller : MonoInstaller
{
    private SaveData _saveData;
    
    [SerializeField] private AudioSource _UISoundSource;
    [SerializeField] private UISoundView _uiSoundView;

    [Inject]
    public void Construct(SaveData data)
    {
        _saveData = data;
    }

    public override void InstallBindings()
    {
        var model = new UISoundController(_UISoundSource, _saveData);
        var presenter = new UISoundPresenter(model, _uiSoundView);
    }
}