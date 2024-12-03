using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddItemOnActObj : MonoBehaviour
{
    public Item itemAdd;
    private InventoryManager inventoryManager;

    private void OnEnable()
    {
        StartCoroutine(AddItem());
    }

    private IEnumerator AddItem()
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
        bool itemAdded = false;

        foreach (var slot in slots)
        {
            if (slot.GetComponent<Image>().sprite == null)
            {
                slot.SetItem(itemAdd);
                itemAdded = true;
                break;
            }
        }

        inventoryManager.inventoryPanel.SetActive(false);
    }
}
