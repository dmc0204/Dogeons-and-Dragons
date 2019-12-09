using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SummonController : MonoBehaviour
{
    public ArrayOfDogs dogs;

    //public DogStatsConfig[][] Pool;


    [SerializeField] private DogStatsEvent summon;



    public void summonTime()
    {
        int i = dogs.generateRandom();
        int j = dogs.generateRandom();
        DogStatsConfig toSummon = returnDog(i, j);
        summon.Raise(toSummon);
        Debug.Log("summon event sent: " + toSummon);
    }

    public DogStatsConfig returnDog(int i, int j)
    {
        int pool;
        if (i < 4)
        {
            pool = 0;
        }
        else if (i < 7)
        {
            pool = 1;
        }
        else if (i < 9)
        {
            pool = 2;
        }
        else if (i == 9)
        {
            pool = 3;
        }
        else
        {
            pool = 0;
        }
        Debug.Log("pool is " + pool);

        switch (pool)
        {
            case 0:
                j = j % dogs.RareDogs.Count;
                Debug.Log("rare count is " + dogs.RareDogs.Count);
                Debug.Log("j is " + j);
                break;
            case 1:
                j = j % dogs.SuperRareDogs.Count;
                Debug.Log("sr count is " + dogs.SuperRareDogs.Count);
                Debug.Log("j is " + j);
                break;
            case 2:
                j = j % dogs.SuperDuperRareDogs.Count;
                Debug.Log("sdr count is " + dogs.SuperDuperRareDogs.Count);
                Debug.Log("j is " + j);
                break;
            case 3:
                j = j % dogs.UltraRareDogs.Count;
                Debug.Log("ur count is " + dogs.UltraRareDogs.Count);
                Debug.Log("j is " + j);
                break;
        }
        DogStatsConfig toReturn = dogs.summoningPools[pool][j];
        return toReturn;
    }
    // Start is called before the first frame update
    void Start()
    {
        dogs.initPool();
        //Pool = dogs.summoningPools;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
