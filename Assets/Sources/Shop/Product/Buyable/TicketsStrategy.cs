public class TicketsStrategy : IBuyable
{
    private TicketAccount _ticketAccount;

    private int _ticketsPerPurchase;

    public TicketsStrategy(TicketAccount ticketAccount, int ticketsPerPurchase)
    {
        _ticketAccount = ticketAccount;
        _ticketsPerPurchase = ticketsPerPurchase;
    }

    public void Byu()
    {
        _ticketAccount.ChangeTickets(_ticketsPerPurchase);
    }
}