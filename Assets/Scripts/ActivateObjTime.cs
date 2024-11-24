using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjTime : MonoBehaviour
{
    [SerializeField] private GameObject playerAct;
    [SerializeField] private GameObject playerHide;
    public float sec;

    private void Start()
    {
        StartCoroutine(WaitAndActivate());
    }

    private IEnumerator WaitAndActivate()
    {
        yield return new WaitForSeconds(sec);
        playerAct.SetActive(true);
        playerHide.SetActive(false);
    }
}
