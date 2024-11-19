using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSave;

    public void SaveState()
    {
        SceneStateManage.Instance.SaveSceneState(objectsToSave);
    }

    public void LoadRubikScene()
    {
        SaveState();
        SceneStateManage.Instance.DisableStateManagerObject();
        SceneManager.LoadScene("RubikScene");
    }

    public void ReturnToLevel()
    {
        SceneManager.LoadScene("First Level");
        SceneStateManage.Instance.EnableStateManagerObj();
        SceneStateManage.Instance.RestoreSceneState(objectsToSave);
    }
}
