using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemyController : EnemyControllerBase
{
    /// <summary>
    /// LaserEnemy�̃|�W�V������ύX���CDefenseBase�̂ق��Ɍ���
    /// </summary>
    protected override void Start()
    {
        base.Start();
        //�]���r�Ɠ��������W�ɐ��������̂ňʒu����������
        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        GameObject effect = Instantiate(EffectDataBase.instance.enemySummonEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.0f);
        this.gameObject.transform.LookAt(target.transform);
    }


}
