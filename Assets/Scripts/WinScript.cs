using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public int fullElementToWin = 0;
    public static int myElement;
    public GameObject myPanel;
    public GameObject winPanel;

    private void Start()
    {
        myElement = 0;
        winPanel.SetActive(false);
    }
    void Update()
    {
        if (myElement >= fullElementToWin)
        {
            winPanel.SetActive(true);
        }
    }

    public static void AddElement()
    {
        myElement++;
    }
}
