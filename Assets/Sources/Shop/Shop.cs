using System;

public class Shop : IModel, IPopup
{
    public event Action Opened;
    public event Action Closed;

    public void Open()
    {
        Opened?.Invoke();
    }

    public void Close()
    {
        Closed?.Invoke();
    }
}