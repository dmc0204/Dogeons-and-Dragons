using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class chewyButtonController : MonoBehaviour
{
    public ChewableConfig myChew;
    public TextMeshProUGUI myText;

    public PlayerConfig myCoolPlayer;

    public void initPlayer(PlayerConfig newPlayer)
    {
        myCoolPlayer = newPlayer;
        countInit();
    }

    public void updateCount()
    {

        myText.text = myCoolPlayer.amount(myChew).ToString();

    }

    public void countInit()
    {
        myText.text = myCoolPlayer.amount(myChew).ToString();
    }
    // Start is called before the first frame update

    //TODO: make player event system to tell everythign what the player is
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
