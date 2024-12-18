using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjAfterCheckActivation : MonoBehaviour
{
    public List<GameObject> objTrack;
    public GameObject objAct;

    [Header("Optional Settings")]
    public bool deleteObjects;
    public List<GameObject> objectsDelete;

    private HashSet<GameObject> activatedObjects = new HashSet<GameObject>();
    private GameObject lastActivatedObject = null;
    private bool lastDeactivatedTriggered = false;

    void Update()
    {
        TrackActivation();

        if (ObjectsWereActive() && lastActivatedObject != null && !lastActivatedObject.activeSelf && !lastDeactivatedTriggered)
        {
            objAct.SetActive(true);
            lastDeactivatedTriggered = true;

            if (deleteObjects)
            {
                DeleteOptionalObjects();
            }
        }
    }

    private void TrackActivation()
    {
        foreach (var obj in objTrack)
        {
            if (obj.activeSelf && !activatedObjects.Contains(obj))
            {
                activatedObjects.Add(obj);
                lastActivatedObject = obj;
                lastDeactivatedTriggered = false;
            }
        }
    }

    private bool ObjectsWereActive()
    {
        foreach (var obj in objTrack)
        {
            if (!activatedObjects.Contains(obj))
            {
                return false;
            }
        }
        return true;
    }

    private void DeleteOptionalObjects()
    {
        foreach (var obj in objectsDelete)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }

        objectsDelete.Clear();
    }
}
