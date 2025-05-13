using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public int[] playMusicScenes;
    public int[] stopMusicScenes;
    public int[] restartMusicScenes;

    private List<AudioSource> allAudioSrc = new List<AudioSource>();
    private float volume = 1f;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();

            volume = Mathf.Clamp(PlayerPrefs.GetFloat("MasterVolume", 1f), 0.0005f, 0.5f);

            RegisterAudioSrc(audioSource);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (ArrayContains(playMusicScenes, currentSceneIndex))
        {
            PlayMusic();
        }
        else if (ArrayContains(stopMusicScenes, currentSceneIndex))
        {
            StopMusic();
        }
        else if (ArrayContains(restartMusicScenes, currentSceneIndex))
        {
            RestartMusic();
        }
    }

    void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void RestartMusic()
    {
        audioSource.Stop();
        audioSource.Play();
    }

    bool ArrayContains(int[] array, int value)
    {
        foreach (int item in array)
        {
            if (item == value)
            {
                return true;
            }
        }
        return false;
    }

    public void RegisterAudioSrc(AudioSource source)
    {
        if (!allAudioSrc.Contains(source))
        {
            allAudioSrc.Add(source);
            source.volume = volume;
        }
    }

    public void UnregisterAudioSrc(AudioSource source)
    {
        if (allAudioSrc.Contains(source))
        {
            allAudioSrc.Remove(source);
        }
    }

    public void SetVolume(float newVolume)
    {
        volume = newVolume;
        foreach (AudioSource source in allAudioSrc)
        {
            if (source != null)
                source.volume = volume;
        }
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return volume;
    }
}
