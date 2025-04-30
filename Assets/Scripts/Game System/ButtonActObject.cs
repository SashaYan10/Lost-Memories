using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActObject : MonoBehaviour
{
    public Button actButton;
    public GameObject actObj;
    public float delay = 1f;

    void Start()
    {
        if (actButton != null)
        {
            actButton.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        StartCoroutine(ActivateObj());
    }

    IEnumerator ActivateObj()
    {
        yield return new WaitForSeconds(delay);
        actObj.SetActive(true);
    }
}
