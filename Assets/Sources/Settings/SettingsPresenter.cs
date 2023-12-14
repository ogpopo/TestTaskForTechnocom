using System;

public class SettingsPresenter : PresenterBase<Settings, SettingsView>, IDisposable
{
    public SettingsPresenter(Settings model, SettingsView view) : base(model, view)
    {
        Model.Opened += View.OnOpen;
        Model.Closed += View.OnClose;

        View.ClickOnCloseButton += Model.Close;
        View.MusicToggle.onValueChanged.AddListener(Model.OnMusicToggle);
        View.SoundToggle.onValueChanged.AddListener(Model.OnUISoundToggle);
    }

    public void Dispose()
    {
        Model.Opened -= View.OnOpen;
        Model.Closed -= View.OnClose;

        View.ClickOnCloseButton -= Model.Close;
        View.MusicToggle.onValueChanged.RemoveListener(Model.OnMusicToggle);
        View.SoundToggle.onValueChanged.RemoveListener(Model.OnUISoundToggle);
    }
}