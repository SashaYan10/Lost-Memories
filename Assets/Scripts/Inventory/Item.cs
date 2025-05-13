using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public string itemDescription;
    public string itemDescriptonEng;

    public string GetLocalizedDescription()
    {
        var locale = LocalizationSettings.SelectedLocale;
        string code = locale.Identifier.Code;

        if (code == "en")
            return itemDescriptonEng;
        else if (code == "uk")
            return itemDescription;
        else
            return itemDescriptonEng;

    }
}
