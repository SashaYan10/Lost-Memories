using System.Collections;
using UnityEngine;

public class ActionObject : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;
    private BoxCollider2D currentTrigger;
    private EdgeCollider2D currentEdge;
    public float delayToActivate = 1f;

    private void Awake()
    {
        currentTrigger = GetComponent<BoxCollider2D>();
        currentEdge = GetComponent<EdgeCollider2D>();
    }
    public void ActivateDialogue()
    {
        dialogue.SetActive(true);
        currentTrigger.enabled = false;
        currentEdge.enabled = false;

        StartCoroutine(ActivateObject());
    }

    public bool DialogueActive()
    {
        return dialogue.activeInHierarchy;
    }

    IEnumerator ActivateObject()
    {
        yield return new WaitForSeconds(delayToActivate);

        currentTrigger.enabled = true;
        currentEdge.enabled = true;
    }
}
