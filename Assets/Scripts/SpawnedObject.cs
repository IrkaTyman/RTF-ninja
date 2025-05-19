using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class SpawnedObject : Object
{
    public Sprite[] _sprites;  
    public Color[] _particularColors;

    void Start()
    {
        var index = Random.Range(0, _sprites.Length);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _sprites[index];

        ParticleSystem.MainModule main = GetComponent<ParticleSystem>().main;
        main.startColor = _particularColors[index]; 
    }
}
