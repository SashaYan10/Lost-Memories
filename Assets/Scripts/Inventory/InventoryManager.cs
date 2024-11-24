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
    public GameObject[] blockingPanels;

    private bool isOpen = false;

    void Update()
    {
        if (isOpen && IsBlockingPanels())
        {
            CloseInventory();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (IsBlockingPanels())
        {
            CloseInventory();
            return;
        }

        isOpen = !isOpen;
        inventoryPanel.SetActive(isOpen);

        if (!isOpen && inventoryDescriptionPanel.activeSelf)
        {
            inventoryDescriptionPanel.SetActive(false);
        }
    }

    public void ShowDescription(Item item)
    {
        if (IsBlockingPanels()) return;

        inventoryDescriptionPanel.SetActive(true);
        itemImage.sprite = item.itemIcon;
        itemDescription.text = item.itemDescription;
    }

    public void HideDescription()
    {
        inventoryDescriptionPanel.SetActive(false);
    }

    public void CloseInventory()
    {
        isOpen = false;
        inventoryPanel.SetActive(false);
        inventoryDescriptionPanel.SetActive(false);
    }

    private bool IsBlockingPanels()
    {
        foreach (var panel in blockingPanels)
        {
            if (panel != null && panel.activeSelf)
            {
                return true;
            }
        }

        return false;
    }
}
