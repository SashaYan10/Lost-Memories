using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateManage : MonoBehaviour
{
    private Vector3[] savedPositions;
    private bool[] savedActive;
    public GameObject stateManagerObject;

    public static SceneStateManage Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

        stateManagerObject = gameObject;
    }

    public void SaveSceneState(GameObject[] objects)
    {
        savedPositions = new Vector3[objects.Length];
        savedActive = new bool[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            savedPositions[i] = objects[i].transform.position;
            savedActive[i] = objects[i].activeSelf;
        }
    }

    public void RestoreSceneState(GameObject[] objects)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.position = savedPositions[i];
            objects[i].SetActive(savedActive[i]);
        }
    }

    public void DisableStateManagerObject()
    {
        stateManagerObject.SetActive(false);
    }

    public void EnableStateManagerObj()
    {
        stateManagerObject = GameObject.FindGameObjectWithTag("Save");
        if (stateManagerObject != null)
        {
            stateManagerObject.SetActive(true);
        } else
        {
            Debug.LogError("Не знайдено об'єкт для зберігання!");
        }
    }
}
