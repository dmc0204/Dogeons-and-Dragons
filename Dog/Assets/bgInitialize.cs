using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgInitialize : MonoBehaviour
{
    public SpriteRenderer backgroundSpriteRenderer;
    public LevelConfig level;

    // Start is called before the first frame update
    void Start()
    {
        backgroundSpriteRenderer = GetComponent<SpriteRenderer>();
        backgroundSpriteRenderer.sprite = level.background;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
