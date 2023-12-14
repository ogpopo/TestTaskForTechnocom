using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductView : MonoBehaviour, IView
{
    [SerializeField] private Image _icon;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _priceText;

    [SerializeField] private Transform _сonfirmationObject;

    public void Init()
    {
        
    }
}