using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Content/Level Config")]
public class LevelConfig : ScriptableObject
{
    public EnemyStatsConfig[] enemies;

    //List<DogContainer> yourTeam;

    public Sprite background;

    private float damageTaken, damageDealt;
    //funcs to track these, get passed numbers

    private bool dogDied;

    private int count = 0;

    public EnemyStatsConfig getNext()
    {
        EnemyStatsConfig toReturn;
        toReturn = enemies[count];
        count++;
        return toReturn;
    }

    public bool isEmpty()
    {
        if (count > enemies.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
