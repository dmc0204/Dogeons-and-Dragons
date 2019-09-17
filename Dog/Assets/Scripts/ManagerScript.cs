using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class ManagerScript : MonoBehaviour {

    public static ManagerScript Instance { get; private set; }
    public static int Counter { get; private set; }

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    public void IncrementCounter()
    {
        Counter++;
        UiScript.Instance.UpdatePointsText();
    }

    public void Restart()
    {
        PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_aim_for_the_skies, Counter);
        Counter = 0;
        UiScript.Instance.UpdatePointsText();
    }
}
