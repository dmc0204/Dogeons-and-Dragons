using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Content/Level Config")]
public class LevelConfig : ScriptableObject
{
    public EnemyStatsConfig[] enemies;

    public DogStatsConfig[] yourTeam;

    public Sprite background;

    

}
