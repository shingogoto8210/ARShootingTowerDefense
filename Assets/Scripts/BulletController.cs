using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private EnemyController enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out enemy))
        {
            enemy.AttackEnemy();
            Destroy(gameObject);
        }
    }
}
