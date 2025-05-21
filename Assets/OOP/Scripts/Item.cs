using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private SpawnPoint _spawnPoint;

    public void SetSpawnPoint(SpawnPoint spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    public void OnPickedUp()
    {
        if (_spawnPoint != null)
            _spawnPoint.Clear();

        _spawnPoint = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Inventory inventory))
        {
            if(inventory.AddItem(this) == false)
                return;
            else OnPickedUp();
        }
    }

    public abstract void Use(GameObject player);
}
