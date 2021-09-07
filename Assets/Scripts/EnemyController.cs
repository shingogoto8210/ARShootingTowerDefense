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
    [SerializeField]
    private int point;
    private UIManager uiManager;

    void Start()
    {
        enemyHP = maxEnemyHP;
        target = GameObject.Find("DefenseBase");
        agent = GetComponent<NavMeshAgent>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
            agent.destination = target.transform.position;   
    }

    public void AttackEnemy()
    {
        enemyHP--;
        if(enemyHP <= 0)
        {
            Destroy(gameObject);
            ScoreManager.instance.score += point;
            uiManager.UpdateDisplayScore();
        }
    }
}
