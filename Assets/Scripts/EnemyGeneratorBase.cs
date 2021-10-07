using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorBase : MonoBehaviour
{
    protected GameManager gameManager;
    [SerializeField]
    public EnemyControllerBase enemyController;

    protected void GenerateEnemy()
    {
        float random_x = Random.Range(-1.5f, 1.5f);
        float random_z = Random.Range(0, 1.5f);
        EnemyControllerBase enemy = Instantiate(enemyController, new Vector3(transform.root.position.x + random_x, transform.root.position.y, transform.root.position.z + random_z), Quaternion.Euler(0, -180, 0));
        gameManager.generateCount++;
        enemy.SetUpEnemy(gameManager);
    }

    public void SetUpGenerator(GameManager gameManager)
    {
        this.gameManager = gameManager;
        StartCoroutine(PrepareteGenerateEnemy());
    }

    public IEnumerator PrepareteGenerateEnemy()
    {
        gameManager.isGenerate = true;
        while (gameManager.isGenerate)
        {
            if (gameManager.currentGameState == ARState.Play)
            {
                GenerateEnemy();
            }
            if (gameManager.generateCount >= gameManager.enemyCount)
            {
                gameManager.isGenerate = false;
            }
            yield return null;
        }
    }
}
