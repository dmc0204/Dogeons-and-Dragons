using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "Initialization/Array of Dogs")]

public class ArrayOfDogs : ScriptableObject
{
    public DogStatsConfig[] dogsInTheGame;
    private DogStatsConfig[][] summoningPools;

    private List<DogStatsConfig> rareDogs;
    private List<DogStatsConfig> superRareDogs;
    private List<DogStatsConfig> superDuperRareDogs;
    private List<DogStatsConfig> ultraRareDogs;

    public List<DogStatsConfig> RareDogs { get => rareDogs; set => rareDogs = value; }
    public List<DogStatsConfig> SuperRareDogs { get => superRareDogs; set => superRareDogs = value; }
    public List<DogStatsConfig> SuperDuperRareDogs { get => superDuperRareDogs; set => superDuperRareDogs = value; }
    public List<DogStatsConfig> UltraRareDogs { get => ultraRareDogs; set => ultraRareDogs = value; }
    public DogStatsConfig[][] SummoningPools { get => summoningPools; set => summoningPools = value; }

    public void initPool()
    {
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
        SummoningPools = new DogStatsConfig[4][];
        SummoningPools[0] = RareDogs.ToArray();
        SummoningPools[1] = SuperRareDogs.ToArray();
        SummoningPools[2] = SuperDuperRareDogs.ToArray();
        SummoningPools[3] = UltraRareDogs.ToArray();
    }

    public DogStatsConfig returnDog(int i, int j)
    {
        switch (i)
        {
            case 0:
                j = j % RareDogs.Count;
                break;
            case 1:
                j = j % SuperRareDogs.Count;
                break;
            case 2:
                j = j % SuperDuperRareDogs.Count;
                break;
            case 3:
                j = j % UltraRareDogs.Count;
                break;
        }
        return SummoningPools[i][j];
    }

}