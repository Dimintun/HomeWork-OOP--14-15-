using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : Item
{
    [SerializeField] private GameObject _bombProjectilePrefab;
    [SerializeField] private float _launchForce = 10f;
    [SerializeField] private float _lifeTime = 3f;

    public override void Use(GameObject player)
    {
        Destroy(gameObject);

        if (player == null)
        {
            Debug.Log("Скрипт не найден");
            return;
        }

        Vector3 spawnPos = player.transform.position + player.transform.forward * 1.5f + Vector3.up * 1f;
        Quaternion rotation = Quaternion.LookRotation(player.transform.forward);

        GameObject bomb = Instantiate(_bombProjectilePrefab, spawnPos, rotation);

        if (bomb.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.AddForce(player.transform.forward * _launchForce, ForceMode.Impulse);
        }

        Destroy(bomb, _lifeTime);
    }
}
