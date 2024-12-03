using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Button button;
    private Item currentItem;
    private InventoryManager inventoryManager;
    private Image buttonImage;

    private bool isDescriptionOpen = false;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        buttonImage = GetComponent<Image>();

        UpdateButtonState();
        button.onClick.AddListener(OnItemClick);
    }

    public void SetItem(Item item)
    {
        currentItem = item;
        buttonImage.sprite = item.itemIcon;
        UpdateButtonState();
    }

    public Item GetItem()
    {
        return currentItem;
    }

    public void ClearItem()
    {
        currentItem = null;
        buttonImage.sprite = null;
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        buttonImage.enabled = currentItem != null;
    }

    public void OnItemClick()
    {
        if (currentItem != null)
        {
            if (isDescriptionOpen)
            {
                inventoryManager.HideDescription();
                isDescriptionOpen = false;
            }
            else
            {
                inventoryManager.ShowDescription(currentItem);
                isDescriptionOpen = true;
            }
        }
    }
}
