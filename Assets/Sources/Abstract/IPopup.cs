using System;

public interface IPopup
{
    public event Action Opened;
    public event Action Closed;

    public void Open();
    public void Close();
}