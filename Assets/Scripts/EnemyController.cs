using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private NavMeshAgent agent;
    public int enemyHP;
    [SerializeField]
    private int maxEnemyHP;

    void Start()
    {
        enemyHP = maxEnemyHP;
        target = GameObject.Find("DefenseBase");
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
            agent.destination = target.transform.position;   
    }

    public void AttackEnemy()
    {
        enemyHP = Mathf.Clamp(enemyHP--, 0, maxEnemyHP);
        if(enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
