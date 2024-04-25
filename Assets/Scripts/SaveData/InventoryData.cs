using System;
using System.Collections.Generic;

[Serializable]
public class InventoryData
{
    public List<SlotData> Slots;

    public InventoryData()
    {
        Slots = new List<SlotData>();
    }
}