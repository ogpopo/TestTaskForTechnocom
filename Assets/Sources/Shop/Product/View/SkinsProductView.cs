using TMPro;
using UnityEngine;

public class SkinsProductView : ProductView
{
    [SerializeField] private TextMeshProUGUI _priceText;

    public void Init(SkinsProductConfig config)
    {
        _priceText.text = config.PriceInTickets.ToString();
        base.Init(config);
    }
}