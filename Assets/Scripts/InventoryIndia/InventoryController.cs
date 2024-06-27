using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject panel;
    [SerializeField] GameObject toolbarPanel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            panel.SetActive(!panel.activeInHierarchy);
            toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
        }
    }
}
