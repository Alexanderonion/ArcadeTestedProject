using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Transform _inventoryPanel;

    private List<InventorySlot> _slots;

    public Transform InventoryPanel
    {
        get { return _inventoryPanel; }
    }

    public List<InventorySlot> Slots
    {
        get { return _slots; }
    }

    private void OnEnable()
    {
        Player.IsHarvested += AddItem;
    }

    private void OnDestroy()
    {
        Player.IsHarvested -= AddItem;
    }

    void Start()
    {
        _slots = new List<InventorySlot>();

        for(int i = 0; i < InventoryPanel.childCount; i++)
        {
            if(InventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                Slots.Add(InventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }

    private void AddItem(ProductItem item)
    {
        foreach (InventorySlot slot in Slots)
        {
            if (slot.ProductType == item.ProductType && slot.AmountItem != 0 && slot.AmountItem + item.Amount <= item.MaximumAmountInInventorySlot)
            {
                slot.AddItemInSlot(item);
                return;
            }
        }

        foreach (InventorySlot slot in Slots)
        {
            if(slot.IsEmpty)
            {
                slot.AddItemInSlot(item);
                break;
            }
        }
    }

    public bool AddItemPossible(ProductItem item)
    {
        foreach (InventorySlot slot in Slots)
        {
            if (slot.IsEmpty)
            {
                return true;
            }

            if (slot.ProductType == item.ProductType && slot.AmountItem + item.Amount < item.MaximumAmountInInventorySlot)
            {
                return true;
            }
        }

        return false;
    }

    public bool SubtractItem(ProductType productType, int subtrahend)
    {
        foreach (InventorySlot slot in Slots)
        {
            if (slot.ProductType == productType && slot.AmountItem > 0)
            {
                return slot.SubtractItemInSlot(productType, subtrahend);
            }
        }

        return false;
    }

    public void SetInventorySlots(List<SlotData> inventoryData)
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            _slots[i].SetSlotValue(inventoryData[i]._amountItem, inventoryData[i]._isEmpty, inventoryData[i]._productType);
        }
    }
}