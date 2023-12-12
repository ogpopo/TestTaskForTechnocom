using TMPro;
using UnityEngine;

public class TicketsProductView : ProductView
{
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private TextMeshProUGUI _ticketsPerPurchase;
    
    public void Init(TicketsChestConfig config)
    {
        _priceText.text = config.PriceInDollars + "$";
        _ticketsPerPurchase.text = config.TicketsPerPurchase.ToString();
        base.Init(config);
    }
}