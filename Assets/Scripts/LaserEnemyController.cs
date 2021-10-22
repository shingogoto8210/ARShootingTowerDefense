using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemyController : EnemyControllerBase
{
    /// <summary>
    /// LaserEnemyのポジションを変更し，DefenseBaseのほうに向く
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //ゾンビと同じｙ座標に生成されるので位置を高くする
        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        GameObject effect = Instantiate(EffectDataBase.instance.enemySummonEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.0f);
        this.gameObject.transform.LookAt(target.transform);
    }


}
