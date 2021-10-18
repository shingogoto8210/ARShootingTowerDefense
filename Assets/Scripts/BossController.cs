using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : EnemyControllerBase
{
    
    [SerializeField]
    private Image imgBossHP;

    protected override void Start()
    {
        base.Start();
        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        GameObject effect = Instantiate(EffectDataBase.instance.enemySummonEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.0f);
        this.gameObject.transform.LookAt(target.transform);
        UpdateDisplayBossHPGage();
    }

    private void UpdateDisplayBossHPGage()
    {
        imgBossHP.fillAmount = this.enemyHP / this.maxEnemyHP;
        if (imgBossHP.fillAmount <= 0)
        {
            imgBossHP.fillAmount = 0;
        }
    }

    private void Update()
    {
        UpdateDisplayBossHPGage();
        
    }





}
