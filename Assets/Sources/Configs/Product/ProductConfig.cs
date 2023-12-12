using UnityEngine;

public enum ProductType
{
    Chest,
    Skins,
    Locations
}

public abstract class ProductConfig : ScriptableObject
{
    [field: SerializeField] public int PurchaseLevel { get; private set; }

    [field: SerializeField] public ProductType ProductType { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}