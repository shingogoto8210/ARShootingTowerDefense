using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    public int enemyHP;
    [SerializeField]
    private int maxEnemyHP;
    [SerializeField]
    private int point;
    private UIManager uiManager;
    public Tween tween;
    private GameManager gameManager;
    [SerializeField]
    private GameObject effectPrefab;
    private GameObject effect;

    void Start()
    {
        enemyHP = maxEnemyHP;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        target = GameObject.Find("DefenseBase");
        tween = this.transform.DOMove(target.transform.position, 4.0f).SetEase(Ease.Linear);
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void Update()
    {
        if(target == null)
        {
            this.tween.Kill();
        }
    }

    public void AttackEnemy()
    {
        enemyHP--;
        if(enemyHP <= 0)
        {
            effect = Instantiate(effectPrefab, new Vector3(transform.position.x,transform.position.y + 0.25f, transform.position.z), Quaternion.identity);
            Destroy(effect, 1.0f);
            ScoreManager.instance.score += point;
            uiManager.UpdateDisplayScore();
            DestoryEnemy();
        }
    }

    public void DestoryEnemy()
    {
        Destroy(this.gameObject);
        this.tween.Kill();
        gameManager.enemyCount--;
    }

}
