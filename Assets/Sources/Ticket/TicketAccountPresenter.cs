using System;

public class TicketAccountPresenter : PresenterBase<TicketAccount, TicketAccountView>, IDisposable
{
    public TicketAccountPresenter(TicketAccount model, TicketAccountView view) : base(model, view)
    {
        Model.ChangedMeans += View.OnChangedTicket;
        Model.Init();
    }

    public void Dispose()
    {
        Model.ChangedMeans -= View.OnChangedTicket;
    }
}