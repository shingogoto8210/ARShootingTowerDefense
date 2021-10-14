using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField]
    private EnemyControllerBase enemy;
    private Transform target;

    private void Start()
    {
        StartCoroutine(Teleport());
        target = enemy.gameManager.stage.defenseBase.transform;
    }

    public void MoveRandom()
    {
        float randomPos_x = Random.Range(-1.5f, 1.5f);
        float randomPos_y = Random.Range(0.5f, 1.5f);
        float randomPos_z = Random.Range(0, 2.0f);
        transform.position = new Vector3(randomPos_x, randomPos_y, randomPos_z);
        this.gameObject.transform.LookAt(target) ;

    }
    public IEnumerator Teleport()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            float randomTime = Random.Range(3.0f, 6.0f);
            MoveRandom();
            yield return new WaitForSeconds(randomTime);
        }
    }
}
