using UnityEngine;

[CreateAssetMenu(fileName = "Skins Product Config")]
public class SkinsProductConfig : ProductConfig
{
    [field: SerializeField] public int PriceInTickets { get; private set; }
}