using System.Collections;
//sing System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class LevelController : MonoBehaviour
{
    private float damageTaken, damageDealt;
    //TODO:funcs to track these, get passed numbers

    public float[] currentHP;

    private int currentDog;

    private int numDogsDied;

    //public int count;
    public PlayerLevelContainer brrrr;
    public LevelConfig newLevel;

    public PlayerConfig playa;
    //public EnemyStatsConfig[] enemies;

    public Queue<EnemyStatsConfig> NMEs;
    public DogStatsConfig[] dogs;
    public ChewableConfig[] chews;

    public Sprite background;
    public SpriteRenderer backgroundSpriteRenderer;

    public Image[] dogbtn, chewBtn;
    [SerializeField] private EnemyStatsEvent gettingEnemyStats;
    [SerializeField] private DogStatsEvent gettingDogStats;
    [SerializeField] private FloatEvent hpSending;
    [SerializeField] private ChewableEvent chewing;

    //initializes level values
    public void initialize()
    {
        damageTaken = 0;
        damageDealt = 0;
        numDogsDied = 0;
        newLevel = brrrr.myCoolLevel;
        playa = brrrr.myCoolPlayer;
        NMEs = new Queue<EnemyStatsConfig>(newLevel.enemies);
        dogs = playa.yourTeam;
        chews = playa.yourChewies;
        background = newLevel.background;
        backgroundSpriteRenderer = GetComponent<SpriteRenderer>();
        backgroundSpriteRenderer.sprite = background;
    }

    public void initHP()
    {
        currentHP = new float[dogs.Length];
        for (int i = 0; i < 3; i++)
        {
            currentHP[i] = -1;
        }
    }

    //initializes dog buttons
    public void initBtn()
    {
        for (int i = 0; i < dogs.Length; i++)
        {
            dogbtn[i].sprite = dogs[i].head;
        }
        for (int i = 0; i < chews.Length; i++)
        {
            chewBtn[i].sprite = chews[i].chewySprite;
            chewBtn[i].color = new Color(chews[i].chewyColor.r, chews[i].chewyColor.g, chews[i].chewyColor.b, chews[i].chewyColor.a);
        }
    }

    //functions to handle spawning new enemies
    //checks if there are enemies left to spawn
    public bool enemiesIsEmpty()
    {
        if (NMEs.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //returns next enemy in list
    public EnemyStatsConfig getNext()
    {

        EnemyStatsConfig toReturn;
        toReturn = NMEs.Dequeue();
        return toReturn;
    }

    void enemyDied()
    {
        //Debug.Log ("enemydied check triggered");
        if (!enemiesIsEmpty())
        {
            gettingEnemyStats.Raise(getNext());
        }
        else
        {
            Debug.Log("its empty!");
            endLevel(1);
        }
    }
    // // // // // // // // // // // // // // // // // //

    public void endLevel(int code)
    {
        //TODO:end the level with this function
        //stop time
        //call up level end panel
        //display stats
        //calculate rewards
        //write to player object
        switch (code)
        {
            case 0:
                //ends in game over, called when party dies
                break;
            case 1:
                //ends in victory
                break;
            default:
                break;
        }
    }

    // // // // // // // // // // // // // //
    //dog switching and such
    public void switchDogs(int whichDog)
    {
        Debug.Log("switching to: " + dogs[whichDog]);
        Debug.Log("hp sent is: " + currentHP[whichDog]);

        hpSending.Raise(currentHP[whichDog]);

        gettingDogStats.Raise(dogs[whichDog]);
        Debug.Log("dog switch events received");
        currentDog = whichDog;
        Debug.Log("current dog is: " + currentDog);
    }

    public void saveHP(float savedHP)
    {
        currentHP[currentDog] = savedHP;
        Debug.Log("current dog is: " + currentDog);
        Debug.Log("saved hp is: " + savedHP);
    }

    public void dogDeath()
    {
        int num;
        saveHP(0);
        dogbtn[currentDog].color = new Color(0, 0, 0, 1);
        numDogsDied++;
        if (numDogsDied < dogs.Length)
        {
            num = (currentDog + 1) % dogs.Length;
            if (currentHP[num] < 0)
            {
                num = (currentDog + 1) % dogs.Length;
            }
            switchDogs(num);
        }
        endLevel(0);
    }

    // // / // // // // // // // /// 
    //using chewable
    public void chewableTime(int i)
    {
        chewBtn[i].color = new Color(0, 0, 0, 1);
        //playa.usedItem(chews[i].chewName);
        //TODO:link this shit up with player
        chewing.Raise(chews[i]);
    }
    // Start is called before the first frame update
    void Start()
    {
        initialize();
        initHP();
        initBtn();
        //initQueue();
    }

    // Update is called once per frame
    void Update()
    {

    }
}