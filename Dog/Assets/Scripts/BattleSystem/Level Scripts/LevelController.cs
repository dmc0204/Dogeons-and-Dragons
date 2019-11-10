﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private float damageTaken, damageDealt;
    //TODO:funcs to track these, get passed numbers

    private bool dogDied;

    //public int count;
    public LevelConfig newLevel;
    public EnemyStatsConfig[] enemies;

    public Queue<EnemyStatsConfig> NMEs;
    public DogStatsConfig[] dogs;

    public Sprite background;
    public SpriteRenderer backgroundSpriteRenderer;
    [SerializeField] private EnemyStatsEvent gettingEnemyStats;

    //initializes level values
    public void initialize()
    {
        damageTaken = 0;
        damageDealt = 0;
        //count = 0;
        enemies = newLevel.enemies;
        dogs = newLevel.yourTeam;
        background = newLevel.background;
        backgroundSpriteRenderer = GetComponent<SpriteRenderer>();
        backgroundSpriteRenderer.sprite = background;
    }

    //initializes queue
    public void initQueue()
    {
        NMEs = new Queue<EnemyStatsConfig>(enemies);
    }

    //functions to handle spawning new enemies
    //checks if there are enemies left to spawn
    public bool enemiesIsEmpty()
    {
        if (NMEs.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //returns next enemy in list
    public EnemyStatsConfig getNext()
    {
        EnemyStatsConfig toReturn;
        toReturn = NMEs.Dequeue();
        return toReturn;
    }

    void enemyDied()
    {
        //Debug.Log ("enemydied check triggered");
        if (!enemiesIsEmpty())
        {
            gettingEnemyStats.Raise(getNext());
        }
        else
        {
            Debug.Log("its empty!");
            endLevel();
        }
    }
    // // // // // // // // // // // // // // // // // //

    public void endLevel()
    {
        //TODO:end the level with this function
        //stop time
        //call up level end panel
        //display stats
        //calculate rewards
        //write to player object
    }

    // Start is called before the first frame update
    void Start()
    {
        initialize();
        initQueue();
    }

    // Update is called once per frame
    void Update()
    {

    }
}