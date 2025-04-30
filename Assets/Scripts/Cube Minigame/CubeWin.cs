using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeWin : MonoBehaviour
{
    public CubeState cubeState;
    public GameObject winPanel;
    public GameObject warning;

    void Start()
    {
        winPanel.SetActive(false);
        warning.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCubeSolved())
        {
            ShowWinPanel();
        }
    }

    bool IsCubeSolved()
    {
        return IsFaceSolved(cubeState.up) &&
               IsFaceSolved(cubeState.down) &&
               IsFaceSolved(cubeState.left) &&
               IsFaceSolved(cubeState.right) &&
               IsFaceSolved(cubeState.front) &&
               IsFaceSolved(cubeState.back);
    }

    bool IsFaceSolved(List<GameObject> face)
    {
        string color = face[0].name[0].ToString();
        foreach (GameObject piece in face)
        {
            if (piece.name[0].ToString() != color)
            {
                return false;
            }
        }
        return true;
    }

    void ShowWinPanel()
    {
        winPanel.SetActive(true);
        warning.SetActive(false);
    }
}
