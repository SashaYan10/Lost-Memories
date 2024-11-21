using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject inventoryDescriptionPanel;
    public Image itemImage;
    public Text itemDescription;
    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        isOpen = !isOpen;
        inventoryPanel.SetActive(isOpen);

        if (!isOpen && inventoryDescriptionPanel.activeSelf)
        {
            inventoryDescriptionPanel.SetActive(false);
        }
    }

    public void ShowDescription(Item item)
    {
        inventoryDescriptionPanel.SetActive(true);
        itemImage.sprite = item.itemIcon;
        itemDescription.text = item.itemDescription;
    }

    public void HideDescription()
    {
        inventoryDescriptionPanel.SetActive(false);
    }
}
