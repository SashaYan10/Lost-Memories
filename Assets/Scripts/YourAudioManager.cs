using UnityEngine.SceneManagement;
using UnityEngine;

public class YourAudioManager : MonoBehaviour
{
    private static YourAudioManager instance;

    // Додайте ваші аудіо-компоненти або інші потрібні дані.

    // Задайте індекси сцен, на яких потрібно виконати певні дії щодо музики.
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
        // Додайте власний код для налаштування аудіо, якщо потрібно.
    }

    void Update()
    {
        // Перевірка індексу поточної сцени і виконання відповідних дій.

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Перевірка, чи поточний індекс сцени знаходиться в масиві для відтворення музики.
        if (ArrayContains(playMusicScenes, currentSceneIndex))
        {
            PlayMusic();
        }
        // Перевірка, чи поточний індекс сцени знаходиться в масиві для зупинки музики.
        else if (ArrayContains(stopMusicScenes, currentSceneIndex))
        {
            StopMusic();
        }
        // Перевірка, чи поточний індекс сцени знаходиться в масиві для знову почати грати музику.
        else if (ArrayContains(restartMusicScenes, currentSceneIndex))
        {
            RestartMusic();
        }
    }

    void PlayMusic()
    {
        // Припустимо, що ви використовуєте компонент AudioSource для відтворення музики.
        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            // Перевірка, чи аудіо не відтворюється вже, щоб уникнути подвійного відтворення.
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
        // Припустимо, що ви використовуєте компонент AudioSource для відтворення музики.
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
        // Припустимо, що ви використовуєте компонент AudioSource для відтворення музики.
        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            // Зупинка музики перед відтворенням з початку.
            audioSource.Stop();

            // Відтворення музики з початку.
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource is null.");
        }
    }


    // Метод для перевірки наявності значення в масиві.
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
