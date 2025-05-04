using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;

    [SerializeField] private int _health;

    private Vector3 _startPosition;

    private int _collectedCoins;
    public int CollectedCoins => _collectedCoins;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    public void ColletCoin(int value) => _collectedCoins += value;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        
        if (_health <= 0)
        {
            _health = 0;
            Death();
        }
    }
    public void Death()
    {
        _deathEffect.transform.position = transform.position;
        _deathEffect.Play();
        gameObject.SetActive(false);
        
      
    }
    public void NewGame()
    {
      
      gameObject.SetActive(true);
      transform.position = _startPosition;
      _collectedCoins = 0;
    }
}
