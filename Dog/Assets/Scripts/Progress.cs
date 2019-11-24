using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{

    public GameObject progressScreen, progressBtn;


    void Start()
    {
        progressScreen.SetActive(false);

    }

    public void showProgress()
    {
        progressScreen.SetActive(true);
        Time.timeScale = 0;
    }





    public void Resume()
    {
        progressScreen.SetActive(false);
        //Time.timeScale = 1;
    }




    // Update is called once per frame
    void Update()
    {

    }
}
