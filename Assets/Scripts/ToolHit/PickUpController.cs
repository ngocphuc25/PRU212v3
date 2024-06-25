using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    // Start is called before the first frame update
    public static  PickUpController instance;

    private void Awake() {
        instance =this;
    }

    public GameObject player;
    public ItemContainer inventoyContainer;
    public ItemDragAndDropController itemDragAndDropController;
}
