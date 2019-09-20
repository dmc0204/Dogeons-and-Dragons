using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Credits : MonoBehaviour {
    //using boolean for button being clicked
    public Button credits;
    public bool buttonIsClicked;
    void start()
    {
        Button CreditsBtn = credits.GetComponent<Button>();
        CreditsBtn.onClick.AddListener(TaskOnClick);

    }
    void TaskOnClick()
    {
        Debug.Log("Credits goes to Oakland Express!");
        buttonIsClicked = true;
    }
    private void OnGUI()
    {

    }

}
