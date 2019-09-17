using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dPad : MonoBehaviour {

    public Transform Player;
    public float speed = 5.0f;
    public bool touchStart = false;

    private Vector2 pointA;
    private Vector2 pointB;

    public Transform outerCircle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //not for touch below, arrow keys used instead here
        //moveCharacter(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        //this will be used for touch
        if (Input.GetMouseButtonDown(0))
        {
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }

	}


    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * -1);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        Player.Translate(direction * speed * Time.deltaTime);
    }

}
