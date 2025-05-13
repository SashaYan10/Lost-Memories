using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryBabyRoom : MonoBehaviour
{
    [Header("Об'єкт, який перевіряється")]
    public GameObject targetObj;

    [Header("Об'єкт, що активується, коли головний об'єкт видалений")]
    public GameObject[] activateIfMissing;

    [Header("Об'єкт, що активується, коли головний об'єкт існує, але тоді видаляється")]
    public GameObject[] activateIfExists;

    public void CheckAndAct()
    {
        if (targetObj == null)
        {
            ActivateObjects(activateIfMissing);
        }
        else
        {
            Destroy(targetObj);
            ActivateObjects(activateIfExists);
        }
    }

    private void ActivateObjects(GameObject[] objects)
    {
        if (objects == null) return;

        foreach (var obj in objects)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
