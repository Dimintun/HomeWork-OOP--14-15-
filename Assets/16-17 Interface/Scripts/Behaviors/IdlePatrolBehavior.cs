
using System.Collections.Generic;
using UnityEngine;

public class IdlePatrolBehavior : IEnemyBehavior
{
    private const int Height = 1;
    private List<Vector3> _patrolPoints = new List<Vector3>();
    private int _speed = 5;
    private float _stopDistance = 0.3f;
    private int _currentIndex = 0;
    private int _numberOfPoints = 4;

    public void Update(GameObject enemy, GameObject player)
    {
        if (_patrolPoints.Count == 0)
        {
            CreatePoints(enemy.transform.position);
            return;
        }

        Vector3 target = _patrolPoints[_currentIndex];
        Vector3 direction = (target - enemy.transform.position).normalized;

        enemy.transform.position += direction * _speed * Time.deltaTime;

        Vector3 toTarget = target - enemy.transform.position;
        if (toTarget.magnitude < _stopDistance)
        {
            _currentIndex++;

            if (_currentIndex >= _patrolPoints.Count)
            {
                _currentIndex = 0;
                _patrolPoints.Clear(); // Пересоздание маршрута
            }
        }
    }
    private void CreatePoints(Vector3 startPos)
    {
        _patrolPoints.Clear(); 

        for (int i = 0; i < _numberOfPoints; i++)
        {
            float randomX = Random.Range(-5f, 5f);
            float randomZ = Random.Range(-5f, 5f);

            Vector3 randomPoint = new Vector3(startPos.x + randomX, Height, startPos.z + randomZ);
            _patrolPoints.Add(randomPoint);
        }
    }

}



