using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Content/Chewable Config")]

public class ChewableConfig : ScriptableObject
{
    public float value, time;
    public bool increaseAttack,
    increaseDefense,
    increaseHealth,
    increaseSpeed;
    public Sprite chewySprite;

    public Color chewyColor;

}