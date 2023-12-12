using System;

public class Product : IModel
{
    private IBuyable _buyableStrategy;

    private int _levelForPurchase;
    private int _id;

    public Action<Product> TryingToBuy;

    public Product(IBuyable buyableStrategy, int levelForPurchase, int id)
    {
        _buyableStrategy = buyableStrategy;
        _levelForPurchase = levelForPurchase;
        _id = id;
    }

    public IBuyable BuyableStrategy => _buyableStrategy;

    public int LevelForPurchase => _levelForPurchase;

    public void TryBuy()
    {
        TryingToBuy?.Invoke(this);
    }
}