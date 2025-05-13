using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RegisterAudioSrc : MonoBehaviour
{
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        AudioManager.Instance.RegisterAudioSrc(source);
    }

    private void OnDestroy()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.UnregisterAudioSrc(source);
        }
    }
}
