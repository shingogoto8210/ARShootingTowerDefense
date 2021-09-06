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

    /// <summary>
    /// 敵の生成
    /// </summary>
    void GenerateEnemy()
    {
        float random_x = Random.Range(-5.0f, 5.0f);
        float random_z = Random.Range(0, 5.0f);
        Debug.Log("敵生成");
        Instantiate(enemy, new Vector3(random_x, transform.position.y, random_z), Quaternion.Euler(0, -180, 0));
    }

    /// <summary>
    /// 敵の生成準備開始
    /// </summary>
    /// <returns></returns>
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
