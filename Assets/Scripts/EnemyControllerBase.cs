using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyControllerBase : MonoBehaviour
{
    protected GameObject target;
    public int enemyHP;
    [SerializeField]
    protected int maxEnemyHP;
    [SerializeField]
    protected int point;
    protected UIManager uiManager;
    protected GameManager gameManager;
    [SerializeField]
    protected GameObject effectPrefab;
    protected GameObject effect;
    public List<ItemController> itemsList = new List<ItemController>();
    [SerializeField]
    protected int dropRate;
    public Tween tween;
    

    protected virtual void Start()
    {
        enemyHP = maxEnemyHP;
    }

    public virtual void AttackEnemy()
    {
        enemyHP--;
        ScoreManager.instance.comboCount++;
        if (enemyHP <= 0)
        {
            effect = Instantiate(effectPrefab, new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), Quaternion.identity);
            Destroy(effect, 1.0f);
            ScoreManager.instance.score += point;
            ScoreManager.instance.comboTimer = 0;
            uiManager.UpdateDisplayScore();
            JudgeDropItem();
            DestoryEnemy();
        }
    }

    public virtual void DestoryEnemy()
    {
        Destroy(this.gameObject);
        if (tween != null)
        {
            this.tween.Kill();
        }
        gameManager.enemyCount--;
    }

    protected virtual void JudgeDropItem()
    {
        int number = 0;
        number = Random.Range(0, 100);
        if (number < dropRate)
        {
            int random = 0;
            random = Random.Range(0, itemsList.Count);
            ItemController item = Instantiate(itemsList[random], new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), Quaternion.identity);
            item.itemNo = random;
            //Destroy(item.gameObject, 5.0f);
        }
    }

    public void StopEnemy()
    {
        tween.Pause();
    }

    public void ResumeEnemy()
    {
        tween.Play();
    }

    public void SetUpEnemy(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.uiManager = gameManager.uiManager;
        this.target = gameManager.defenseBase.gameObject;
    }
}
