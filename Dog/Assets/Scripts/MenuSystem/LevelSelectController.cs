using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{
    public PlayerLevelContainer hackyWorkaround;
    public PlayerConfig myPlayer;
    public GameObject levelContainer;

    public Sprite unknown;
    public LevelConfig[] levels;
    public Image[] yourDogs;

    [SerializeField] PlayerEvent playerSetting;

    //inits and sends player
    public void initPlayer()
    {
        playerSetting.Raise(myPlayer);
    }
    //loads the level into the plc
    public void loadLevel(int i)
    {
        hackyWorkaround.myCoolPlayer = myPlayer;
        hackyWorkaround.myCoolLevel = levels[i];
        if (myPlayer.currentLevel >= levels[i].levelNumber)
        {
            bool hasDog = false;
            for (int j = 0; j < myPlayer.yourTeam.Length; j++)
            {
                if (myPlayer.yourTeam[j] != null)
                {
                    hasDog = true;
                }
            }
            if (hasDog)
            {
                openTheGame();
            }

        }
    }

    //loads your dogs pictures
    public void initActiveTeamPics()
    {
        for (int i = 0; i < hackyWorkaround.myCoolPlayer.yourTeam.Length; i++)
        {
            if (hackyWorkaround.myCoolPlayer.yourTeam[i] == null)
            {
                yourDogs[i].sprite = null;
                yourDogs[i].color = new Color(0, 0, 0, 0);
            }
            else
            {
                yourDogs[i].sprite = hackyWorkaround.myCoolPlayer.yourTeam[i].head;
                yourDogs[i].color = new Color(1, 1, 1, 1);
            }
        }

    }

    public void initAvailableLevels()
    {
        Image[] bgs = levelContainer.GetComponentsInChildren<Image>();
        for (int i = 0; i < bgs.Length; i++)
        {
            if (bgs.Length - i - 1 > hackyWorkaround.myCoolPlayer.currentLevel)
            {
                bgs[i].sprite = unknown;
            }
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
        initPlayer();
        initActiveTeamPics();
        initAvailableLevels();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
