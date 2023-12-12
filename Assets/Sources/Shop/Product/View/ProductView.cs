using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductView : MonoBehaviour, IView
{
    [SerializeField] protected TextMeshProUGUI _levelText;

    [SerializeField] protected Image _icon;

    [SerializeField] protected TextMeshProUGUI _nameText;

    [SerializeField] protected Transform _сonfirmationObject;

    [field: SerializeField] public Button PurchaseButton { get; private set; }

    protected void Init(ProductConfig config)
    {
        _levelText.text = "Level " + config.PurchaseLevel;
        _icon.sprite = config.Icon;
        _nameText.text = config.name;
    }

    public void SetActiveLevelText(bool active)
    {
        _levelText.gameObject.SetActive(active);
    }

    public void OnPurchase()
    {
        PurchaseButton.gameObject.SetActive(false);
        _сonfirmationObject.gameObject.SetActive(true);
    }
}