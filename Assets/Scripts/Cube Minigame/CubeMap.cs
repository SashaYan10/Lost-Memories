using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{
    private CubeState cubeState;
    private TimerScript timerScript;

    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform front;
    public Transform back;

    public GameObject errorPanel;

    private bool hasPenaltyApplied = false;

    void Start()
    {
        timerScript = FindObjectOfType<TimerScript>();
    }

    public void Set()
    {
        cubeState = FindObjectOfType<CubeState>();

        try
        {
            UpdateMap(cubeState.front, front);
            UpdateMap(cubeState.back, back);
            UpdateMap(cubeState.left, left);
            UpdateMap(cubeState.right, right);
            UpdateMap(cubeState.up, up);
            UpdateMap(cubeState.down, down);
        }
        catch (System.ArgumentOutOfRangeException ex)
        {
            Debug.LogWarning("Кубик пошкоджено: " + ex.Message);
            ShowErrorPanel();

            if (!hasPenaltyApplied && timerScript != null)
            {
                timerScript.ReduceTime(600f);
                hasPenaltyApplied = true;
            }
        }
    }

    void UpdateMap(List<GameObject> face, Transform side)
    {
        int i = 0;
        foreach (Transform map in side)
        {
            if (i >= face.Count)
            {
                throw new System.ArgumentOutOfRangeException("face", "Сторона кубика має менше елементів, ніж очікувалося.");
            }

            char c = face[i].name[0];

            switch (c)
            {
                case 'F':
                    map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
                    break;
                case 'B':
                    map.GetComponent<Image>().color = Color.red;
                    break;
                case 'U':
                    map.GetComponent<Image>().color = Color.yellow;
                    break;
                case 'D':
                    map.GetComponent<Image>().color = Color.white;
                    break;
                case 'L':
                    map.GetComponent<Image>().color = Color.green;
                    break;
                case 'R':
                    map.GetComponent<Image>().color = Color.blue;
                    break;
            }

            i++;
        }
    }

    void ShowErrorPanel()
    {
        if (errorPanel != null)
        {
            errorPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("errorPanel не призначено в інспекторі!");
        }
    }
}
