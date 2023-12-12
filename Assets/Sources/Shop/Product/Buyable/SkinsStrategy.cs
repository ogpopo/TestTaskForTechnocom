using System;

public class SkinsStrategy : IBuyable
{
    private TicketAccount _ticketAccount;
    private int _tick;

    public SkinsStrategy(TicketAccount ticketAccount, SkinsProductConfig config)
    {
        _ticketAccount = ticketAccount;
        _tick = config.PriceInTickets;
    }

    public event Action Purchased;

    public void Byu()
    {
        _ticketAccount.ChangeTickets(-_tick);
        Purchased?.Invoke();
    }
}