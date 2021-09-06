using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private int intervalGenerateTime;
    [SerializeField]
    private GameObject enemy;
    public bool isGenerate;

    void GenerateEnemy()
    {
        float random_x = Random.Range(-3.0f, 3.0f);
        float random_z = Random.Range(0, 3.0f);
        Instantiate(enemy, new Vector3(random_x, transform.position.y, random_z), Quaternion.Euler(0, -90.0f, 0));
    }

    public IEnumerator PrepareteGenerateEnemy()
    {
        int timer = 0;
        isGenerate = true;
        while (isGenerate)
        {
            timer++;
            if (timer > intervalGenerateTime)
            {
                GenerateEnemy();
                timer = 0;
            }
            yield return null;
        }
    }
}
