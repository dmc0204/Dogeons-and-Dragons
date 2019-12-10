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

    //public bool chewableActive;

    private int chargeCount;

    //public Slider healthbar;

    //public Text name;

    public Animator dogAnimator;

    public SpriteRenderer dogBodySpriteRenderer, dogHeadSpriteRenderer, dogFLeftSpriteRenderer, dogFRightSpriteRenderer, dogBLeftSpriteRenderer, dogBRightSpriteRenderer, dogAccesorySpriteRenderer;

    public Transform dogBodyTransform, dogHeadTransform, dogFLeftTransform, dogFRightTransform, dogBLeftTransform, dogBRightTransform, dogAccesoryTransform;
    private float timeAbleToBasicAttack, timeWhenChewableWearsOff;

    //private ChewableConfig activeChewable;

    private SortedDictionary<float, effects> activeEffects;

    public Object deathExplodeRef;
    public Object chewableEffectRef;
    [SerializeField] private FloatEvent attacking, damageTaking, hpSaving, dogHPUpdating, dogAttackTiming;
    [SerializeField] private IntEvent switching;
    [SerializeField] private VoidEvent dying, specialUsing;
    [SerializeField] private statChangeEvent statChanging;

    public void spawnDog()
    {
        dogAnimator.runtimeAnimatorController = activeDog.animator;
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
        activeEffects = new SortedDictionary<float, effects>();

        //initializes sprites
        dogBodySpriteRenderer.sprite = activeDog.body;
        dogHeadSpriteRenderer.sprite = activeDog.head;
        dogFLeftSpriteRenderer.sprite = activeDog.FLleg;
        dogFRightSpriteRenderer.sprite = activeDog.FRleg;
        dogBLeftSpriteRenderer.sprite = activeDog.BLleg;
        dogBRightSpriteRenderer.sprite = activeDog.BRleg;
        dogAccesorySpriteRenderer.sprite = activeDog.accesory;
        //inits transforms
        dogBodyTransform.localPosition = new Vector3(activeDog.bodyPosition.x, activeDog.bodyPosition.y, activeDog.bodyPosition.z);
        dogHeadTransform.localPosition = new Vector3(activeDog.headPosition.x, activeDog.headPosition.y, activeDog.headPosition.z);
        dogFLeftTransform.localPosition = new Vector3(activeDog.FLlegPosition.x, activeDog.FLlegPosition.y, activeDog.FLlegPosition.z);
        dogFRightTransform.localPosition = new Vector3(activeDog.FRlegPosition.x, activeDog.FRlegPosition.y, activeDog.FRlegPosition.z);
        dogBLeftTransform.localPosition = new Vector3(activeDog.BLlegPosition.x, activeDog.BLlegPosition.y, activeDog.BLlegPosition.z);
        dogBRightTransform.localPosition = new Vector3(activeDog.BRlegPosition.x, activeDog.BRlegPosition.y, activeDog.BRlegPosition.z);
        dogAccesoryTransform.localPosition = new Vector3(activeDog.accesoryPosition.x, activeDog.accesoryPosition.y, activeDog.accesoryPosition.z);
        //dogAnimator = GetComponent<Animator>();


        //healthbar.value = calcHealth();
        //name.text = activeDog.dogName;
        chargeCount = 0;
        timeAbleToBasicAttack = Time.time + basicAttackCooldown();
        //chewableActive = false;
    }

    //this function sets your current dog as active and calls the previous spawndog function
    public void loadDog(DogStatsConfig newdoggo)
    {
        activeDog = newdoggo;
        spawnDog();
    }

    // // // // // // // // //
    //battle functions
    void dogAttack()
    {
        //checks if you can attack
        if (Time.time > timeAbleToBasicAttack)
        {
            //sets next time you can attack
            timeAbleToBasicAttack = Time.time + basicAttackCooldown();
            //tells everyone you are attacking
            attacking.Raise(currentAttack);
            dogAnimator.SetTrigger("attack");
            Debug.Log("attack good");
            //each attack adds one to charge
            chargeCount++;
        }
        else
        {
            Debug.Log("ITS ON COOLDOWN  Time is " + Time.time + ", able to attack at " + timeAbleToBasicAttack);
        }
    }

    //small func to calculate how often you can basic attack.  this excellent equation was thought of by olivia, what would we do without her?
    public float basicAttackCooldown()
    {
        return 10 / currentSpeed;
    }

    //func for getting percent time for the basic attack meter.  this is for the display up top
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
        damageTaking.Raise(damage);

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

    //special attack
    public void specialAttack()
    {
        //checks if you can use youur special
        if (chargeCount >= 3)
        {
            //instantiates the effects
            // // // // // //effects selfEffects = new effects(), enemyEffects = new effects();
            //these are fucking flags so we don't do random shit we dont need
            //bool don = false, john = false;

            //these basically check if the special does the thing, who it does it to and sets the flag
            foreach (special special in activeDog.specialEffects)
            {
                effects newEffect = new effects(special.type, special.value);
                if (special.targets == target.enemy)
                {
                    statChange marcel = new statChange();
                    marcel.duration = special.duration;
                    marcel.effects = newEffect;
                    statChanging.Raise(marcel);
                }
                else if (special.targets == target.self)
                {
                    applyEffect(special.duration, newEffect);
                }
            }
            chargeCount = 0;
            specialUsing.Raise();

            /* if (activeDog.specialDealsDamage.onEnemy)
            {
                enemyEffects.damageValue = activeDog.specialDealsDamage.value;
                don = true;
            }
            if (activeDog.specialDealsDamage.onSelf)
            {
                selfEffects.damageValue = activeDog.specialDealsDamage.value;
                john = true;
            }
            if (activeDog.specialIncreasesHealth.onEnemy)
            {
                enemyEffects.healthValue = activeDog.specialIncreasesHealth.value;
                don = true;
            }
            if (activeDog.specialIncreasesHealth.onSelf)
            {
                selfEffects.healthValue = activeDog.specialIncreasesHealth.value;
                john = true;
            }

            if (activeDog.specialIncreasesAttack.onEnemy)
            {
                enemyEffects.attackValue = activeDog.specialIncreasesAttack.value;
                don = true;
            }
            if (activeDog.specialIncreasesAttack.onSelf)
            {
                selfEffects.attackValue = activeDog.specialIncreasesAttack.value;
                john = true;
            }
            if (activeDog.specialIncreasesDefense.onEnemy)
            {
                enemyEffects.defenseValue = activeDog.specialIncreasesDefense.value;
                don = true;
            }
            if (activeDog.specialIncreasesDefense.onSelf)
            {
                selfEffects.defenseValue = activeDog.specialIncreasesDefense.value;
                john = true;
            }
            if (activeDog.specialIncreasesSpeed.onEnemy)
            {
                enemyEffects.speedValue = activeDog.specialIncreasesSpeed.value;
                don = true;
            }
            if (activeDog.specialIncreasesSpeed.onSelf)
            {
                selfEffects.speedValue = activeDog.specialIncreasesSpeed.value;
                john = true;
            }
            //does special effects on self
            if (john)
            {
                applyEffect(activeDog.specialDuration, selfEffects);
            }
            //does special effects on enemy
            if (don)
            {

            }
        } */

        }
    }

    // funcs for calculating health
    float calcHealth()
    {
        return currentHP / activeDog.MaxHealth;
    }

    void updateHealthBar()
    {
        dogHPUpdating.Raise(calcHealth());
    }

    //needs this to remember what the other dogs hp are
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
        activeEffects.Clear();
        dying.Raise();
    }

    public void stop()
    {
        deathExplodeRef = null;
    }

    public void spawnChewableParticle(Color particleColor)
    {
        Debug.Log("spawning stat change particles");
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
    //converts chewable to an "effects" and calls the apply effect
    public void useChewable(ChewableConfig chewable)
    {
        foreach (special chew in chewable.chewEffects)
        {
            effects newEffect = new effects(chew.type, chew.value);
            applyEffect(chew.duration, newEffect);
        }
        Debug.Log("chewable used");
        /* effects newEffect = new effects();
        if (chewable.increaseAttack.yes)
        {
            newEffect.attackValue = chewable.increaseAttack.value;
            //upAttack(chewable.value);
        }
        if (chewable.increaseDefense.yes)
        {

            newEffect.defenseValue = chewable.increaseDefense.value;
            //upDefense(chewable.value);
        }
        if (chewable.increaseSpeed.yes)
        {

            newEffect.speedValue = chewable.increaseSpeed.value;
            //upSpeed(chewable.value);
        }
        if (chewable.increasesHealth.yes)
        {

            newEffect.healthValue = chewable.increasesHealth.value;
        }
        applyEffect(chewable.chewableDuration, newEffect); */
    }

    //unpacks incoming stat changes and applies them
    public void unpackStatChange(statChange loi)
    {
        applyEffect(loi.duration, loi.effects);
    }

    //adding active effects to sorted dictionary and apply them
    public void applyEffect(float duration, effects newEffect)
    {
        float timeSpecial = Time.time + duration;
        bool joe = false;
        //need to do this shit because i'm using time as a key.  probably bad coding practice, but im on a time crunch
        while (activeEffects.ContainsKey(timeSpecial))
        {
            timeSpecial += 0.1f;
        }
        if (newEffect.HealthValue != 0)
        {
            spawnChewableParticle(new Color32(103, 245, 89, 255)); // green
            upHealth(newEffect.HealthValue);
        }
        if (newEffect.DamageValue != 0)
        {
            upHealth(newEffect.DamageValue);
        }
        if (newEffect.AttackValue != 0)
        {
            spawnChewableParticle(new Color32(245, 89, 244, 255)); // purple
            upAttack(newEffect.AttackValue);
            joe = true;
        }
        if (newEffect.DefenseValue != 0)
        {
            Debug.Log("applying defense effect");
            spawnChewableParticle(new Color32(89, 230, 245, 255)); // blue
            upDefense(newEffect.DefenseValue);
            joe = true;
        }
        if (newEffect.SpeedValue != 0)
        {
            spawnChewableParticle(new Color32(245, 204, 89, 255)); // orange
            upSpeed(newEffect.DefenseValue);
            joe = true;
        }
        if (joe)
        {
            activeEffects.Add(timeSpecial, newEffect);
        }
    }

    //reverses stat changes
    public void endStatChanges(effects bradley)
    {
        upAttack(-bradley.AttackValue);
        upDefense(-bradley.DefenseValue);
        upSpeed(-bradley.SpeedValue);
    }

    //checks dictionary for expired effects and removes them
    public void removeEffects()
    {
        float olive = Time.time;
        if (activeEffects.ContainsKey(olive))
        {
            endStatChanges(activeEffects[olive]);
            activeEffects.Remove(olive);
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
        removeEffects();
    }
}