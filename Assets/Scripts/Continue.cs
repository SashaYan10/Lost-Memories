using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    public GameObject[] objectsShow;
    public GameObject objectHide;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (GameObject obj in objectsShow)
            {
                obj.SetActive(true);
            }

            if (objectHide != null)
            {
                objectHide.SetActive(false);
            }
        }
    }
}
