using UnityEngine;
using Zenject;

public class TicketAccountInstaller : MonoInstaller
{
    [SerializeField] private TicketAccountView _ticketAccountView;

    private SaveData _saveData;

    [Inject]
    public void Construct(SaveData saveData)
    {
        _saveData = saveData;
    }

    public override void InstallBindings()
    {
        var model = new TicketAccount(_saveData);
        var presenter = new TicketAccountPresenter(model, _ticketAccountView);
        Container.Bind<TicketAccount>().FromInstance(model).AsSingle();
    }
}