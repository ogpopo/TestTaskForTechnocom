using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LevelsView : MonoBehaviour, IView
{
    [field: SerializeField] public Button CloseButton { get; private set; }

    public void OnOpen()
    {
        transform.DOScale(Vector3.one, .1f);
    }

    public void OnClose()
    {
        transform.DOScale(Vector3.zero, .1f).OnComplete(() => gameObject.SetActive(true));
    }
}