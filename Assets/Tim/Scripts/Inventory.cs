using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int item = 0;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] Canvas inventoryCanvas;
    [SerializeField] public bool inventoryOpened;

    void Start()
    {
        item = 0;
        inventoryCanvas.enabled = false;
        inventoryOpened = false;
    }

    void Update()
    {
        
        //OpenInventory();
        //CloseInventory();
        if (Input.GetKeyDown(KeyCode.Tab) && !inventoryOpened)
        {
            Time.timeScale = 0;
            inventoryCanvas.enabled = true;
            inventoryOpened = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && inventoryOpened)
        {
            Time.timeScale = 1;
            inventoryCanvas.enabled = false;
            inventoryOpened = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void AddItemToInventory()
    {
        item++;
    }

    private void OpenInventory()
    {
        
    }

    private void CloseInventory()
    {
        
    }

    public void CloseInventoryWithButton()
    {
        if (inventoryOpened)
        {
            inventoryCanvas.enabled = false;
            inventoryOpened = false;
        }
    }
}
