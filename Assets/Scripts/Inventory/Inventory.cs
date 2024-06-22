using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public ItemType type;
        public int count;
        public int maxAllowed;
        public Sprite icon;

        public Slot()
        {
            type = ItemType.None;
            count = 0;
            maxAllowed = 99;
        }

        public bool CanAddItem() => count < maxAllowed;

        public void Add(IItem item, int qty)
        {
            type = item.type;
            icon = item.icon;
            count += qty;
            maxAllowed = item.maxSlot;
        }

        public void Remove()
        {
            if (count > 0)
            {
                count--;
                if (count == 0)
                {
                    type = ItemType.None;
                    icon = null;
                    maxAllowed = 99;
                }
            }
        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlot)
    {
        for (int i = 0; i < numSlot; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void AddItem(IItem item, int count)
    {
        foreach (var slot in slots)
        {
            if (slot.type == item.type && slot.CanAddItem())
            {
                slot.Add(item, count);
                return;
            }
        }

        foreach (var slot in slots)
        {
            if (slot.type == ItemType.None)
            {
                slot.Add(item, count);
                return;
            }
        }
    }

    public void RemoveItem(int index)
    {
        slots[index].Remove();
    }
}
