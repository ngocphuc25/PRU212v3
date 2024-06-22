using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public PlayerMovement player;
    public List<SlotUI> slots = new List<SlotUI>();

    private Vector3 offset = new Vector3(1, 0, 0);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    void Refresh()
    {
        if (slots.Count == player.Inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.Inventory.slots[i].type != ItemType.None)
                {
                    slots[i].SetItem(player.Inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove(int slotId)
    {
        player.Inventory.RemoveItem(slotId);
        ProductPool.Instance.SpawnFromPool("Milk", player.transform.position + offset, Quaternion.identity);
        Refresh();
    }
}
