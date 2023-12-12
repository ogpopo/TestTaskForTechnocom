using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    private TicketAccount _ticketAccount;
    private SaveData _saveData;

    [SerializeField] private ShopView _shopView;

    [SerializeField] private TicketsProductView _ticketsProductViewTemplate;
    [SerializeField] private SkinsProductView _skinsProductViewTemplate;
    [SerializeField] private ProductView _locationProductViewTemplate;

    [SerializeField] private List<ProductConfig> _productConfigs;

    [Inject]
    public void Construct(TicketAccount ticketAccount, SaveData saveData)
    {
        _ticketAccount = ticketAccount;
        _saveData = saveData;
    }

    public override void InstallBindings()
    {
        var products = new List<Product>();

        var index = 0;

        foreach (var productConfig in _productConfigs)
        {
            if (productConfig.ProductType == ProductType.Chest)
            {
                Product productsModel = TicketsInit((TicketsChestConfig) productConfig, index);
                var view = Container.InstantiatePrefabForComponent<TicketsProductView>(_ticketsProductViewTemplate,
                    Vector3.zero,
                    Quaternion.identity, _shopView.HolderForTickets);
                view.Init((TicketsChestConfig) productConfig);
                view.SetActiveLevelText(productsModel.LevelForPurchase > _saveData.PlayerLevel);
                var productPresenter = new ProductPresenter(productsModel, view);

                products.Add(productsModel);
            }
            else if (productConfig.ProductType == ProductType.Skins)
            {
                Product productsModel = SkinsInit((SkinsProductConfig) productConfig, index);
                var view = Container.InstantiatePrefabForComponent<SkinsProductView>(_skinsProductViewTemplate,
                    Vector3.zero,
                    Quaternion.identity, _shopView.HolderForSkins);
                view.Init((SkinsProductConfig) productConfig);
                view.SetActiveLevelText(productsModel.LevelForPurchase > _saveData.PlayerLevel);
                var productPresenter = new ProductPresenter(productsModel, view);

                products.Add(productsModel);
            }
            else if (productConfig.ProductType == ProductType.Locations)
            {
                Product productsModel = SkinsInit((SkinsProductConfig) productConfig, index);
                var view = Container.InstantiatePrefabForComponent<SkinsProductView>(_skinsProductViewTemplate,
                    Vector3.zero,
                    Quaternion.identity, _shopView.HolderForLocation);
                view.Init((SkinsProductConfig) productConfig);
                view.SetActiveLevelText(productsModel.LevelForPurchase > _saveData.PlayerLevel);
                var productPresenter = new ProductPresenter(productsModel, view);

                products.Add(productsModel);
            }

            index++;
        }

        var model = new Shop(products, _saveData);

        var presenter = new ShopPresenter(model, _shopView);
        Container.Bind<Shop>().FromInstance(model);
    }

    private Product TicketsInit(TicketsChestConfig config, int id)
    {
        var product = new Product(new TicketsStrategy(_ticketAccount, config), config.PurchaseLevel, id);
        return product;
    }

    private Product SkinsInit(SkinsProductConfig config, int id)
    {
        var product = new Product(new SkinsStrategy(_ticketAccount, config), config.PurchaseLevel, id);
        return product;
    }
}