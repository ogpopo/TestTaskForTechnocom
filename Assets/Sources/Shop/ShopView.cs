using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour, IView
{
    [field: SerializeField] public Transform HolderForTickets;
    [field: SerializeField] public Transform HolderForSkins;
    [field: SerializeField] public Transform HolderForLocation;

    [field: SerializeField] public Button ClickOnCloseButton { get; private set; }

    public void OnOpen()
    {
        transform.DOScale(Vector3.one, .1f);
    }

    public void OnClose()
    {
        transform.DOScale(Vector3.zero, .1f).OnComplete(() => gameObject.SetActive(true));
    }
}