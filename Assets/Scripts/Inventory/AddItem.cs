using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddItem : MonoBehaviour
{
    public Item itemAdd;
    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    public void AddItemToInventory()
    {
        StartCoroutine(ActivateInventory());
    }

    private IEnumerator ActivateInventory()
    {
        inventoryManager.inventoryPanel.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        var slots = inventoryManager.inventoryPanel.GetComponentsInChildren<ItemButton>();
        foreach (var slot in slots)
        {
            if (slot.GetComponent<Image>().sprite == null)
            {
                slot.SetItem(itemAdd);
                break;
            }
        }

        inventoryManager.inventoryPanel.SetActive(false);
    }
}
