using System;

public class TicketsStrategy : IBuyable
{
    private TicketAccount _ticketAccount;

    private int _ticketsPerPurchase;
    private float _price;

    public event Action<TicketsStrategy> TryingToBuy;
    public event Action Purchased;

    public TicketsStrategy(TicketAccount ticketAccount, TicketsChestConfig config)
    {
        _ticketAccount = ticketAccount;
        _ticketsPerPurchase = config.TicketsPerPurchase;
        _price = config.PriceInDollars;
        IDForPurchase = config.IDForPurchase;
    }

    public string IDForPurchase { get; }

    public void Byu()
    {
        TryingToBuy?.Invoke(this);
    }

    public void ConfirmedPurchase()
    {
        _ticketAccount.ChangeTickets(_ticketsPerPurchase);
        Purchased?.Invoke();
    }
}