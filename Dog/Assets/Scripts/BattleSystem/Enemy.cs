using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float health = 100;


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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
