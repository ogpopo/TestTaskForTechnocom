using System;
using UnityEngine;
using Zenject;

public class SettingInstaller : MonoInstaller
{
    [SerializeField] private SettingsView _settingsView;

    private SaveData _data;

    [Inject]
    public void Construct(SaveData data)
    {
        _data = data;
    }

    public override void InstallBindings()
    {
        var model = new Settings(_data);
        var presenter = new SettingsPresenter(model, _settingsView);

        _settingsView.MusicToggle.isOn = _data.PlayingMusic.Value;
        _settingsView.SoundToggle.isOn = _data.PlayingUISound.Value;

        Container.Bind<Settings>().FromInstance(model).AsSingle();
        Container.Bind(typeof(IDisposable)).To<SettingsPresenter>().FromInstance(presenter);
    }
}