using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgradeItem : Item
{
    private int _upgradeSpeed = 2;
    public override void Use(GameObject player)
    {
        if (player.TryGetComponent(out Movement movement))
        {
            movement.Speed += _upgradeSpeed;
            Debug.Log($"Скорость увеличена на {_upgradeSpeed}");
        }
        else
        {
            Debug.LogWarning("Скрипт Movement не найден");
        }
    }
}
