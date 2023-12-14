public class SkinsStrategy : IBuyable
{
    private TicketAccount _ticketAccount;
    private int _tick;

    public SkinsStrategy(TicketAccount ticketAccount, int price)
    {
        _ticketAccount = ticketAccount;
        _tick = price;
    }

    public void Byu()
    {
        _ticketAccount.ChangeTickets(-_tick);
    }
}