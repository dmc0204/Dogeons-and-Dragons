using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABtnHit : MonoBehaviour
{

    public Animator anim;
    public KeyCode attack1;

public void Update()
    {
        if (Input.GetKeyDown(attack1)) {
            Debug.Log("Squirrels are reptiles!");
            anim.SetTrigger("PlayerAttack");
        }
    }


}
