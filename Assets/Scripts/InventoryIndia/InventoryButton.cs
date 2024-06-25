
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class InventoryButton : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] Image icon;
   [SerializeField] Text text;

    int myIndex;
    public void SetIndex(int index){
        myIndex = index;
    }
    public void Set (ItemSlot slot){
        icon.sprite =slot.item.icon;

        if (slot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            text.text =slot.count.ToString();
        }
        else 
        {
            text.gameObject.SetActive(false);
        }
        

    }

    public void Clean(){
        icon.sprite =null;
        icon.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }
}
