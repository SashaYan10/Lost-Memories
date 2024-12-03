using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItemOnActivation : MonoBehaviour
{
    public string itemNameRemove;
    private InventoryManager inventoryManager;

    private void OnEnable()
    {
        StartCoroutine(RemoveItem());
    }

    private IEnumerator RemoveItem()
    {
        yield return new WaitForEndOfFrame();

        inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager == null)
        {
            yield break;
        }

        if (inventoryManager.inventoryPanel == null)
        {
            yield break;
        }

        yield return StartCoroutine(ActInventory());
    }

    private IEnumerator ActInventory()
    {
        inventoryManager.inventoryPanel.SetActive(true);

        yield return new WaitForSeconds(0.00001f);

        var slots = inventoryManager.inventoryPanel.GetComponentsInChildren<ItemButton>();
        bool itemRemoved = false;

        foreach (var slot in slots)
        {
            if (slot.GetItem() != null && slot.GetItem().itemName == itemNameRemove)
            {
                slot.ClearItem();
                itemRemoved = true;
                break;
            }
        }

        inventoryManager.inventoryPanel.SetActive(false);
    }
}
