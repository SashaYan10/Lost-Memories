using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

namespace DialogueSystem1
{
    public class DialogueLine1 : DialogueBaseClass1
    {
        private Text textHolder;

        [Header ("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private string inputEng;
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
        private string selectedInput;

        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";

            if (imageHolder != null && characterSprite != null)
            {
                imageHolder.sprite = characterSprite;
                imageHolder.preserveAspect = true;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (textHolder.text != selectedInput)
                {
                    StopCoroutine(lineAppearCoroutine);
                    textHolder.text = selectedInput;
                }
            }

            if (Input.GetKeyDown(KeyCode.Return) && textHolder.text == selectedInput)
            {
                finished = true;
            }
        }
        private void Start()
        {
            selectedInput = GetLocalizedInput();
            lineAppearCoroutine = StartCoroutine(WriteText(selectedInput, textHolder, textColor, textFont, delay, sound, delayBetweenLines));
        }

        private string GetLocalizedInput()
        {
            var locale = LocalizationSettings.SelectedLocale;
            string code = locale.Identifier.Code;

            if (code == "en")
                return inputEng;
            else if (code == "uk")
                return input;
            else
                return inputEng;
        }
    }
}