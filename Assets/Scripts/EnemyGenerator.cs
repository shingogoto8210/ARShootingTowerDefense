using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private int intervalGenerateTime;
    [SerializeField]
    private EnemyController enemyController;
    public bool isGenerate;

    /// <summary>
    /// “G‚Ì¶¬
    /// </summary>
    void GenerateEnemy()
    {
        float random_x = Random.Range(-5.0f, 5.0f);
        float random_z = Random.Range(0, 5.0f);
        EnemyController enemy = Instantiate(enemyController, new Vector3(random_x, transform.position.y, random_z), Quaternion.Euler(0, -180, 0));
    }

    /// <summary>
    /// “G‚Ì¶¬€”õŠJn
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
