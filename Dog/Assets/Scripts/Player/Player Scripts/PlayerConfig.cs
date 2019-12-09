using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "Content/Player Config")]

public class PlayerConfig : ScriptableObject
{
    public DogStatsConfig[] yourTeam;

    public ChewableConfig[] yourPack;

    public Dictionary<ChewableConfig, int> inventory;

    public List<DogStatsConfig> yourDogs;

    public int currency, currentLevel;
    //public DogStatsConfig[] ownedDogs;

    [SerializeField] public IntEvent currencyDisplaying;
    //[SerializeField] public FloatEvent dupeChecking;

    //initall

    ///Inventory functions
    /// inventory intializer

    //pack initializer

    //adds items to your inventory
    public void addItems(ChewableConfig key, int value)
    {
        if (inventory.ContainsKey(key))
        {
            inventory[key] += value;
        }
        else
        {
            inventory.Add(key, value);
        }
    }
    //
    //can add items to your bag to take into battle
    public void addToBag(ChewableConfig chewable)
    {
        inventory[chewable] -= 1;
        for (int i = 0; i < yourPack.Length; i++)
        {
            if (yourPack[i] == null)
            {
                yourPack[i] = chewable;
                i = 10;
            }
        }
    }

    //check how many you have
    public int amount(ChewableConfig chewable)
    {
        if (inventory.ContainsKey(chewable))
        {
            return inventory[key];
        }
        else
        {
            return 0;
        }
    }

    //uses up your chewable
    public void chewableGotUsed(int spot)
    {
        yourPack[spot] = null;
    }

    //dog functions

    /*  public void dogsInit()
     {
         yourDogs = new List<DogStatsConfig>(ownedDogs);
     } */

    public bool hasDog(DogStatsConfig toCheck)
    {
        if (yourDogs.Contains(toCheck))
        {
            return true;
        }
        else
            return false;
    }

    public void changeBones(int bones)
    {
        currency += bones;
    }

    public bool isOnTeam(DogStatsConfig check)
    {
        bool toReturn = false;
        for (int i = 0; i < yourTeam.Length; i++)
        {
            if (yourTeam[i] == check)
            {
                toReturn = true;
            }
        }
        return toReturn;
    }

    public void removeFromTeam(DogStatsConfig toRemove)
    {
        for (int i = 0; i < yourTeam.Length; i++)
        {
            if (yourTeam[i] == toRemove)
            {
                yourTeam[i] = null;
            }
        }
    }

    public void addToTeam(DogStatsConfig toAdd)
    {
        for (int i = 0; i < yourTeam.Length; i++)
        {
            if (yourTeam[i] == null)
            {
                yourTeam[i] = toAdd;
                i = 4;
            }
        }
    }

    /* public void usedItem(string key)
    {
        if (inventory.ContainsKey(key))
        {
            inventory[key] -= 1;
        }
        else
        {
            Debug.Log("error used an item you didnt have");
        }
    } */

}