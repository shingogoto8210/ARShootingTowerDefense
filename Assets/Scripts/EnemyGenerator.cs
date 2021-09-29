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
    private int generateCount;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(PrepareteGenerateEnemy());
    }

    /// <summary>
    /// “G‚Ì¶¬
    /// </summary>
    void GenerateEnemy()
    {
        float random_x = Random.Range(-1.0f,1.0f);
        float random_z = Random.Range(0, 1.0f);
        Instantiate(enemyController, new Vector3(transform.root.position.x + random_x, transform.root.position.y, transform.root.position.z + random_z), Quaternion.Euler(0, -180, 0));
        generateCount++;
    }

    /// <summary>
    /// “G‚Ì¶¬€”õŠJn
    /// </summary>
    /// <returns></returns>
    public IEnumerator PrepareteGenerateEnemy()
    {
        int timer = 0;
        isGenerate = true;
        while (isGenerate )
        {
            timer++;
            if (timer > intervalGenerateTime)
            {
                timer = 0;
                if(gameManager.currentGameState == ARState.Play)
                {
                    GenerateEnemy();
                }
                if (generateCount >= gameManager.maxEnemyCount)
                {
                    isGenerate = false;
                }
            }
            yield return null;
        }
    }
}
