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
    public List<ItemController> itemsList = new List<ItemController>();
    //private Rigidbody rb;
    [SerializeField]
    private int dropRate;

    void Start()
    {
        enemyHP = maxEnemyHP;
        //rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.enemiesList.Add(this);
        target = GameObject.Find("DefenseBase");
        if (target != null)
        {
            tween = this.gameObject.transform.DOMove(target.transform.position, 4.0f).SetEase(Ease.Linear);
            //tween = rb.DOMove(target.transform.position, 4.0f).SetEase(Ease.Linear);
        }
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void Update()
    {
        if(target == null)
        {
            this.tween.Kill();
        }
    }

    //“G‚ÌHP‚ðŒ¸‚ç‚·
    public void AttackEnemy()
    {
        enemyHP--;
        ScoreManager.instance.comboCount++;
        if(enemyHP <= 0)
        {
            effect = Instantiate(effectPrefab, new Vector3(transform.position.x,transform.position.y + 0.25f, transform.position.z), Quaternion.identity);
            Destroy(effect, 1.0f);
            ScoreManager.instance.score += point;
            uiManager.UpdateDisplayScore();
            JudgeDropItem();
            DestoryEnemy();
        }
    }

    public void DestoryEnemy()
    {
        Destroy(this.gameObject);
        this.tween.Kill();
        gameManager.enemyCount--;
    }

    public void StopEnemy()
    {
        tween.Pause();
    }

    public void ResumeEnemy()
    {
        tween.Play();
    }

    private void JudgeDropItem()
    {
        dropRate = Random.Range(0,100);
        if(dropRate > 70)
        {
            int random = 0;
            random = Random.Range(0, itemsList.Count);
            ItemController item = Instantiate(itemsList[random], new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), Quaternion.identity);
            item.itemNo = random;
            Destroy(item.gameObject, 5.0f);
        }
    }

}
