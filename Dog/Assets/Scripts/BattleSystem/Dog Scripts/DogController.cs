using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogController : MonoBehaviour {
    //public LevelConfig myCoolLevel;
    public DogStatsConfig activeDog;

    public float currentHP;

    public float currentAttack;

    public float currentDefense;

    public float currentSpeed;

    public Slider healthbar;

    public Text name;

    public Animator dogAnimator;

    public SpriteRenderer dogBodySpriteRenderer;
    public SpriteRenderer dogHeadSpriteRenderer;
    public SpriteRenderer dogFLeftSpriteRenderer;
    public SpriteRenderer dogFRightSpriteRenderer;
    public SpriteRenderer dogBLeftSpriteRenderer;
    public SpriteRenderer dogBRightSpriteRenderer;

    public float timeAbleToBasicAttack;
    [SerializeField] private FloatEvent attacking;

    float calcHealth () {
        return currentHP / activeDog.MaxHealth;
    }

    void updateHealthBar () {
        healthbar.value = calcHealth ();
    }

    void spawnDog () {
        //myCoolVariable = myCoolLevel.getNext();
        currentHP = activeDog.MaxHealth;
        currentAttack = activeDog.BaseAttack;
        currentDefense = activeDog.BaseDefense;
        currentSpeed = activeDog.BaseSpeed;
        dogBodySpriteRenderer.sprite = activeDog.body;
        dogHeadSpriteRenderer.sprite = activeDog.head;
        dogFLeftSpriteRenderer.sprite = activeDog.FLleg;
        dogFRightSpriteRenderer.sprite = activeDog.FRleg;
        dogBLeftSpriteRenderer.sprite = activeDog.BLleg;
        dogBRightSpriteRenderer.sprite = activeDog.BRleg;
        dogAnimator = GetComponent<Animator> ();
        dogAnimator.runtimeAnimatorController = activeDog.animator;
        healthbar.value = calcHealth ();
        name.text = activeDog.dogName;
        timeAbleToBasicAttack = Time.time;
    }

    // // // // // // // // //
    //battle functions
    void dogAttack () {
        if (Time.time > timeAbleToBasicAttack) {
            timeAbleToBasicAttack = Time.time + basicAttackCooldown ();
            attacking.Raise (currentAttack);
            dogAnimator.SetTrigger ("attack");
            Debug.Log ("attack good");
        } else {
            Debug.Log ("ITS ON COOLDOWN");
        }
    }

    public float basicAttackCooldown () {
        return 10 / currentSpeed;
    }

    public void calculateDamage (float attack) {
        System.Random rand = new System.Random ();
        double dubmult = rand.NextDouble () + 1;

        float multiplier = (float) dubmult;
        //Debug.Log (multiplier);
        float damage = (attack * multiplier) - currentDefense;
        if (damage < 0)
            damage = 1;
        takeDamage (damage);
        //TODO: tell level how much damage was taken
    }

    public void takeDamage (float damage) {
        currentHP -= damage;
        //updateHealthBar ();
    }

    void Start () {
        spawnDog ();
    }

    void Update () {
        updateHealthBar ();
    }
}