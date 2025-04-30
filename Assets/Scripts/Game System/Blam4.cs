using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blam4 : MonoBehaviour
{
    public GameObject obj;

    public int scene;

    private void Update()
    {
        if (obj != null && !obj.activeInHierarchy)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
