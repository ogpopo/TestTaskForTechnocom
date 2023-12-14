using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    private TicketAccount _ticketAccount;

    [SerializeField] private ShopView _shopView;

    [SerializeField] private ProductView _ticketsProductView;
    [SerializeField] private ProductView _skinsProductView;
    [SerializeField] private ProductView _locationProductView;

    [Inject]
    public void Construct(TicketAccount ticketAccount)
    {
        _ticketAccount = ticketAccount;
    }

    public override void InstallBindings()
    {
        // var products = new List<Product>();
        //
        // for (var i = 0; i < 2; i++)
        // {
        //     Product ticketsProductModel;
        //
        //     if (i == 1)
        //     {
        //         ticketsProductModel = new Product(new TicketsStrategy(_ticketAccount, 500), 1, 1);
        //     }
        //     else
        //     {
        //         ticketsProductModel = new Product(new TicketsStrategy(_ticketAccount, 1200), 1, 2);
        //     }
        //
        //     products.Add(ticketsProductModel);
        //
        //     var view = Container.InstantiatePrefabForComponent<ProductView>(_ticketsProductView, Vector3.zero,
        //         Quaternion.identity, _shopView.HolderForTickets);
        //
        //     var ticketsProductPresenter = new ProductPresenter(ticketsProductModel, view);
        // }
        //
        // for (var i = 0; i < 2; i++)
        // {
        //     Product skinsProductModel;
        //
        //     if (i == 1)
        //     {
        //         skinsProductModel = new Product(new SkinsStrategy(_ticketAccount, 5), 1, 3);
        //     }
        //     else
        //     {
        //         skinsProductModel = new Product(new SkinsStrategy(_ticketAccount, 500), 1, 4);
        //     }
        //
        //     products.Add(skinsProductModel);
        //
        //     var view = Container.InstantiatePrefabForComponent<ProductView>(_ticketAccount, Vector3.zero,
        //         Quaternion.identity, _shopView.HolderForTickets);
        //
        //     var ticketsProductPresenter = new ProductPresenter(skinsProductModel, view);
        // }
        
        var model = new Shop();

        var presenter = new ShopPresenter(model, _shopView);
        Container.Bind<Shop>().FromInstance(model);
    }
}