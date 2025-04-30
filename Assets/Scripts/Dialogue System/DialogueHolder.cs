using System.Collections;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        public static bool IsDialogueActive { get; private set; }

        private void OnEnable()
        {
            StartCoroutine(dialogueSequence());
        }

        private IEnumerator dialogueSequence()
        {
            IsDialogueActive = true;
            for (int i = 0; i < transform.childCount; i++)
            {
                Deactivate();
                var dialogueLine = transform.GetChild(i).GetComponent<DialogueLine>();
                dialogueLine.gameObject.SetActive(true);
                yield return new WaitUntil(() => dialogueLine.finished);

                if (dialogueLine.ShouldDestroyAfterFinish())
                {
                    Destroy(dialogueLine.gameObject);
                }
            }
            IsDialogueActive = false;
            gameObject.SetActive(false);
        }

        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
