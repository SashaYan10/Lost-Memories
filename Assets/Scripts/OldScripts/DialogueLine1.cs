using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem1
{
    public class DialogueLine1 : DialogueBaseClass1
    {
        private Text textHolder;

        [Header ("Text Options")]
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

        private Coroutine lineAppearCoroutine;

        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";

            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
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

            if (Input.GetKeyDown(KeyCode.Return) && textHolder.text == input)
            {
                finished = true;
            }
        }
        private void Start()
        {
            lineAppearCoroutine = StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines));
        }
    }
}