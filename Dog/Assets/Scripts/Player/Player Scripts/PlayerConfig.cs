using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Content/Player Config")]

public class PlayerConfig : ScriptableObject
{
    public DogStatsConfig[] yourTeam;

    public ChewableConfig[] yourChewies;

    public Dictionary<string, int> inventory;

    public Dictionary<string, bool> dogs;

    public void addItems(string key, int value)
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

    public void initializeInventory()
    {

    }

    public void usedItem(string key)
    {
        if (inventory.ContainsKey(key))
        {
            inventory[key] -= 1;
        }
        else
        {
            Debug.Log("error used an item you didnt have");
        }
    }


}