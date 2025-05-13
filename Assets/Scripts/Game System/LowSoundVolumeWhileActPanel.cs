using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class LowSoundVolumeWhileActPanel : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject panel;

    private float baseVolume;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        baseVolume = AudioManager.Instance.GetVolume();
        AudioManager.Instance.RegisterAudioSrc(audioSource);
    }

    void Update()
    {
        if (audioSource != null && panel != null)
        {
            float masterVolume = AudioManager.Instance.GetVolume();

            if (panel.activeInHierarchy)
            {
                audioSource.volume = masterVolume * 0.2f;
            }
            else
            {
                audioSource.volume = masterVolume;
            }
        }
    }
}
