using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Content/Dog Stats Config")]
public class DogStatsConfig : ScriptableObject
{
    [Range(1, 50)]
    public float MaxHealth, BaseAttack, BaseDefense, BaseSpeed;

    public string dogName;

    public Sprite head, body, FLleg, FRleg, BLleg, BRleg;

    public Transform headT, bodyT, FLlegT, FRlegT, BLlegT, BRlegT;

    public RuntimeAnimatorController animator;
}
