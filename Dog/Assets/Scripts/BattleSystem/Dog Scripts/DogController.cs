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

    public bool chewableActive;

    //public Slider healthbar;

    //public Text name;

    public Animator dogAnimator;

    public SpriteRenderer dogBodySpriteRenderer, dogHeadSpriteRenderer, dogFLeftSpriteRenderer, dogFRightSpriteRenderer, dogBLeftSpriteRenderer, dogBRightSpriteRenderer;

    public Transform dogBodyTransform, dogHeadTransform, dogFLeftTransform, dogFRightTransform, dogBLeftTransform, dogBRightTransform;
    public float timeAbleToBasicAttack, timeWhenChewableWearsOff;

    public ChewableConfig activeChewable;
    [SerializeField] private FloatEvent attacking, hpSaving, dogHPUpdating, dogAttackTiming;
    [SerializeField] private IntEvent switching;
    [SerializeField] private VoidEvent dying;

    public Object deathExplodeRef;
    public Object chewableEffectRef;

    float calcHealth()
    {
        return currentHP / activeDog.MaxHealth;
    }

    void updateHealthBar()
    {
        dogHPUpdating.Raise(calcHealth());
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



        //healthbar.value = calcHealth();
        //name.text = activeDog.dogName;
        timeAbleToBasicAttack = Time.time + basicAttackCooldown();
        chewableActive = false;
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
            Debug.Log("ITS ON COOLDOWN  Time is " + Time.time + ", able to attack at " + timeAbleToBasicAttack);
        }
    }

    public float basicAttackCooldown()
    {
        return 10 / currentSpeed;
    }

    public float calcTime()
    {
        float percentTime = ((timeAbleToBasicAttack - Time.time) / basicAttackCooldown());
        if (percentTime < 0)
        {
            percentTime = 0;
        }
        return 1 - percentTime;
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
        dogAnimator.SetTrigger("damaged");

        if (currentHP < 0)
        {
            currentHP = 0;
            doggyDied();
        }
        //updateHealthBar ();
    }

    //function for dog switching
    public void switchDog(int number)
    {
        timeWhenChewableWearsOff = Time.time;
        hpSaving.Raise(currentHP);
        switching.Raise(number);
        Debug.Log("dog switch events called");
    }

    public void hpReceiving(float num)
    {
        loadedHP = num;
    }

    //handling dog death
    public void doggyDied()
    {
        // create smoke effect at body position on death
        if (deathExplodeRef != null)
        {
            GameObject deathExplosion = (GameObject)Instantiate(deathExplodeRef);
            deathExplosion.transform.position = new Vector3(dogBodyTransform.position.x, dogBodyTransform.position.y, dogBodyTransform.position.z);
        }

        dogBodySpriteRenderer.sprite = null;
        dogHeadSpriteRenderer.sprite = null;
        dogFLeftSpriteRenderer.sprite = null;
        dogFRightSpriteRenderer.sprite = null;
        dogFLeftSpriteRenderer.sprite = null;
        dogBRightSpriteRenderer.sprite = null;
        dogBLeftSpriteRenderer.sprite = null;
        dying.Raise();
    }

    public void spawnChewableParticle(Color particleColor)
    {
        if (chewableEffectRef != null)
        {
            GameObject particleEffect = (GameObject)Instantiate(chewableEffectRef);
            // spawns at units feet
            particleEffect.transform.position = new Vector3(dogBodyTransform.position.x,
                                                        dogBodyTransform.position.y - (2 * dogBRightSpriteRenderer.bounds.extents.y),
                                                        dogBodyTransform.position.z);
            ParticleSystem.MainModule settings = particleEffect.GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(particleColor);
        }
    }

    //chewables

    public void useChewable(ChewableConfig chewable)
    {
        if (chewable.increaseAttack)
        {
            chewableActive = true;
            activeChewable = chewable;
            timeWhenChewableWearsOff = Time.time + chewable.time;
            upAttack(chewable.value);
            spawnChewableParticle(new Color32(245, 89, 244, 255)); // purple
        }
        if (chewable.increaseDefense)
        {
            chewableActive = true;
            activeChewable = chewable;
            timeWhenChewableWearsOff = Time.time + chewable.time;
            upDefense(chewable.value);
            spawnChewableParticle(new Color32(89, 230, 245, 255)); // blue
        }
        if (chewable.increaseSpeed)
        {
            chewableActive = true;
            activeChewable = chewable;
            timeWhenChewableWearsOff = Time.time + chewable.time;
            upSpeed(chewable.value);
            spawnChewableParticle(new Color32(245, 204, 89, 255)); // orange
        }
        if (chewable.increaseHealth)
        {
            upHealth(chewable.value);
            spawnChewableParticle(new Color32(103, 245, 89, 255)); // green
        }
    }

    public void endChewableChanges()
    {
        if (chewableActive)
        {
            if (Time.time > timeWhenChewableWearsOff)
            {
                if (activeChewable.increaseAttack)
                {
                    upAttack(activeChewable.value * -1);
                }
                if (activeChewable.increaseDefense)
                {
                    upDefense(activeChewable.value * -1);
                }
                if (activeChewable.increaseSpeed)
                {
                    upSpeed(activeChewable.value * -1);
                }
                chewableActive = false;
            }
        }

    }

    // // // // // // // //// // // // // // // //
    //stat changes
    public void upAttack(float value)
    {
        currentAttack += value;
    }

    public void upDefense(float value)
    {
        currentDefense += value;
    }

    public void upSpeed(float value)
    {
        currentSpeed += value;
    }

    public void upHealth(float value)
    {
        currentHP += value;
        if (currentHP > activeDog.MaxHealth)
        {
            currentHP = activeDog.MaxHealth;
        }
    }
    // // // // // // // // // // // // // // // //

    void Start()
    {
        switching.Raise(0);
        hpSaving.Raise(currentHP);
    }

    void Update()
    {
        updateHealthBar();
        dogAttackTiming.Raise(calcTime());
        endChewableChanges();
    }
}