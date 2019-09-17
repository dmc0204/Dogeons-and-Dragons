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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
