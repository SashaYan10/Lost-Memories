using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int numScene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(numScene);
    }

    public void ShowPanel(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void HidePanel(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void DeleteObject(GameObject obj)
    {
        Destroy(obj);
    }
}
