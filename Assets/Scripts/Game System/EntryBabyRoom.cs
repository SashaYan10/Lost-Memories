using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryBabyRoom : MonoBehaviour
{
    [Header("��'���, ���� ������������")]
    public GameObject targetObj;

    [Header("��'���, �� ����������, ���� �������� ��'��� ���������")]
    public GameObject[] activateIfMissing;

    [Header("��'���, �� ����������, ���� �������� ��'��� ����, ��� ��� �����������")]
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
