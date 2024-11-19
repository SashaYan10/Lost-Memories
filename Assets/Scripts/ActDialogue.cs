using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;

    public void ActiveDialogue()
    {
        dialogue.SetActive(true);
    }

    public bool DialogueActive()
    {
        return dialogue.activeInHierarchy;
    }
}
