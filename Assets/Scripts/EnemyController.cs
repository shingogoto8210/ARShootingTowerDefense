using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : EnemyControllerBase
{
    protected override void Start()
    {
        base.Start();
        if (target != null)
        {
            float random = Random.Range(10.0f, 20.0f);
            tween = this.gameObject.transform.DOMove(target.transform.position, random).SetEase(Ease.Linear);
        }
    }
}
