using TMPro;
using UnityEngine;

public class TicketAccountView : MonoBehaviour, IView
{
    [SerializeField] private TextMeshProUGUI ticketValueText;

    public void OnChangedTicket(int newValue)
    {
        ticketValueText.text = newValue.ToString();
    }
}