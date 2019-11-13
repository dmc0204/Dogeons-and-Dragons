using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogController : MonoBehaviour
{
    //public LevelConfig myCoolLevel;
    public DogStatsConfig activeDog;

    public float currentHP, loadedHP;

    public float currentAttack;

    public float currentDefense;

    public float currentSpeed;

    public Slider healthbar;

    public Text name;

    public Animator dogAnimator;

    public SpriteRenderer dogBodySpriteRenderer, dogHeadSpriteRenderer, dogFLeftSpriteRenderer, dogFRightSpriteRenderer, dogBLeftSpriteRenderer, dogBRightSpriteRenderer;

    public Transform dogBodyTransform, dogHeadTransform, dogFLeftTransform, dogFRightTransform, dogBLeftTransform, dogBRightTransform;
    public float timeAbleToBasicAttack;
    [SerializeField] private FloatEvent attacking, hpSaving;
    [SerializeField] private IntEvent switching;

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
        //initializes stats
        if (loadedHP == -1)
        {
            currentHP = activeDog.MaxHealth;
        }
        else
        {
            currentHP = loadedHP;
        }
        currentAttack = activeDog.BaseAttack;
        currentDefense = activeDog.BaseDefense;
        currentSpeed = activeDog.BaseSpeed;

        //initializes sprites
        dogBodySpriteRenderer.sprite = activeDog.body;
        dogHeadSpriteRenderer.sprite = activeDog.head;
        dogFLeftSpriteRenderer.sprite = activeDog.FLleg;
        dogFRightSpriteRenderer.sprite = activeDog.FRleg;
        dogBLeftSpriteRenderer.sprite = activeDog.BLleg;
        dogBRightSpriteRenderer.sprite = activeDog.BRleg;
        dogBodyTransform.localPosition = new Vector3(activeDog.bodyPositionX, activeDog.bodyPositionY, activeDog.bodyPositionZ);
        dogHeadTransform.localPosition = new Vector3(activeDog.headPositionX, activeDog.headPositionY, activeDog.headPositionZ);
        dogFLeftTransform.localPosition = new Vector3(activeDog.FLlegPositionX, activeDog.FLlegPositionY, activeDog.FLlegPositionZ);
        dogFRightTransform.localPosition = new Vector3(activeDog.FRlegPositionX, activeDog.FRlegPositionY, activeDog.FRlegPositionZ);
        dogBLeftTransform.localPosition = new Vector3(activeDog.BLlegPositionX, activeDog.BLlegPositionY, activeDog.BLlegPositionZ);
        dogBRightTransform.localPosition = new Vector3(activeDog.BRlegPositionX, activeDog.BRlegPositionY, activeDog.BRlegPositionZ);
        dogAnimator = GetComponent<Animator>();
        dogAnimator.runtimeAnimatorController = activeDog.animator;



        healthbar.value = calcHealth();
        name.text = activeDog.dogName;
        timeAbleToBasicAttack = Time.time;
    }

    public void loadDog(DogStatsConfig newdoggo)
    {
        activeDog = newdoggo;
        spawnDog();
    }

    // // // // // // // // //
    //battle functions
    void dogAttack()
    {
        if (Time.time > timeAbleToBasicAttack)
        {
            timeAbleToBasicAttack = Time.time + basicAttackCooldown();
            attacking.Raise(currentAttack);
            dogAnimator.SetTrigger("attack");
            Debug.Log("attack good");
        }
        else
        {
            Debug.Log("ITS ON COOLDOWN");
        }
    }

    public float basicAttackCooldown()
    {
        return 10 / currentSpeed;
    }

    public void calculateDamage(float attack)
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
        if (currentHP < 0)
        {
            currentHP = 0;
        }
        //updateHealthBar ();
    }

    //function for dog switching
    public void switchDog(int number)
    {
        hpSaving.Raise(currentHP);
        switching.Raise(number);
        Debug.Log("dog switch events called");
    }

    public void hpReceiving(float num)
    {
        loadedHP = num;
    }

    void Start()
    {
        switching.Raise(0);
        hpSaving.Raise(currentHP);
    }

    void Update()
    {
        updateHealthBar();
    }
}