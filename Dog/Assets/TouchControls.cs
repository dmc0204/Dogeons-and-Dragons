using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

    private PlayerController Player;

	// Use this for initialization
	void Start () {
        Player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void UpButton()
    {
        Player.Jump();
    }
}
