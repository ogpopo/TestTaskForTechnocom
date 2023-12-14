public class Product : IModel
{
    private IBuyable _buyableStrategy;

    private int _levelForPurchase;
    private int _id;

    public Product(IBuyable buyableStrategy, int levelForPurchase, int id)
    {
        
    }
}