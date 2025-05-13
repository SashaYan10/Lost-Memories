using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class DialogueLineC : DialogueBaseC
{
    private Text textHolder;

    [Header("Text Options")]
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

    [Header("Dialogue Settings")]
    [SerializeField] private bool shouldDestroyAfterFinish = false;
    [SerializeField] private bool autoConfirm = false;

    private Coroutine lineAppearCoroutine;
    private string selectedInput;

    private void Awake()
    {
        textHolder = GetComponent<Text>();
        if (imageHolder != null && characterSprite != null)
        {
            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }
    }

    private void OnEnable()
    {
        ResetLine();
        selectedInput = GetLocalizedInput();
        lineAppearCoroutine = StartCoroutine(WriteText(selectedInput, textHolder, textColor, textFont, delay, sound, delayBetweenLines));
    }

    public bool ShouldDestroyAfterFinish()
    {
        return shouldDestroyAfterFinish;
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

        if ((Input.GetKeyDown(KeyCode.Return) || autoConfirm) && textHolder.text == selectedInput)
        {
            finished = true;
        }
    }

    private void ResetLine()
    {
        textHolder.text = "";
        finished = false;
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
