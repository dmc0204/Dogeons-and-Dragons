using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyContainer : MonoBehaviour
{
    public LevelConfig myCoolLevel;
    public EnemyStatsConfig myCoolVariable;

    //[System.NonSerialized]
    public float currentHP;

    public float currentAttack;

    public float currentDefense;

    public float currentSpeed;

    public Slider healthbar;

    float calcHealth()
    {
        return currentHP / myCoolVariable.MaxHealth;
    }

    void killEnemy()
    {
        // TODO: call death animation here and clear images
        //when finished, do
        currentHP = -1;
        currentAttack = -1;
        currentDefense = -1;
        currentSpeed = -1;
    }

    void spawnEnemy()
    {
        myCoolVariable = myCoolLevel.popOff();
        currentHP = myCoolVariable.MaxHealth;
        currentAttack = myCoolVariable.BaseAttack;
        currentDefense = myCoolVariable.BaseDefense;
        currentSpeed = myCoolVariable.BaseSpeed;
        healthbar.value = calcHealth();
    }

    bool EnemyDead()
    {
        if (currentHP < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void updateHealthBar()
    {
        healthbar.value = calcHealth();
    }

    void Start()
    {
        spawnEnemy();
    }

    void Update()
    {
        updateHealthBar();
        if (EnemyDead())
        {
            killEnemy();
            if (myCoolLevel.isEmpty())
            {
                //TODO: end level
            }
            else
            {
                spawnEnemy();
            }
        }
    }
}
