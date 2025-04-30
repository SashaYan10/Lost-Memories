using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscordManager : MonoBehaviour
{
    private static DiscordManager instance;
    Discord.Discord discord;

    private void Awake()
    {
        if (instance != null && instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        discord = new Discord.Discord(1332073320316932237, (ulong)Discord.CreateFlags.NoRequireDiscord);
        ChangeActivity();
    }

    private void OnDisable()
    {
        if (discord != null)
        {
            discord.Dispose();
        }
    }

    public void ChangeActivity()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = "Playing",
            Details = "Escaping the house",
            Timestamps =
            {
                Start = System.DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            },
            Assets =
            {
                LargeImage = "icon"
            }
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            Debug.Log("Activity updated!");
        });
    }

    void ButtonClicked()
    {
        ChangeActivity();
    }
    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
    }
}
