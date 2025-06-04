using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IEnemyBehavior _currentBehavior;
    private IEnemyBehavior _agroBehavior;
    private IEnemyBehavior _idleBehavior;

    private GameObject _player;

    private void Start()
    {
        _currentBehavior = _idleBehavior;
    }

    private void Update()
    {
        _currentBehavior.Update(gameObject, _player);
    }

    private void OnTriggerEnter(Collider other)
    {
        SetEnemyBehavior(_agroBehavior);
    }

    private void OnTriggerExit(Collider other)
    {
        SetEnemyBehavior(_idleBehavior);
    }

    public void Initialize(IEnemyBehavior agroBehavior, IEnemyBehavior idleBehavior, GameObject player)
    {
        _agroBehavior = agroBehavior;
        _idleBehavior = idleBehavior;
        _player = player;
    }

    private void SetEnemyBehavior(IEnemyBehavior enemyBehavior)
    {
        _currentBehavior = enemyBehavior;
    }
}
