using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {



    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Options()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        
    }
    public void Credits()
    {
        SceneManager.LoadScene("CreditsScreen");
    }
    // Use this for initialization
    void Start () {
		
	}
    public void HomeBtn()
    {
        SceneManager.LoadScene("TitleScreen");
    }
	

    public void PlayBtn()
    {
        SceneManager.LoadScene("DogHouse");
    }
    public void InventoryBtn()
    {
        SceneManager.LoadScene("Inventory");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
