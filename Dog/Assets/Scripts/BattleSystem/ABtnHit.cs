using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABtnHit : MonoBehaviour
{
    //public GameObject ABtn;
    public Animator anim;
    //public KeyCode attack1;


    bool AButtonHit = false;

    void Start()
    {
        

    }

public void Update()
    {
        if (Input.GetButton("Fire1")) {
            //Debug.Log("Squirrels are reptiles!");
            //PlayerAttack here is teh parameter in Unity
            anim.SetTrigger("PlayerAttack");


        }
    }


}
