using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public Text timerText;
    public float timeInSeconds = 60f;
    public int gameOver1 = 0;
    public int gameOver2 = 1;
    public int gameOver3 = 2;
    public int gameOver4 = 3;

    [SerializeField] GameObject finish1;
    [SerializeField] GameObject finish2;
    [SerializeField] GameObject finish3;
    [SerializeField] GameObject finish4;

    private bool timerRunning = true;

    void Update()
    {
        if (timerRunning)
        {
            if (timeInSeconds > 0)
            {
                timeInSeconds -= Time.deltaTime;
                UpdateTimerText();
            }
            else if (finish1.activeSelf)
            {
                SceneManager.LoadScene(gameOver1);
            }
            else if (finish2.activeSelf)
            {
                SceneManager.LoadScene(gameOver2);
            }
            else if (finish3.activeSelf)
            {
                SceneManager.LoadScene(gameOver3);
            }
            else if (finish4.activeSelf)
            {
                SceneManager.LoadScene(gameOver4);
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
