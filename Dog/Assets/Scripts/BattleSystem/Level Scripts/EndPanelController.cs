using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanelController : MonoBehaviour
{
    public PlayerLevelContainer playerLevelContainer;
    public int bones;
    GameObject victory, defeat;

    public void levelEnd(int i)
    {
        playerLevelContainer.myCoolPlayer.changeBones(bones);
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

    public void getBones(int i)
    {
        bones = i;
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
