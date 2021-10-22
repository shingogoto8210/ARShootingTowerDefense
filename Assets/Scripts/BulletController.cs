using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private EnemyControllerBase enemy;

    /// <summary>
    /// Bullet‚ªEnemyControllerBase‚ğ‚Á‚Ä‚¢‚½‚ç“G‚ÉUŒ‚‚·‚é
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out enemy))
        {
            enemy.AttackEnemy();
            GameObject effect = Instantiate(EffectDataBase.instance.enemyAttackEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f), Quaternion.identity);
            Destroy(effect, 1.0f);
            Destroy(gameObject);
        }
    }
}
