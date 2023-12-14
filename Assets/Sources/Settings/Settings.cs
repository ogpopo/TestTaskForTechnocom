using System;

public class Settings : IModel, IPopup
{
    private SaveData _saveData;

    public event Action Opened;
    public event Action Closed;

    public Settings(SaveData data)
    {
        _saveData = data;
    }

    public void Open()
    {
        Opened?.Invoke();
    }

    public void Close()
    {
        Closed?.Invoke();
    }

    public void OnMusicToggle(bool on)
    {
        _saveData.PlayingMusic.Value = on;
    }

    public void OnUISoundToggle(bool on)
    {
        _saveData.PlayingUISound.Value = on;
    }
}