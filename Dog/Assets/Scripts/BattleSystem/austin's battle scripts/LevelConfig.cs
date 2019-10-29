using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Content/Level Config")]
public class LevelConfig : ScriptableObject
{
    public static EnemyStatsConfig[] enemies;

    //public var enemiesHere = new Queue(enemies);

    //List<DogContainer> yourTeam;

    public Sprite background;

    public float damageTaken, damageDealt;
    //funcs to track these, get passed numbers

    public bool dogDied;



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

    public void Start()
    {
        var enemiesHere = new Queue(enemies);
    }


}
