﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    
    private float health = 100;
=======
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{



>>>>>>> Stashed changes
    public Animator hitsquirrel;
    //below is for enemy to move towards position
    public Transform target;
    public float speed;
<<<<<<< Updated upstream
    void TakeDamage(int damageAmount)
    {
        health = health - damageAmount;

        // We should also check if the health is still greater than 0 
        // in order to determine whether enemy is still alive or not

        if (health < 0)
        {
            // This enemy is supposed to be dead now.
        }
    }
=======

>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
       
        //EnemyBody = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        //below is for enenmy to move and how fast too
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            //Debug.Log("Squirrels are infected with colliders!");
            speed = 0;
            hitsquirrel.SetTrigger("SquirrelDeath");

        }
=======
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


>>>>>>> Stashed changes
    }

}
