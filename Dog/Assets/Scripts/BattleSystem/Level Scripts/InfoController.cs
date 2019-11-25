using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoController : MonoBehaviour
{
    //public DogStatsConfig activeDog;

    //public EnemyStatsConfig activeEnemy;

    public Slider dogHealthBar, enemyHealthBar;

    public Image[] dogSpecialCharge, enemySpecialCharge;

    public Image dogBasicCharge, enemyBasicCharge;

    public Image dogPortrait, enemyPortrait;

    public Text dogName, enemyName;

    public int dogChargeCount, enemyChargeCount;


    //TODO: null values when unit dies

    public void initializeDog(DogStatsConfig newDog)
    {
        dogName.text = newDog.dogName;
        dogPortrait.sprite = newDog.head;
        dogPortrait.color = new Color(1, 1, 1, 1);
        dogChargeCount = 0;
        for (int i = 0; i < 3; i++)
        {
            dogSpecialCharge[i].color = new Color(0, 0, 0, 0);
        }
    }

    public void initializeEnemy(EnemyStatsConfig newEnemy)
    {
        enemyName.text = newEnemy.enemyName;
        enemyPortrait.sprite = newEnemy.head;
        enemyPortrait.color = new Color(1, 1, 1, 1);
        enemyChargeCount = 0;
        for (int i = 0; i < 3; i++)
        {
            enemySpecialCharge[i].color = new Color(0, 0, 0, 0);
        }
    }

    public void updateDogHealthBar(float percentageHealth)
    {
        dogHealthBar.value = percentageHealth;
    }

    public void updateEnemyHealthBar(float percentageHealth)
    {
        enemyHealthBar.value = percentageHealth;
    }

    public void updateDogCooldown(float percentageTime)
    {
        dogBasicCharge.fillAmount = percentageTime;
    }

    public void updateEnemyCooldown(float percentageTime)
    {
        enemyBasicCharge.fillAmount = percentageTime;
    }

    public void specialCharging()
    {
        dogChargeCount++;
        for (int i = 0; i < 3; i++)
        {
            if (dogChargeCount > i)
            {
                dogSpecialCharge[i].color = new Color(0.172f, 0.454f, 0.827f, 1);
            }
        }
    }

    public void enemySpecialCharging()
    {
        enemyChargeCount++;
        for (int i = 0; i < 3; i++)
        {
            if (enemyChargeCount > i)
            {
                enemySpecialCharge[i].color = new Color(0.172f, 0.454f, 0.827f, 1);
            }
        }
    }

    public void dogSpecialUsed()
    {
        dogChargeCount = 0;
        foreach (Image x in dogSpecialCharge)
        {
            x.color = new Color(0, 0, 0, 0);
        }
    }

    public void enemySpecialUsed()
    {
        enemyChargeCount = 0;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
