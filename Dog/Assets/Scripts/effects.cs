[System.Serializable]
public class effects
{
    private float healthValue;
    private float attackValue;
    private float defenseValue;
    private float speedValue;
    private float damageValue;

    public effects(types type, float value)
    {
        switch (type)
        {
            case types.changeAttack:
                AttackValue = value;
                break;
            case types.changeDefense:
                DefenseValue = value;
                break;
            case types.changeSpeed:
                SpeedValue = value;
                break;
            case types.changeHealth:
                if (value > 0)
                {
                    HealthValue = value;
                }
                else
                {
                    DamageValue = value;
                }
                break;
            default:
                AttackValue = 0;
                DefenseValue = 0;
                SpeedValue = 0;
                HealthValue = 0;
                DamageValue = 0;
                break;
        }
    }

    public float AttackValue { get => attackValue; set => attackValue = value; }
    public float DefenseValue { get => defenseValue; set => defenseValue = value; }
    public float SpeedValue { get => speedValue; set => speedValue = value; }
    public float DamageValue { get => damageValue; set => damageValue = value; }
    public float HealthValue { get => healthValue; set => healthValue = value; }
}