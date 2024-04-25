using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIImageHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _discriptionWindow;
    [SerializeField] private TextMeshProUGUI _discriptionText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        InventorySlot slot = GetComponent<InventorySlot>();

        if (slot.AmountItem > 0)
        {
            _discriptionText.text =slot.DiscriptionProduct;

            _discriptionWindow.SetActive(true);
            _discriptionText.gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _discriptionWindow.SetActive(false);
    }
}