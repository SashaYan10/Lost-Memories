using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Piano : MonoBehaviour, IPointerDownHandler
{
    public AudioClip key;
    private AudioSource audioSource;
    private PianoMinigame pianoMinigame;
    
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        pianoMinigame = FindObjectOfType<PianoMinigame>();

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.RegisterAudioSrc(audioSource);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (key != null)
        {
            audioSource.PlayOneShot(key);
        }
        pianoMinigame.OnKeyPressed(GetComponent<Button>());
    }
}
