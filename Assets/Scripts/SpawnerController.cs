using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject[] _prefabs;
    public float _minX;
    public float _maxX;
    public float _startTime;  
    private float _time;      

    void Update()
    {
        if (_time <= 0)
        {
            SpawnObject();
            _time = _startTime;
        }
        else
        {
            _time -= Time.deltaTime;
        }
    }

    private void SpawnObject()
    {
        var index = Random.Range(0, _prefabs.Length);

        GameObject _newPrefab = Instantiate(_prefabs[index]);
         _newPrefab.transform.position = new Vector3(
                Random.Range(_minX, _maxX),
                transform.position.y,
                -9
                );
    }
}
