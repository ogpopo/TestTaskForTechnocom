using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPCore : IStoreListener, IDisposable
{
    private static IStoreController _storeController;
    private static IExtensionProvider _storeExtensionProvider;

    private List<TicketsStrategy> _buyables;

    public IAPCore(List<TicketsStrategy> buyables)
    {
        _buyables = buyables;

        foreach (var buyable in _buyables)
            buyable.TryingToBuy += TryBuyProduct;

        InitializePurchasing();
    }

    private void InitializePurchasing()
    {
        if (IsInitialized())
            return;

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        foreach (var buyable in _buyables)
        {
            builder.AddProduct(buyable.IDForPurchase, UnityEngine.Purchasing.ProductType.NonConsumable);
        }

        UnityPurchasing.Initialize(this, builder);
    }

    private void TryBuyProduct(TicketsStrategy ticketsStrategy)
    {

        if (IsInitialized() == false)
            return;

        UnityEngine.Purchasing.Product product = _storeController.products.WithID(ticketsStrategy.IDForPurchase);

        if (product == null || product.availableToPurchase == false)
            return;

        _storeController.InitiatePurchase(product);
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        foreach (var buyable in _buyables)
        {
            if (string.Equals(purchaseEvent.purchasedProduct.definition.id, buyable.IDForPurchase,
                StringComparison.Ordinal))
            {
                buyable.ConfirmedPurchase();
            }
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(UnityEngine.Purchasing.Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}",
            product.definition.storeSpecificId, failureReason));
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _storeController = controller;
        _storeExtensionProvider = extensions;
    }

    private bool IsInitialized()
    {
        return _storeController != null && _storeExtensionProvider != null;
    }

    public void Dispose()
    {
        foreach (var buyable in _buyables)
            buyable.TryingToBuy -= TryBuyProduct;
    }
}