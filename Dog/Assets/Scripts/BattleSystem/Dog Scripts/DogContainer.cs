using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DogContainer : MonoBehaviour
{
    public LevelConfig myCoolLevel;
    public DogStatsConfig activeDog;

    public float currentHP;

    public float currentAttack;

    public float currentDefense;

    public float currentSpeed;

    public Slider healthbar;

    public Animator dogAnimator;

    public SpriteRenderer dogBodySpriteRenderer;
    public SpriteRenderer dogHeadSpriteRenderer;
    public SpriteRenderer dogFLeftSpriteRenderer;
    public SpriteRenderer dogFRightSpriteRenderer;
    public SpriteRenderer dogBLeftSpriteRenderer;
    public SpriteRenderer dogBRightSpriteRenderer;

    float calcHealth()
    {
        return currentHP / activeDog.MaxHealth;
    }

    void updateHealthBar()
    {
        healthbar.value = calcHealth();
    }

    void spawnDog()
    {
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
        dogAnimator = GetComponent<Animator>();
        dogAnimator.runtimeAnimatorController = activeDog.animator;
        healthbar.value = calcHealth();
    }

    void Start()
    {
        spawnDog();
    }

    void Update()
    {
        updateHealthBar();
    }
}
