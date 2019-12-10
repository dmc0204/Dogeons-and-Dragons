using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndPanelController : MonoBehaviour
{
    public PlayerLevelContainer playerLevelContainer;
    public int bones;
    public GameObject victory, defeat;

    public TextMeshProUGUI boner;
    public void levelEnd(int i)
    {
        victory.SetActive(false);
        defeat.SetActive(false);
        playerLevelContainer.myCoolPlayer.changeBones(bones);
        if (playerLevelContainer.myCoolLevel.levelNumber > playerLevelContainer.myCoolPlayer.currentLevel)
        {
            playerLevelContainer.myCoolPlayer.currentLevel = playerLevelContainer.myCoolLevel.levelNumber;
        }
        boner.text = bones.ToString();
        if (i == 1)
        {
            victory.SetActive(true);
            defeat.SetActive(false);
        }
        else if (i == 0)
        {
            victory.SetActive(false);
            defeat.SetActive(true);
        }
    }

    public void getBones(int j)
    {
        bones = j;
        if (bones < 0)
        {
            bones = 0;
        }
    }

    public void back()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void next()
    {
        if (playerLevelContainer.myCoolLevel.nextLevel != null)
        {
            playerLevelContainer.myCoolLevel = playerLevelContainer.myCoolLevel.nextLevel;
        }
        SceneManager.LoadScene("Levels");
    }

    public void retry()
    {
        SceneManager.LoadScene("Levels");
    }




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
