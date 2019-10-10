using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogHit : MonoBehaviour
{

    //Player stats
    private float attack = 5;
    private float MaxHP = 50;
    private float hitRange = 1000;

    public KeyCode attack1;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if a certain input is clicked, hit, etc
        if (Input.GetKeyDown(attack1))
        {
            Attack();
        }
    }
    void Attack()
    {
        //check if we hit something
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 origin = transform.position;

        if (Physics.Raycast(origin,forward, out hit, hitRange))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                Debug.Log("Squirrels are not dry reptiles!");
                //hit.transform.gameObject.SendMessage("TakeDamage", 10);
            }
        }

    }
}
