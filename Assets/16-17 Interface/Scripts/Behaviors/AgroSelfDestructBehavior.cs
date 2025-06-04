using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AgroSelfDestructBehavior : IEnemyBehavior
{
    public void Update(GameObject enemy, GameObject player)
    {
        GameObject.Destroy(enemy);
    }
}
