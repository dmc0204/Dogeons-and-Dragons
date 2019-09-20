using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public Button level2btn, level3btn;
    int LevelUnlocked;

    void Start()
    {
        LevelUnlocked = PlayerPrefs.GetInt("LevelUnlocked");
    }
    public void LoadThisLevel(int level)
    {
        SceneManager.LoadScene(level);

    }
    public void ResetPlayerPrefs()
    {
        level2btn.interactable = false;
        level3btn.interactable = false;
        PlayerPrefs.DeleteAll();
    }

}
