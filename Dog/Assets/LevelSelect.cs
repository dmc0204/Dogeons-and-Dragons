using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour {


    private const int buttonsPerRow = 1;
    private const int rowsPerPage = 7;

    private static int numColumns = 2*buttonsPerRow + 1;
    private static int numRows = 2*rowsPerPage + 1;

    private float gridBoxWidth = Screen.width / numColumns;
    private float gridBoxHeight = Screen.height / numRows;

    private static int numlevels = 10;
    //private static int completedLevels = 4;
    void OnGUI()
    {
        for (var i = 0; i < numlevels; i++)
        {


            int buttonRow = (int)i / buttonsPerRow;
            int gridRow = 2 * buttonRow+1;
            float top = gridBoxHeight * gridRow;

            int buttonIndex = 1 % buttonsPerRow;
            int gridColumn = 2 * buttonIndex + 1;
            float left = gridBoxWidth * gridColumn;

            var levelName = "Floor" + (i);
            if(GUI.Button(new Rect(left, top,gridBoxWidth+1,gridBoxHeight+1),levelName))
            {
                SceneManager.LoadScene(levelName);
            }
        }

    }


}
