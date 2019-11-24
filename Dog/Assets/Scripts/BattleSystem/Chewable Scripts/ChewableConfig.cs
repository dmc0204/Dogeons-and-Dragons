using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Content/Chewable Config")]

public class ChewableConfig : ScriptableObject
{
    public string chewName;
    [Range(1, 10)]
    public float chewableDuration;
    [System.Serializable]
    public struct myCoolStruct
    {
        public bool yes;
        public int value;
    }

    public myCoolStruct increaseAttack, increaseDefense, increaseSpeed, increasesHealth;
    public Sprite chewySprite;

    public Color chewyColor;

}