using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Cut : MonoBehaviour
{
    private Manager _manager;

    void Start()
    {
        _manager = GameObject.FindObjectOfType<Manager>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.GetComponent<Renderer>().enabled) {
            return;
        }

        if (collision.gameObject.CompareTag("Bomb")) {
            _manager.Damage();
        } else {
            Destroy(collision.gameObject, 0.5f);
            var spawnedObject = collision.GetComponent<SpawnedObject>();
            _manager._score += spawnedObject._pointsCount;
            _manager.LevelUpdate();
        }
    }
}
