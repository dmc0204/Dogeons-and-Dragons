using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Initialization/Array of Dogs")]

public class ArrayOfDogs : ScriptableObject
{
    public DogStatsConfig[] dogsInTheGame;

    public DogStatsConfig[][] summoningPools;

    private List<DogStatsConfig> rareDogs;
    private List<DogStatsConfig> superRareDogs;
    private List<DogStatsConfig> superDuperRareDogs;
    private List<DogStatsConfig> ultraRareDogs;
    public System.Random firstRando;

    //public bool poolBuilt;

    public List<DogStatsConfig> RareDogs { get => rareDogs; set => rareDogs = value; }
    public List<DogStatsConfig> SuperRareDogs { get => superRareDogs; set => superRareDogs = value; }
    public List<DogStatsConfig> SuperDuperRareDogs { get => superDuperRareDogs; set => superDuperRareDogs = value; }
    public List<DogStatsConfig> UltraRareDogs { get => ultraRareDogs; set => ultraRareDogs = value; }
    //public DogStatsConfig[][] summoningPools { get => summoningPools; set => summoningPools = value; }
    public DogStatsConfig[] rareDogArray;

    public DogStatsConfig[] superRareDogArray;

    public DogStatsConfig[] superDuperRareDogArray;

    public DogStatsConfig[] ultraRareDogArray;




    public void initPool()
    {
        firstRando = new System.Random();
        if (true)
        {
            RareDogs = new List<DogStatsConfig>();
            SuperRareDogs = new List<DogStatsConfig>();
            SuperDuperRareDogs = new List<DogStatsConfig>();
            UltraRareDogs = new List<DogStatsConfig>();

            //summoningPools = new DogStatsConfig[4, 20];
            for (int i = 0; i < dogsInTheGame.Length; i++)
            {
                Rarity butts = dogsInTheGame[i].dogRarity;
                switch (butts)
                {
                    case Rarity.rare:
                        RareDogs.Add(dogsInTheGame[i]);
                        break;
                    case Rarity.superRare:
                        SuperRareDogs.Add(dogsInTheGame[i]);
                        break;
                    case Rarity.superDuperRare:
                        SuperDuperRareDogs.Add(dogsInTheGame[i]);
                        break;
                    case Rarity.ultraRare:
                        UltraRareDogs.Add(dogsInTheGame[i]);
                        break;
                }
            }
            summoningPools = new DogStatsConfig[4][];
            rareDogArray = RareDogs.ToArray();
            superRareDogArray = SuperRareDogs.ToArray();
            superDuperRareDogArray = SuperDuperRareDogs.ToArray();
            ultraRareDogArray = UltraRareDogs.ToArray();

            summoningPools[0] = new DogStatsConfig[RareDogs.Count];
            summoningPools[1] = new DogStatsConfig[SuperRareDogs.Count];
            summoningPools[2] = new DogStatsConfig[SuperDuperRareDogs.Count];
            summoningPools[3] = new DogStatsConfig[UltraRareDogs.Count];

            rareDogArray.CopyTo(summoningPools[0], 0);
            for (int i = 0; i < summoningPools[0].Length; i++)
            {
                Debug.Log(summoningPools[0][i]);
            }
            superRareDogArray.CopyTo(summoningPools[1], 0);
            superDuperRareDogArray.CopyTo(summoningPools[2], 0);
            ultraRareDogArray.CopyTo(summoningPools[3], 0);
        }
        //poolBuilt = true;

    }

    public int generateRandom()
    {
        int toReturn = firstRando.Next(9);
        return toReturn;
    }




}