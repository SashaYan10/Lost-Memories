using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;

        [Header("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;

        [Header("Time parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        [Header("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;

        [Header("Dialogue Settings")]
        [SerializeField] private bool shouldDestroyAfterFinish = false;
        [SerializeField] private bool autoConfirm = false;

        private Coroutine lineAppearCoroutine;

        private void Awake()
        {
            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }

        private void OnEnable()
        {
            ResetLine();
            lineAppearCoroutine = StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines));
        }

        public bool ShouldDestroyAfterFinish()
        {
            return shouldDestroyAfterFinish;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (textHolder.text != input)
                {
                    StopCoroutine(lineAppearCoroutine);
                    textHolder.text = input;
                }
            }

            if ((Input.GetKeyDown(KeyCode.Return) || autoConfirm) && textHolder.text == input)
            {
                finished = true;
            }
        }

        private void ResetLine()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            finished = false;
        }
    }
}
