using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            Debug.Log("Squirrels are infected with colliders!");
            
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
