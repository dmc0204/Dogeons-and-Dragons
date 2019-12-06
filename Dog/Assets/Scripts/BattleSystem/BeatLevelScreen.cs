using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatLevelScreen : MonoBehaviour
{
    public LevelConfig myCoolLevel;
    public GameObject win, wincondition;

    // Start is called before the first frame update


    void Start()
    {
        WinScreen();

    }



    // Update is called once per frame
    void Update()
    {

    }

    void WinScreen()
    {
        win.SetActive(true);
        wincondition.SetActive(true);
        Time.timeScale = 0;

    }

}
