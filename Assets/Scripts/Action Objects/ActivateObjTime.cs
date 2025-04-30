using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjTime : MonoBehaviour
{
    [SerializeField] private GameObject playerAct;
    [SerializeField] private GameObject[] objectsHide;
    public float sec;

    private void Start()
    {
        StartCoroutine(WaitAndActivate());
    }

    private IEnumerator WaitAndActivate()
    {
        yield return new WaitForSeconds(sec);
        playerAct.SetActive(true);
        foreach (GameObject obj in objectsHide)
        {
            obj.SetActive(false);
        }
    }
}
