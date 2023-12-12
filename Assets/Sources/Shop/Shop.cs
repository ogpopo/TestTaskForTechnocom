using System;
using System.Collections.Generic;
using System.Linq;

public class Shop : IModel, IPopup, IDisposable
{
    private IAPCore _iapCore;

    private SaveData _saveData;

    private List<Product> _products;
    public event Action Opened;
    public event Action Closed;

    public Shop(List<Product> products, SaveData saveData)
    {
        _saveData = saveData;
        _products = products;

        _iapCore = new IAPCore((from product in _products
            where product.BuyableStrategy.GetType() == typeof(TicketsStrategy)
            select (TicketsStrategy) product.BuyableStrategy).ToList());

        foreach (var product in _products)
        {
            product.TryingToBuy += OnProductTryingBuy;
        }
    }

    public void Open()
    {
        Opened?.Invoke();
    }

    public void Close()
    {
        Closed?.Invoke();
    }

    private void OnProductTryingBuy(Product product)
    {
        if (product.LevelForPurchase > _saveData.PlayerLevel)
            return;

        product.BuyableStrategy.Byu();
    }

    public void Dispose()
    {
        foreach (var product in _products)
        {
            product.TryingToBuy -= OnProductTryingBuy;
        }
    }
}