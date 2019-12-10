using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonesController : MonoBehaviour
{
    public PlayerConfig myCoolPlayer;

    public TextMeshProUGUI texty;

    public void updateBones()
    {
        texty.text = myCoolPlayer.currency.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        updateBones();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
