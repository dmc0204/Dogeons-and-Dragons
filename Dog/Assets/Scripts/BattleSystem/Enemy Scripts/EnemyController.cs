using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public EnemyStatsConfig myCoolVariable;

    //[System.NonSerialized]
    public float currentHP, currentAttack, currentDefense, currentSpeed, timeAbleToBasicAttack;

    //public Slider healthbar;

    public SpriteRenderer enemyBodySpriteRenderer,
    enemyHeadSpriteRenderer,
    enemyLeftArmSpriteRenderer,
    enemyRightArmSpriteRenderer,
    enemyLeftLegSpriteRenderer,
    enemyRightLegSpriteRenderer;

    public Transform enemyBodyTransform,
    enemyHeadTransform,
    enemyLeftArmTransform,
    enemyRightArmTransform,
    enemyLeftLegTransform,
    enemyRightLegTransform;

    public Animator enemyAnimator;

    //public Text name;

    private SortedDictionary<float, effects> activeEffects;
    public int chargeCount;

    [SerializeField] private VoidEvent dying;
    [SerializeField] private VoidEvent enemyFetching, specialUsing;
    [SerializeField] private FloatEvent attacking, healthUpdating, basicAttackTiming, enemydamaging;
    [SerializeField] private statChangeEvent statChanging;

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
        dying.Raise();
        //TODO:write something in animator that links this call to the
        //wantNewEnemy call.  that way the new enemy only spawns when the 
        //old one's death animation finishes
    }

    //clears enemy sprites
    void nullEnemy()
    {
        enemyBodySpriteRenderer.sprite = null;
        enemyHeadSpriteRenderer.sprite = null;
        enemyLeftArmSpriteRenderer.sprite = null;
        enemyRightArmSpriteRenderer.sprite = null;
        enemyLeftLegSpriteRenderer.sprite = null;
        enemyRightLegSpriteRenderer.sprite = null;
        currentAttack = 0;
        currentDefense = 0;
        currentSpeed = 0;
        currentHP = -1;
        //name.text = "";
    }

    //asks if there are enemies left
    public void wantNewEnemy()
    {
        enemyFetching.Raise();
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
        //inits stats
        currentHP = myCoolVariable.MaxHealth;
        currentAttack = myCoolVariable.BaseAttack;
        currentDefense = myCoolVariable.BaseDefense;
        currentSpeed = myCoolVariable.BaseSpeed;
        //inits sprites
        enemyBodySpriteRenderer.sprite = myCoolVariable.body;
        enemyHeadSpriteRenderer.sprite = myCoolVariable.head;
        enemyLeftArmSpriteRenderer.sprite = myCoolVariable.leftArm;
        enemyRightArmSpriteRenderer.sprite = myCoolVariable.rightArm;
        enemyLeftLegSpriteRenderer.sprite = myCoolVariable.leftLeg;
        enemyRightLegSpriteRenderer.sprite = myCoolVariable.rightLeg;

        //inits transforms
        enemyBodyTransform.localPosition = new Vector3(myCoolVariable.bodyPosition.x, myCoolVariable.bodyPosition.y, myCoolVariable.bodyPosition.z);
        enemyHeadTransform.localPosition = new Vector3(myCoolVariable.headPosition.x, myCoolVariable.headPosition.y, myCoolVariable.headPosition.z);
        enemyLeftArmTransform.localPosition = new Vector3(myCoolVariable.leftArmPosition.x, myCoolVariable.leftArmPosition.y, myCoolVariable.leftArmPosition.z);
        enemyRightArmTransform.localPosition = new Vector3(myCoolVariable.rightArmPosition.x, myCoolVariable.rightArmPosition.y, myCoolVariable.rightArmPosition.z);
        enemyLeftLegTransform.localPosition = new Vector3(myCoolVariable.leftLegPosition.x, myCoolVariable.leftLegPosition.y, myCoolVariable.leftLegPosition.z);
        enemyRightLegTransform.localPosition = new Vector3(myCoolVariable.rightLegPosition.x, myCoolVariable.rightLegPosition.y, myCoolVariable.rightLegPosition.z);

        enemyAnimator = GetComponent<Animator>();
        enemyAnimator.runtimeAnimatorController = myCoolVariable.animator;
        //name.text = myCoolVariable.enemyName;
        timeAbleToBasicAttack = Time.time + basicAttackCooldown();
        activeEffects = new SortedDictionary<float, effects>();

    }

    // // // // // // // // // // // //

    //healthbar controller functions
    public void updateHealthBar()
    {
        healthUpdating.Raise(calcHealth());
    }

    public float calcHealth()
    {
        return currentHP / myCoolVariable.MaxHealth;
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
        enemydamaging.Raise(damage);
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
            attacking.Raise(currentAttack);
        }
    }

    //TODO: implement all that special shit for enemies

    //special attack stuff
    public void specialAttack()
    {
        //checks if you can use youur special
        if (chargeCount >= 3)
        {
            foreach (special special in myCoolVariable.specialEffects)
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
            //instantiates the effects
            /* effects selfEffects = new effects (), enemyEffects = new effects ();
            //these are fucking flags so we don't do random shit we dont need
            bool don = false, john = false;

            //these basically check if the special does the thing, who it does it to and sets the flag

            if (myCoolVariable.specialDealsDamage.onDog) {
                enemyEffects.DamageValue = myCoolVariable.specialDealsDamage.value;
                don = true;
            }
            if (myCoolVariable.specialDealsDamage.onSelf) {
                selfEffects.DamageValue = myCoolVariable.specialDealsDamage.value;
                john = true;
            }
            if (myCoolVariable.specialIncreasesHealth.onDog) {
                enemyEffects.HealthValue = myCoolVariable.specialIncreasesHealth.value;
                don = true;
            }
            if (myCoolVariable.specialIncreasesHealth.onSelf) {
                selfEffects.HealthValue = myCoolVariable.specialIncreasesHealth.value;
                john = true;
            }

            if (myCoolVariable.specialIncreasesAttack.onDog) {
                enemyEffects.AttackValue = myCoolVariable.specialIncreasesAttack.value;
                don = true;
            }
            if (myCoolVariable.specialIncreasesAttack.onSelf) {
                selfEffects.AttackValue = myCoolVariable.specialIncreasesAttack.value;
                john = true;
            }
            if (myCoolVariable.specialIncreasesDefense.onDog) {
                enemyEffects.DefenseValue = myCoolVariable.specialIncreasesDefense.value;
                don = true;
            }
            if (myCoolVariable.specialIncreasesDefense.onSelf) {
                selfEffects.DefenseValue = myCoolVariable.specialIncreasesDefense.value;
                john = true;
            }
            if (myCoolVariable.specialIncreasesSpeed.onDog) {
                enemyEffects.SpeedValue = myCoolVariable.specialIncreasesSpeed.value;
                don = true;
            }
            if (myCoolVariable.specialIncreasesSpeed.onSelf) {
                selfEffects.SpeedValue = myCoolVariable.specialIncreasesSpeed.value;
                john = true;
            }
            //does special effects on self
            if (john) {
                applyEffect (myCoolVariable.specialDuration, selfEffects);
            }
            //does special effects on enemy
            if (don) {
                statChange marcel = new statChange ();
                marcel.duration = myCoolVariable.specialDuration;
                marcel.effects = enemyEffects;
                statChanging.Raise (marcel);
            }
        }
        chargeCount = 0;
        specialUsing.Raise (); */
        }
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
            upHealth(newEffect.HealthValue);
        }
        if (newEffect.DamageValue != 0)
        {
            upHealth((-1) * (newEffect.DamageValue));
        }
        if (newEffect.AttackValue != 0)
        {
            upAttack(newEffect.AttackValue);
            joe = true;
        }
        if (newEffect.DefenseValue != 0)
        {
            upDefense(newEffect.DefenseValue);
            joe = true;
        }
        if (newEffect.SpeedValue != 0)
        {
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
        if (currentHP > myCoolVariable.MaxHealth)
        {
            currentHP = myCoolVariable.MaxHealth;
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
        removeEffects();
        basicAttackTiming.Raise(calcTime());
        if (isEnemyDead())
        {
            died();
            nullEnemy();
            wantNewEnemy();
        }
    }
}