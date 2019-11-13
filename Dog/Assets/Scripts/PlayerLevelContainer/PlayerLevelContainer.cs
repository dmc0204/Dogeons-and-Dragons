using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Content/Player Level Container")]

public class PlayerLevelContainer : ScriptableObject
{
    public PlayerConfig myCoolPlayer;
    public LevelConfig myCoolLevel;
}
