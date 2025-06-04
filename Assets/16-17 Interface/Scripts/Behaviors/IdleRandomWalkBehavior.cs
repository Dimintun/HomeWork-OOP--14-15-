using UnityEngine;

public class IdleRandomWalkBehavior : IEnemyBehavior
{
    private Vector3 _currentDirection = Vector3.zero;
    private float _changeDirectionTime = 1f;
    private float _timer = 0f;
    private float _speed = 2f;

    public void Update(GameObject enemy, GameObject player)
    {
        _timer += Time.deltaTime;

        if (_timer >= _changeDirectionTime)
        {
            _timer = 0f;

            float randomX = Random.Range(-1f, 1f);
            float randomZ = Random.Range(-1f, 1f);
            _currentDirection = new Vector3(randomX, 0f, randomZ).normalized;
        }

        enemy.transform.Translate(_currentDirection * _speed * Time.deltaTime, Space.World);
    }
}

