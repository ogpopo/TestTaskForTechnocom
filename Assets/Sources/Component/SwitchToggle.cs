using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SwitchToggle : MonoBehaviour
{
    private Toggle _toggle;

    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        OnToggle(_toggle.isOn);

        _toggle.onValueChanged.AddListener(OnToggle);
    }

    private void OnToggle(bool on)
    {
        _toggle.image.sprite = on == true ? _onSprite : _offSprite;
    }

    private void OnDestroy()
    {
        _toggle.onValueChanged.RemoveListener(OnToggle);
    }
}