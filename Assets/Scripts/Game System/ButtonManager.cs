using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public float delay = 1f;
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

    public void HideDelay(GameObject obj)
    {
        StartCoroutine(Object());
        IEnumerator Object()
        {
            yield return new WaitForSeconds(delay);
            obj.SetActive(false);
        }
    }

    public void ActDelay(GameObject obj)
    {
        StartCoroutine(Object());
        IEnumerator Object()
        {
            yield return new WaitForSeconds(delay);
            obj.SetActive(true);
        }
    }

    public void PlaySound(GameObject obj)
    {
        AudioSource audioSource = obj.GetComponent<AudioSource>();
        audioSource.Play();
    }
}
