using System;

public class TicketAccount : IModel
{
    public event Action<int> ChangedMeans;

    private SaveData _data;

    public TicketAccount(SaveData data)
    {
        _data = data;
    }

    public void Init()
    {
        ChangedMeans?.Invoke(_data.Tickets);
    }
    
    public void ChangeTickets(int changeValue)
    {
        _data.Tickets += changeValue;

        ChangedMeans?.Invoke(_data.Tickets);
    }
}