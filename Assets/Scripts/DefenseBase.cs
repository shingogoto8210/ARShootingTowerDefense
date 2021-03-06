using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class DefenseBase : MonoBehaviour
{
    public float dbHP;
    [SerializeField]
    public float maxdbHP;
    [SerializeField]
    private GameManager gameManager;
    private AudioSource audioSource;

    /// <summary>
    /// DefenseBaseの初期設定
    /// </summary>
    void Start()
    {
        dbHP = maxdbHP;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// EnemyControllerBaseのコンポーネント持つオブジェクトか，EnemyLaserのタグを持っていたら，DefenseBaseのHPを減らす
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out EnemyControllerBase enemy))
        {
            audioSource.PlayOneShot(AudioDataBase.instance.enemyDestroySound);
            //dbHP--;
            UpdateDefenseBaseHP(-1);
            gameManager.uiManager.UpdateDisplayHPGage();
            GameObject effect = Instantiate(EffectDataBase.instance.defenseBaseAttackEffect, new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), Quaternion.identity);
            Destroy(effect, 1.0f);
            enemy.DefenseBaseDestroyEnemy();
            if(dbHP <= 0)
            {
                dbHP = 0;
                Destroy(gameObject);
                gameManager.GameOver();
            }
        }
        else if (other.gameObject.CompareTag("EnemyLaser"))
        {
            audioSource.PlayOneShot(AudioDataBase.instance.enemyDestroySound);
            //dbHP--;
            UpdateDefenseBaseHP(-1);
            gameManager.uiManager.UpdateDisplayHPGage();
            GameObject effect = Instantiate(EffectDataBase.instance.defenseBaseAttackEffect, new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), Quaternion.identity);
            Destroy(effect, 1.0f);
            if (dbHP <= 0)
            {
                dbHP = 0;
                Destroy(gameObject);
                gameManager.GameOver();
            }
        }
    }

    //HPを増減させる
    public void UpdateDefenseBaseHP(int point)
    {
        //dbHP += point;
        dbHP = Mathf.Clamp(dbHP + point, 0, 10);
    }
}
