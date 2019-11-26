using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Content/Dog Stats Config")]
public class DogStatsConfig : ScriptableObject
{
    public string dogName;

    [Range(1, 50)]
    public float MaxHealth, BaseAttack, BaseDefense, BaseSpeed;

    //public bool 

    public Sprite head, body, FLleg, FRleg, BLleg, BRleg;

    public Vector3 headPosition, bodyPosition, FLlegPosition, FRlegPosition, BLlegPosition, BRlegPosition;
    public RuntimeAnimatorController animator;

    [Range(1, 10)]
    public float specialDuration;

    [System.Serializable]
    public struct myCoolStruct
    {
        public bool onSelf, onEnemy;
        [Range(-20, 20)]
        public float value;
    }

    public myCoolStruct specialDealsDamage, specialIncreasesAttack, specialIncreasesDefense, specialIncreasesSpeed, specialIncreasesHealth;

}
