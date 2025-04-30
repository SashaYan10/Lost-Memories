using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public int[] playMusicScenes;
    public int[] stopMusicScenes;
    public int[] restartMusicScenes;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
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
        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("Audio is already playing.");
            }
        }
        else
        {
            Debug.LogWarning("AudioSource is null.");
        }
    }


    void StopMusic()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            Debug.LogWarning("AudioSource is either null or not playing.");
        }
    }

    void RestartMusic()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.Stop();

            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource is null.");
        }
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
}
