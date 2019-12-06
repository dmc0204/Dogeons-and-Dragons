using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{
    public PlayerLevelContainer hackyWorkaround;
    public LevelConfig[] levels;
    public Image[] yourDogs;

    //loads the level into the plc
    public void loadLevel(int i)
    {
        hackyWorkaround.myCoolLevel = levels[i];
        openTheGame();
    }

    //loads your dogs pictures
    public void initActiveTeamPics()
    {
        for (int i = 0; i < hackyWorkaround.myCoolPlayer.yourTeam.Length; i++)
        {
            yourDogs[i].sprite = hackyWorkaround.myCoolPlayer.yourTeam[i].head;
            yourDogs[i].color = new Color(1, 1, 1, 1);
        }
    }

    public void openTheGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Levels");
    }


    // Start is called before the first frame update
    void Start()
    {
        //hackyWorkaround.myCoolPlayer.playerInit();
        initActiveTeamPics();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
