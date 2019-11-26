using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private Transform CharBattle;
    private void Start()
    {
        SpawnChar(true);
        SpawnChar(false);
    }
    private void SpawnChar(bool isPlayerOnTeam)
    {
        Vector2 position;
        if (isPlayerOnTeam)
        {
            position = new Vector2(-11,-4);
        }
        else
        {
            position = new Vector2(-8, -4);
        }
        Instantiate(CharBattle, position, Quaternion.identity);
    }
}
