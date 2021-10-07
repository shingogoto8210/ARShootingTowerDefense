using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemyController : EnemyControllerBase
{
    protected override void Start()
    {
        base.Start();
        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        this.gameObject.transform.LookAt(target.transform);
    }
}
