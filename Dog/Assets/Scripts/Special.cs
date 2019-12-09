using UnityEngine;

[System.Serializable]
public class special
{
    public target targets;

    public types type;

    [Range(0, 10)]
    public float duration;
    [Range(-50, 50)]
    public float value;


}