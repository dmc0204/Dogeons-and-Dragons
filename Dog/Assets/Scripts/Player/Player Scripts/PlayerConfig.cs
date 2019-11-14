using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Content/Player Config")]

public class PlayerConfig : ScriptableObject {
    public DogStatsConfig[] yourTeam;

    public ChewableConfig[] yourChewies;

}