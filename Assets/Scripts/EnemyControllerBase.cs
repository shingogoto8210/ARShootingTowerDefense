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
    /// Enemy�̏����ݒ�
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
    /// Enemy��HP�����炵�CUI�̍X�V������
    /// </summary>
    public virtual void AttackEnemy()
    {
        enemyHP--;
        //�R���{���𑝂₵�āC�X�V����
        ScoreManager.instance.CountCombo();
        uiManager.UpdateDisplayCombo();
        //Mathf.Clamp�̒��ł�++���g���Ȃ��̂Œ��ӂ���
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
    /// Enemy��j�󂵂ă��X�g������폜����
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
    /// �G��j�󂹂��C�����Ȃ�����
    /// </summary>
    /// <param name="isSwitch"></param>
    public void SwitchGameObject(bool isSwitch)
    {
        this.gameObject.SetActive(isSwitch);
    }

    /// <summary>
    /// �C�ӂ̊m���ŃA�C�e����������
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
    /// �G�̓������~�߂�
    /// </summary>
    public void StopEnemy()
    {
        if(tween != null)
        {
            tween.Pause();
        }
    }

    /// <summary>
    /// �G�̓������ĊJ������
    /// </summary>
    public void ResumeEnemy()
    {
        if(tween != null)
        {
            tween.Play();
        }
    }

    /// <summary>
    /// Enemy�̏����ݒ�
    /// </summary>
    /// <param name="gameManager"></param>
    public void SetUpEnemy(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.uiManager = gameManager.uiManager;
        this.target = gameManager.defenseBase.gameObject;
    }

    /// <summary>
    /// DefenseBase�ɓ��������Ƃ��G��j�󂷂�@�A�C�e���͗����Ȃ�
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
