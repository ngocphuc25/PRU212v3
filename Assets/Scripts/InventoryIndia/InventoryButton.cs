
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    [SerializeField] Image icon;
    [SerializeField] Text text;
    [SerializeField] Image highlight;

     public int myIndex;
    public void SetIndex(int index)
    {
        myIndex = index;
    }

         public void Set(ItemSlot slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;

        if (slot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString();
        }
        else
        {
            text.gameObject.SetActive(false);
        }


    }

    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
        // ItemContainer inventory = PickUpController.instance.inventoyContainer;
         //PickUpController.instance.itemDragAndDropController.OnClick(inventory.slots[myIndex]);

        // // Cập nhật giao diện sau khi click
        // transform.parent.GetComponent<InventoryPanel>().Show();

        ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>();
        itemPanel.OnClick(myIndex);

    }

    public void Highlight(bool b){
        highlight.gameObject.SetActive(b);
    }
}
