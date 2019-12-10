using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Content/Dog Stats Config")]
public class DogStatsConfig : ScriptableObject
{
    public string dogName;
    /* [Range(1, 4)]
    public int rarity; */

    public Rarity dogRarity;

    [Range(1, 200)]
    public float MaxHealth;

    [Range(1, 50)]
    public float BaseAttack, BaseDefense;
    [Range(5, 35)]
    public float BaseSpeed;

    //public bool 

    public Sprite head, body, FLleg, FRleg, BLleg, BRleg, accesory;

    public Vector3 headPosition, bodyPosition, FLlegPosition, FRlegPosition, BLlegPosition, BRlegPosition, accesoryPosition;
    public RuntimeAnimatorController animator;

    /* [Range(1, 10)]
    public float specialDuration;

    [System.Serializable]
    public struct myCoolStruct
    {
        public bool onSelf, onEnemy;
        [Range(-20, 20)]
        public float value;
    }

    public myCoolStruct specialDealsDamage, specialIncreasesAttack, specialIncreasesDefense, specialIncreasesSpeed, specialIncreasesHealth;
 */

    public special[] specialEffects;
}
