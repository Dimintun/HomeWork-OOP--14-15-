using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroRunAwayBehavior : IEnemyBehavior
{
    public void Update(GameObject enemy, GameObject player)
    {
        Vector3 direction = (player.transform.position - enemy.transform.position).normalized;
        enemy.transform.position -= direction * Time.deltaTime * 2f;
    }
}
