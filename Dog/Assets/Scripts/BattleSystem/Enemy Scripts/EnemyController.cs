using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public EnemyStatsConfig myCoolVariable;

    //[System.NonSerialized]
    public float currentHP, currentAttack, currentDefense, currentSpeed, timeAbleToBasicAttack;

    public Slider healthbar;

    public SpriteRenderer enemyBodySpriteRenderer;

    public SpriteRenderer enemyArmSpriteRenderer;

    public Animator enemyAnimator;

    public Text name;

    [SerializeField] private VoidEvent enemyDied;
    [SerializeField] private VoidEvent giveMeEnemy;
    [SerializeField] private FloatEvent enemyAttacking;

    //functions to handle enemy death

    //Checks if enemy's HP is dead
    public bool isEnemyDead()
    {
        if (currentHP > 0)
            return false;
        else
        {
            return true;
        }
    }

    //calls enemy death animation
    public void died()
    {
        enemyDied.Raise();
        //TODO:write something in animator that links this call to the
        //wantNewEnemy call.  that way the new enemy only spawns when the 
        //old one's death animation finishes
    }

    //clears enemy sprites
    void nullEnemy()
    {
        enemyArmSpriteRenderer.sprite = null;
        enemyBodySpriteRenderer.sprite = null;
        currentAttack = 0;
        currentDefense = 0;
        currentSpeed = 0;
        currentHP = -1;
        name.text = "";
    }

    //asks if there are enemies left
    public void wantNewEnemy()
    {
        giveMeEnemy.Raise();
        Debug.Log("want new enemy event triggered");
    }

    // // // // // // // // // // // // //

    //functions to handle enemy spawn

    //load new enemy
    public void loadEnemy(EnemyStatsConfig poo)
    {
        myCoolVariable = poo;
        initializeEnemy();
    }

    //initialize values based off of currently loaded enemy
    public void initializeEnemy()
    {
        currentHP = myCoolVariable.MaxHealth;
        currentAttack = myCoolVariable.BaseAttack;
        currentDefense = myCoolVariable.BaseDefense;
        currentSpeed = myCoolVariable.BaseSpeed;
        enemyArmSpriteRenderer.sprite = myCoolVariable.arm;
        enemyBodySpriteRenderer.sprite = myCoolVariable.body;
        enemyAnimator = GetComponent<Animator>();
        enemyAnimator.runtimeAnimatorController = myCoolVariable.animator;
        name.text = myCoolVariable.enemyName;
        timeAbleToBasicAttack = Time.time + basicAttackCooldown();
    }

    // // // // // // // // // // // //

    //healthbar controller functions
    public void updateHealthBar()
    {
        healthbar.value = calcHealth();
    }

    public float calcHealth()
    {
        return currentHP / myCoolVariable.MaxHealth;
    }
    // // // // // // // // // // // //

    //START: battle functions
    public void calculateDamageFromAttack(float attack)
    {
        System.Random rand = new System.Random();
        double dubmult = rand.NextDouble() + 1;

        float multiplier = (float)dubmult;
        //Debug.Log (multiplier);
        float damage = (attack * multiplier) - currentDefense;
        if (damage < 0)
            damage = 1;
        takeDamage(damage);
        //TODO: tell level how much damage was taken
    }

    public void takeDamage(float damage)
    {
        currentHP -= damage;
        //updateHealthBar ();
    }

    //enemy autoattack cooldown
    public float basicAttackCooldown()
    {
        return 10 / currentSpeed;
    }

    //enemy autoattack
    void enemyAttack()
    {
        if ((Time.time > timeAbleToBasicAttack) && (!isEnemyDead()))
        {
            enemyAnimator.SetTrigger("attack");
            timeAbleToBasicAttack = Time.time + basicAttackCooldown();
            enemyAttacking.Raise(currentAttack);
        }
    }

    // // // // // // /// // // // // //

    //start and update
    void Start()
    {
        wantNewEnemy();
    }

    void Update()
    {
        enemyAttack();
        updateHealthBar();
        if (isEnemyDead())
        {
            died();
            nullEnemy();
            wantNewEnemy();
        }
    }
}