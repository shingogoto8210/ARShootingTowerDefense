using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyControllerBase
{

    protected override void Start()
    {
        base.Start();
        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        GameObject effect = Instantiate(EffectDataBase.instance.enemySummonEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.0f);
        this.gameObject.transform.LookAt(target.transform);
    }

    
    
}
