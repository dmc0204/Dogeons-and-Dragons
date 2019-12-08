/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_anim_attack : MonoBehaviour
{
    private Animator anim;

    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isAttacking = true;
            Debug.Log("Pressed attack");
            //anim.SetBool("isAttacking", true);
            anim.SetTrigger("swing");
        }
        //else
        //{
        //    isAttacking = false;
        //    //anim.SetBool("isAttacking", false);
        //}
    }
}
 */