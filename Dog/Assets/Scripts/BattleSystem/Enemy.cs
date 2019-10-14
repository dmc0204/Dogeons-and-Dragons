using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
=======

>>>>>>> parent of 6cad998... Merge pull request #10 from dmc0204/Marcel-Branch
public class Enemy : MonoBehaviour
{
    
    private float health = 100;
<<<<<<< HEAD
    public Animator hitsquirrel;
=======
    
>>>>>>> parent of 6cad998... Merge pull request #10 from dmc0204/Marcel-Branch
    //below is for enemy to move towards position
    public Transform target;
    public float speed;
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
<<<<<<< HEAD
       
        //EnemyBody = this.GetComponent<Rigidbody2D>();
        
=======
        //EnemyBody = this.GetComponent<Rigidbody2D>();
>>>>>>> parent of 6cad998... Merge pull request #10 from dmc0204/Marcel-Branch
    }

    // Update is called once per frame
    void Update()
    {
        //below is for enenmy to move and how fast too
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
<<<<<<< HEAD
            //Debug.Log("Squirrels are infected with colliders!");
            speed = 0;
            hitsquirrel.SetTrigger("SquirrelDeath");

=======
            Debug.Log("Squirrels are infected with colliders!");
            
            //Destroy(this.gameObject);
>>>>>>> parent of 6cad998... Merge pull request #10 from dmc0204/Marcel-Branch
        }
    }

}
