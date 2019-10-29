using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Content/Level Config")]
public class LevelConfig : ScriptableObject
{
    Queue<EnemyStatsConfig> enemiesHere;

    //List<DogContainer> yourTeam;

    Image background;

    float damageTaken, damageDealt;
    //funcs to track these, get passed numbers

    bool dogDied;

    //TODO: queue functions that are accessible
    public bool isEmpty()
    {
        if (enemiesHere.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public EnemyStatsConfig popOff()
    {
        return enemiesHere.Dequeue();
    }
}
