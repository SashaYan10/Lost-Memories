using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampOnOff : MonoBehaviour
{
    public Light2D lamp;
    public AudioClip soundEffect;
    public float lightIntensityOn = 1f;
    public float lightIntensityOff = 0.1f;
    
    private AudioSource audioSource;
    private bool isPlayer = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null )
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.RegisterAudioSrc(audioSource);
        }
    }

    private void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.Return))
        {
            ToggleLight();
        }
    }

    private void ToggleLight()
    {
        if (lamp != null)
        {
            lamp.intensity = lamp.intensity == lightIntensityOn ? lightIntensityOff : lightIntensityOn;

            if (soundEffect != null )
            {
                audioSource.PlayOneShot(soundEffect);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
}
