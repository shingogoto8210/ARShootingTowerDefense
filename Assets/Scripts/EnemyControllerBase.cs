using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyControllerBase : MonoBehaviour
{
    protected GameObject target;
    public float enemyHP;
    [SerializeField]
    protected float maxEnemyHP;
    [SerializeField]
    protected int point;
    protected UIManager uiManager;
    public GameManager gameManager;
    public List<ItemControllerBase> itemsList = new List<ItemControllerBase>();
    [SerializeField]
    protected int dropRate;
    public Tween tween;
    private AudioSource audioSource;
    [SerializeField]
    private int addSkillPoint = 1;
    
    /// <summary>
    /// Enemyの初期設定
    /// </summary>
    protected virtual void Start()
    {
        enemyHP = maxEnemyHP;
        gameManager.enemiesList.Add(this);
        this.gameObject.transform.LookAt(target.transform);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(AudioDataBase.instance.enemySummonSound);
    }

    /// <summary>
    /// EnemyのHPを減らし，UIの更新をする
    /// </summary>
    public virtual void AttackEnemy()
    {
        enemyHP--;
        //コンボ数を増やして，更新する
        ScoreManager.instance.CountCombo();
        uiManager.UpdateDisplayCombo();
        //Mathf.Clampの中では++が使えないので注意する
        //gameManager.skillPoint = Mathf.Clamp(gameManager.skillPoint + 1, 0, 10);
        gameManager.UpdateSkillPoint(addSkillPoint);
        uiManager.UpdateDisplaySkillGage();
        audioSource.PlayOneShot(AudioDataBase.instance.enemyAttackSound);
        if (enemyHP <= 0)
        {
            DestroyEnemy();
        }
    }

    /// <summary>
    /// Enemyを破壊してリストからも削除する
    /// </summary>
    public virtual void DestroyEnemy()
    {
        //audioSource.PlayOneShot(AudioDataBase.instance.enemyDestroySound);

        JudgeDropItem();
        Destroy(this.gameObject);
        ScoreManager.instance.score += point;
        uiManager.UpdateDisplayScore();
        if (tween != null)
        {
            this.tween.Kill();
        }
        GameObject effect = Instantiate(EffectDataBase.instance.enemyDestroyEffect, new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), Quaternion.identity);
        Destroy(effect, 1.0f);
        gameManager.enemiesList.Remove(this);
        //gameManager.enemyCount--;
        gameManager.CheckClear();
        
    }

    /// <summary>
    /// 敵を破壊せず，見えなくする
    /// </summary>
    /// <param name="isSwitch"></param>
    public void SwitchGameObject(bool isSwitch)
    {
        this.gameObject.SetActive(isSwitch);
    }

    /// <summary>
    /// 任意の確率でアイテムが落ちる
    /// </summary>
    protected virtual void JudgeDropItem()
    {
        int number = 0;
        number = Random.Range(0, 100);
        if (number < dropRate)
        {
            int random = 0;
            random = Random.Range(0, itemsList.Count);
            ItemControllerBase item = Instantiate(itemsList[random], new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), Quaternion.identity);
            item.itemNo = random;
        }
    }

    /// <summary>
    /// 敵の動きを止める
    /// </summary>
    public void StopEnemy()
    {
        if(tween != null)
        {
            tween.Pause();
        }
    }

    /// <summary>
    /// 敵の動きを再開させる
    /// </summary>
    public void ResumeEnemy()
    {
        if(tween != null)
        {
            tween.Play();
        }
    }

    /// <summary>
    /// Enemyの初期設定
    /// </summary>
    /// <param name="gameManager"></param>
    public void SetUpEnemy(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.uiManager = gameManager.uiManager;
        this.target = gameManager.defenseBase.gameObject;
    }

    /// <summary>
    /// DefenseBaseに当たったとき敵を破壊する　アイテムは落ちない
    /// </summary>
    public virtual void DefenseBaseDestroyEnemy()
    {
        //audioSource.PlayOneShot(AudioDataBase.instance.enemyDestroySound);
        Destroy(this.gameObject);
        if (tween != null)
        {
            this.tween.Kill();
        }
        gameManager.enemiesList.Remove(this);
        //gameManager.enemyCount--;
        gameManager.CheckClear();
    }
}
