using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<Item> _items;
    [SerializeField] private Vector3 _offset;
    [SerializeField]private int _cooldown = 5;

    private float _time = 0;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _cooldown )
        {
            List<SpawnPoint> emptyPoints = GetEmptyPoints();

            if (emptyPoints.Count == 0 )
            {
                _time = 0;
                return;
            }

            SpawnPoint spawnPoint = emptyPoints[Random.Range(0, emptyPoints.Count)];
            Item item = _items[Random.Range(0, _items.Count)];

            Item spawnedItem = Instantiate(item, spawnPoint.Position + _offset, Quaternion.identity);

            spawnPoint.Occupy(spawnedItem);

            _time = 0;
        }
    }

  private List<SpawnPoint> GetEmptyPoints()
    {
        List<SpawnPoint> emptyPoints = new List<SpawnPoint>();

        foreach (SpawnPoint point in _spawnPoints)
            if(point.IsEmpty)
                emptyPoints.Add(point);

        return emptyPoints;
    }
}
