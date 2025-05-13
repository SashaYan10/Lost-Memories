using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHide : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject hammer;

    private void Start()
    {
        HideCursor();
    }

    void Update()
    {
        bool shouldShowCursor = false;

        foreach (GameObject panel in panels)
        {
            if (panel != null && panel.activeInHierarchy)
            {
                shouldShowCursor = true;
                break;
            }
        }

        if (shouldShowCursor)
        {
            ShowCursor();
        }
        else if (hammer != null && hammer.activeInHierarchy)
        {
            HideCursorForHammer();
        }
        else
        {
            HideCursor();
        }
    }

    void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void HideCursorForHammer()
    {
        Cursor.visible = false;
    }
}
