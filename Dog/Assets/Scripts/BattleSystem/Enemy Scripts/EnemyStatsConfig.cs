using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Content/Enemy Stats Config")]
public class EnemyStatsConfig : ScriptableObject
{
    public string enemyName;
    [Range(1, 200)]
    public float MaxHealth;

    [Range(1, 100)]
    public float BaseAttack, BaseDefense, BaseSpeed;

    public Sprite head, body, leftArm, rightArm, leftLeg, rightLeg;

    public Vector3 bodyPosition, headPosition, leftArmPosition, rightArmPosition, leftLegPosition, rightLegPosition;

    //public Transform myCoolTransform;

    public RuntimeAnimatorController animator;
    public special[] specialEffects;
    /* public float specialDuration;


    [System.Serializable]
    public struct myCoolStruct
    {
        public bool onSelf, onDog;
        [Range(-20, 20)]
        public float value;
    }

    public myCoolStruct specialDealsDamage, specialIncreasesAttack, specialIncreasesDefense, specialIncreasesSpeed, specialIncreasesHealth; */

}