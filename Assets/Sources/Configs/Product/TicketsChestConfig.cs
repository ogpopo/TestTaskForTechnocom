using UnityEngine;

[CreateAssetMenu(fileName = "Tickets Chest Config")]
public class TicketsChestConfig : ProductConfig
{
    [field: SerializeField] public float PriceInDollars { get; private set; }
    [field: SerializeField] public int TicketsPerPurchase { get; private set; }
    [field: SerializeField] public string IDForPurchase { get; private set; }
}