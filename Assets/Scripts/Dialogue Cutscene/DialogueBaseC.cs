using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBaseC : MonoBehaviour
{
    public bool finished { get; protected set; }

    protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, AudioClip sound, float delayBetweenLines)
    {
        textHolder.color = textColor;
        textHolder.font = textFont;

        for (int i = 0; i < input.Length; i++)
        {
            textHolder.text += input[i];
            SoundManager.instance.PlaySound(sound);
            yield return new WaitForSeconds(delay);
        }

        finished = true;
    }
}
