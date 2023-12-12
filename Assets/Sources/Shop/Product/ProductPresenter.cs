using System;

public class ProductPresenter : PresenterBase<Product, ProductView>, IDisposable
{
    public ProductPresenter(Product model, ProductView view) : base(model, view)
    {
        Model.BuyableStrategy.Purchased += View.OnPurchase;
        View.PurchaseButton.onClick.AddListener(Model.TryBuy);
    }

    public void Dispose()
    {
        Model.BuyableStrategy.Purchased += View.OnPurchase;
        View.PurchaseButton.onClick.RemoveListener(Model.TryBuy);
    }
}