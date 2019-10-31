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

    public SpriteRenderer enemyBodySpriteRenderer;

    public SpriteRenderer enemyArmSpriteRenderer;

    public Animator enemyAnimator;

    public Text name;

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
        enemyArmSpriteRenderer.sprite = null;
        enemyBodySpriteRenderer.sprite = null;
        name.text = null;
    }

    void spawnEnemy()
    {
        myCoolVariable = myCoolLevel.getNext();
        currentHP = myCoolVariable.MaxHealth;
        currentAttack = myCoolVariable.BaseAttack;
        currentDefense = myCoolVariable.BaseDefense;
        currentSpeed = myCoolVariable.BaseSpeed;
        enemyArmSpriteRenderer.sprite = myCoolVariable.arm;
        enemyBodySpriteRenderer.sprite = myCoolVariable.body;
        enemyAnimator = GetComponent<Animator>();
        enemyAnimator.runtimeAnimatorController = myCoolVariable.animator;
        healthbar.value = calcHealth();
        name.text = myCoolVariable.enemyName;
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

    public void calculateDamageFromAttack(float attack)
    {
        System.Random rand = new System.Random();
        double dubmult = rand.NextDouble() + 1;

        float multiplier = (float)dubmult;
        Debug.Log(multiplier);
        float damage = (attack * multiplier) - currentDefense;
        takeDamage(damage);
    }

    void takeDamage(float damage)
    {
        currentHP -= damage;
    }

    void Start()
    {
        myCoolLevel.initializeCount();
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