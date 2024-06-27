using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject dragItemIcon;
    RectTransform iconTranform;
    Image itemIconImage;
    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTranform = dragItemIcon.GetComponent<RectTransform>();
        itemIconImage = dragItemIcon.GetComponent<Image>();
    }
    private void Update()
    {
        if (dragItemIcon.activeInHierarchy == true)
        {
            iconTranform.position = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                  Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                  worldPosition.z =0;
                  ItemSpawnManager.instance.SpawnItem(
                    worldPosition,
                    itemSlot.item,
                    itemSlot.count);

                    itemSlot.Clear();
                    dragItemIcon.SetActive(false);

                }
            }
        }
    }
    public void OnClick(ItemSlot itemSlot)
    {
        if (this.itemSlot.item == null)
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else
        {
            Item item = itemSlot.item;
            int count = itemSlot.count;

            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
        }
        UpdateIcon();
    }

    public void UpdateIcon()
    {
        if (itemSlot.item == null)
        {
            dragItemIcon.SetActive(false);
        }
        else
        {
            dragItemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }

    }
}
