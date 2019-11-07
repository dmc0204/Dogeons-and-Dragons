using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    public EnemyStatsConfig myCoolVariable;

    //[System.NonSerialized]
    public float currentHP, currentAttack, currentDefense, currentSpeed;

    public Slider healthbar;

    public SpriteRenderer enemyBodySpriteRenderer;

    public SpriteRenderer enemyArmSpriteRenderer;

    public Animator enemyAnimator;

    public Text name;

    [SerializeField] private VoidEvent enemyDied;
    [SerializeField] private VoidEvent askIfEnemiesLeft;
    [SerializeField] private VoidEvent getEnemy;

    float calcHealth () {
        return currentHP / myCoolVariable.MaxHealth;
    }

    void killEnemy () {
        enemyDied.Raise ();
    }

    void needEnemy () {
        getEnemy.Raise ();
    }

    void spawnEnemy () {
        currentHP = myCoolVariable.MaxHealth;
        currentAttack = myCoolVariable.BaseAttack;
        currentDefense = myCoolVariable.BaseDefense;
        currentSpeed = myCoolVariable.BaseSpeed;
        enemyArmSpriteRenderer.sprite = myCoolVariable.arm;
        enemyBodySpriteRenderer.sprite = myCoolVariable.body;
        enemyAnimator = GetComponent<Animator> ();
        enemyAnimator.runtimeAnimatorController = myCoolVariable.animator;
        name.text = myCoolVariable.enemyName;
    }

    bool EnemyDead () {
        if (currentHP < 0) {

            return true;
        } else {
            return false;
        }
    }

    void updateHealthBar () {
        healthbar.value = calcHealth ();
    }

    public void calculateDamageFromAttack (float attack) {
        System.Random rand = new System.Random ();
        double dubmult = rand.NextDouble () + 1;

        float multiplier = (float) dubmult;
        Debug.Log (multiplier);
        float damage = (attack * multiplier) - currentDefense;
        takeDamage (damage);
    }

    void takeDamage (float damage) {
        currentHP -= damage;
    }

    void Start () {
        spawnEnemy ();
    }

    void Update () {
        updateHealthBar ();
        if (EnemyDead ()) {
            killEnemy ();

        }
    }
}