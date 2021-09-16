using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    //private NavMeshAgent agent;
    public int enemyHP;
    [SerializeField]
    private int maxEnemyHP;
    [SerializeField]
    private int point;
    //private UIManager uiManager;
    public Tween tween;

    void Start()
    {
        enemyHP = maxEnemyHP;
        target = GameObject.Find("DefenseBase");
        tween = this.transform.DOMove(target.transform.position,5.0f).SetEase(Ease.Linear);
        //agent = GetComponent<NavMeshAgent>();
        //uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
        //if (target != null)
        //{ 
            //agent.destination = target.transform.position;
        //}
    }

    public void AttackEnemy()
    {
        enemyHP--;
        if(enemyHP <= 0)
        {
            Destroy(gameObject);
            this.tween.Kill();
            ScoreManager.instance.score += point;
            //uiManager.UpdateDisplayScore();
        }
    }
}
