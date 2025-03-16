using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private int NextLevel;
    public float sec;

    private void Start()
    {
        StartCoroutine(WaitAndLoad());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(NextLevel);
        }
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(NextLevel);
    }
}
