using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private EnemyController enemy;
    [SerializeField]
    private GameObject effectPrefab;
    private GameObject effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out enemy))
        {
            enemy.AttackEnemy();
            effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1.0f);
            Destroy(gameObject);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("StageArea"))
        {
            Destroy(gameObject);
            ScoreManager.instance.comboCount = 0;
        }
    }


}
