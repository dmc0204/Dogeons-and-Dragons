using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;

public class UiScript : MonoBehaviour {

    public static UiScript Instance { get; private set; }

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    [SerializeField]
    private Text PointsTxt;
    //all used for buttons in level1 scene below
    public void GetPoint()
    {
        ManagerScript.Instance.IncrementCounter();
    }

    
    public void Restart()
    {
        ManagerScript.Instance.Restart();
    }
    


    public void Increment()
    {
        PlayGamesScript.IncrementAchievement(GPGSIds.achievement_touch_screen, 5);
    }

    public void Unlock()
    {
        PlayGamesScript.UnlockAchievement(GPGSIds.achievement_touch_screen);
    }

    public void ShowAchievements()
    {
        PlayGamesScript.ShowAchievementsUI();
    }

    public void ShowLeaderboards()
    {
        PlayGamesScript.ShowLeaderboardsUI();
    }

    public void UpdatePointsText()
    {
        PointsTxt.text = ManagerScript.Counter.ToString();
    }
}
