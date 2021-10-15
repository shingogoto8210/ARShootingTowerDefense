using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorBase : MonoBehaviour
{
    protected GameManager gameManager;
    [SerializeField]
    public EnemyControllerBase enemyController;
    [SerializeField]
    private EnemyControllerBase bossController;

    protected void GenerateEnemy()
    {
        int random_x = Random.Range(-2, 2);
        int random_z = Random.Range(0, 2);
        EnemyControllerBase enemy = Instantiate(enemyController, new Vector3(transform.root.position.x + random_x, transform.root.position.y, transform.root.position.z + random_z), Quaternion.Euler(0, -180, 0));
        //GameObject effect = Instantiate(EffectDataBase.instance.enemySummonEffect, enemy.transform.position, Quaternion.identity);
        //Destroy(effect, 1.0f);
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
        yield return new WaitForSeconds(1.0f);
        if(bossController != null)
        {
            EnemyControllerBase boss = Instantiate(bossController, new Vector3(transform.root.position.x, transform.root.position.y, transform.root.position.z), Quaternion.Euler(0, -180, 0));
            boss.SetUpEnemy(gameManager);
            Instantiate(EffectDataBase.instance.bossStartEffect, new Vector3(boss.transform.position.x, boss.transform.position.y + 0.5f, boss.transform.position.z), Quaternion.identity);

        }
    }
}
