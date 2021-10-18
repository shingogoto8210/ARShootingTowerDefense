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
        float randomPos_x = Random.Range(-2, 2);
        float randomPos_y = Random.Range(1, 3);
        float randomPos_z = Random.Range(-1, 2);
        transform.position = new Vector3(enemy.gameManager.stage.transform.position.x + randomPos_x, enemy.gameManager.stage.transform.position.y+ randomPos_y, enemy.gameManager.stage.transform.position.z + randomPos_z);
        this.gameObject.transform.LookAt(target) ;

    }
    public IEnumerator Teleport()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            float randomTime = Random.Range(5.0f, 10.0f);
            MoveRandom();
            yield return new WaitForSeconds(randomTime);
        }
    }

}
