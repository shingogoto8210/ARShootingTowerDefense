using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : EnemyControllerBase
{
    /// <summary>
    /// Enemyの初期設定
    /// </summary>
    protected override void Start()
    {
        base.Start();
        GameObject effect = Instantiate(EffectDataBase.instance.enemySummonEffect,transform.position, Quaternion.identity);
        Destroy(effect, 1.0f);
        if (target != null)
        {
            //ランダムな速さでDefenseBaseまで近づく
            float random = Random.Range(10.0f, 20.0f);
            tween = this.gameObject.transform.DOMove(target.transform.position, random).SetEase(Ease.Linear);
        }
    }
}
