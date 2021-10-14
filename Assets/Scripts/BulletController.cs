using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //private EnemyController enemy;
    //private LaserEnemyController laserEnemy;
    private EnemyControllerBase enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out enemy))
        {
            enemy.AttackEnemy();
            GameObject effect = Instantiate(EffectDataBase.instance.enemyAttackEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.0f);
            Destroy(gameObject);
        }

        //else if(other.gameObject.TryGetComponent(out laserEnemy))
        //{
          //  laserEnemy.AttackEnemy();
            //GameObject effect = Instantiate(EffectDataBase.instance.enemyAttackEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), Quaternion.identity);
            //Destroy(effect, 1.0f);
            //Destroy(gameObject);
        //}
    }
}
