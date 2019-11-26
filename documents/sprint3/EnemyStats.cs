using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public EnemyStatsConfig myCoolVariable;

    //[System.NonSerialized]
    public float currentHP;
    
    public float currentAttack;
    
    public float currentDefense;
    
    public float currentSpeed;

    public Slider healthbar;

    float calcHealth() {
        return currentHP / myCoolVariable.MaxHealth;
    }
    
    void Start() {
        currentHP = myCoolVariable.MaxHealth;
        currentDefense = myCoolVariable.BaseDefense;
        currentAttack = myCoolVariable.BaseAttack;
        currentSpeed = myCoolVariable.BaseSpeed;
        healthbar.value = calcHealth();
    }

    void Update() {
        healthbar.value = calcHealth();
    }
}
