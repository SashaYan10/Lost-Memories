using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsFocusHandler : MonoBehaviour
{
    public GameObject warning;
    public float hideDelay = 3f;
    public TimerScript timerScript;
    void Start()
    {
        if (warning != null)
            warning.SetActive(false);

        if (timerScript == null)
            timerScript = FindObjectOfType<TimerScript>();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            GameMinimized();
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(HidePanel());
        }
    }

    void GameMinimized()
    {
        if (warning != null)
            warning.SetActive(true);

        if (timerScript != null)
            timerScript.ReduceTime(600);
    }

    IEnumerator HidePanel()
    {
        yield return new WaitForSeconds(hideDelay);
        warning.SetActive(false);
    }
}
