using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSwitch : MonoBehaviour
{
    public GameObject[] objectsDel;
    public GameObject[] objectsAct;
    public GameObject[] objectsHide;
    public float delay;

    private void Update()
    {
        foreach (GameObject obj in objectsDel)
        {
            if (obj == null)
            {
                StartCoroutine(ActivateObjects());
                DestroyObjects();
                return;
            }
        }
    }

    IEnumerator ActivateObjects()
    {
        yield return new WaitForSeconds(delay);
        foreach (GameObject obj in objectsAct)
        {
            obj.SetActive(true);
        }
    }

    void DestroyObjects()
    {
        foreach( GameObject obj in objectsHide)
        {
            Destroy(obj);
        }
    }
}
