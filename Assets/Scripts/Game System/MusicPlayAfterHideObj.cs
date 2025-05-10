using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayAfterHideObj : MonoBehaviour
{
    public GameObject ObjectHide;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (ObjectHide != null && audioSource != null)
        {
            if (!ObjectHide.activeInHierarchy && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else if (ObjectHide.activeInHierarchy && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
