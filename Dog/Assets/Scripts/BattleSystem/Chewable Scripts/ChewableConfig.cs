using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Content/Chewable Config")]

public class ChewableConfig : ScriptableObject
{
    public string chewName;
    public special[] chewEffects;

    public Sprite chewySprite;

    public int chewableCost, chewableStrength;
    public string chewableType;

    public Color chewyColor;

}