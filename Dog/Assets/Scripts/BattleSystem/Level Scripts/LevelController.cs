using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    private float damageTaken, damageDealt;
    //funcs to track these, get passed numbers

    private bool dogDied;

    public int count;
    public LevelConfig newLevel;

    public EnemyStatsConfig[] enemies;
    public DogStatsConfig[] dogs;
    public Sprite background;
    public SpriteRenderer backgroundSpriteRenderer;
    [SerializeField] private EnemyStatsEvent gettingEnemyStats;

    public EnemyStatsConfig getNext () {
        EnemyStatsConfig toReturn;
        toReturn = enemies[count];
        count++;
        return toReturn;
    }

    public void initialize () {
        count = 0;
        enemies = newLevel.enemies;
        dogs = newLevel.yourTeam;
        background = newLevel.background;
        backgroundSpriteRenderer = GetComponent<SpriteRenderer> ();
        backgroundSpriteRenderer.sprite = background;
    }

    public void getNewEnemy () {
        gettingEnemyStats.Raise (getNext ());
    }

    public bool isEmpty () {
        if (count > enemies.Length) {
            return true;
        } else {
            return false;
        }
    }
    // Start is called before the first frame update
    void Start () {
        initialize ();
    }

    // Update is called once per frame
    void Update () {

    }
}