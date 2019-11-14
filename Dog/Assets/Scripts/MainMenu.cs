using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {



    public void PlayGame()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void Options()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        
    }

    // Use this for initialization
    void Start () {
		
	}
    public void HomeBtn()
    {
        SceneManager.LoadScene("TitleScreen");
    }
	


    public void LevelsBtn()
    {
        SceneManager.LoadScene("Levels");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
