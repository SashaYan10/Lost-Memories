using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoMinigame : MonoBehaviour
{
    public List<Button> correctKeys;
    private List<Button> playerInput = new List<Button>();
    public GameObject winPanel;

    void Start()
    {
        winPanel.SetActive(false);
    }

    public void OnKeyPressed(Button key)
    {
        playerInput.Add(key);

        if (playerInput.Count <= correctKeys.Count)
        {
            for (int i = 0; i < playerInput.Count; i++)
            {
                if (playerInput[i] != correctKeys[i])
                {
                    ResetGame();
                    return;
                }
            }
        }

        if (playerInput.Count == correctKeys.Count)
            WinGame();
    }

    private void WinGame()
    {
        winPanel.SetActive(true);
    }

    private void ResetGame()
    {
        playerInput.Clear();
    }
}
