using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public int _pointsCount;

    public Rigidbody2D rb;
    public float _minX;
    public float _maxX;
    public float _minY;
    public float _maxY;
    public float _lifeTime;

    void Start()
    {
        rb.velocity = new Vector2(
                Random.Range(_minX, _maxX),
                Random.Range(_minY, _maxY)
            );
        Destroy(gameObject, _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var emission = ps.emission;
        emission.enabled = true;

        Renderer rend;
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }
}
