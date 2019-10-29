using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Content/Enemy Stats Config")]
public class EnemyStatsConfig : ScriptableObject
{
    [Range(1, 50)]
    public float MaxHealth, BaseAttack, BaseDefense, BaseSpeed;

    public string enemyName;

    public Sprite body;

    public Sprite arm;

    public RuntimeAnimatorController animator;

}