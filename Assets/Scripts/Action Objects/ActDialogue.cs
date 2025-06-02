using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;

    private bool recentlyActivated = false;
    private float cooldownTime = 1.5f;

    public void ActiveDialogue()
    {
        if (!recentlyActivated && !DialogueSystem.DialogueHolder.IsDialogueActive)
        {
            dialogue.SetActive(true);
            StartCoroutine(DialogueCooldown());
        }
    }

    private IEnumerator DialogueCooldown()
    {
        recentlyActivated = true;
        yield return new WaitForSeconds(cooldownTime);
        recentlyActivated = false;
    }

    public bool DialogueActive()
    {
        return dialogue.activeInHierarchy;
    }
}
