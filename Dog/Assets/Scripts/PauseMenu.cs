using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {


    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI, pauseButton;

	// Use this for initialization
	void Start () {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) { 
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
	}
    }
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game");
    }


}
