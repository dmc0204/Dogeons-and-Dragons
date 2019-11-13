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

    public float headPositionX, headPositionY, headPositionZ,
        bodyPositionX, bodyPositionY, bodyPositionZ,
        FLlegPositionX, FLlegPositionY, FLlegPositionZ,
        FRlegPositionX, FRlegPositionY, FRlegPositionZ,
        BLlegPositionX, BLlegPositionY, BLlegPositionZ,
        BRlegPositionX, BRlegPositionY, BRlegPositionZ;

    public RuntimeAnimatorController animator;
}
