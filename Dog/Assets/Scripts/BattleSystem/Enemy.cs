using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{



    public Animator hitsquirrel;
    //below is for enemy to move towards position
    public Transform target;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
       
        //EnemyBody = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //below is for enemy to move and how fast too
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);


    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //Debug.Log("Squirrels are infected with colliders!");
            speed = 0;
            hitsquirrel.SetTrigger("slime_attack");

        }


    }

}
