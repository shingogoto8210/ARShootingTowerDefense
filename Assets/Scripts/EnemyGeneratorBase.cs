using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGeneratorBase : MonoBehaviour
{
    protected GameManager gameManager;
    [SerializeField]
    public EnemyControllerBase enemyController;
    [SerializeField]
    private EnemyControllerBase bossController;
    
    /// <summary>
    /// ランダムな場所に敵を生成して，敵の初期設定を行う
    /// </summary>
    protected void GenerateEnemy()
    {
        float random_x = Random.Range(-2, 2);
        float random_z = Random.Range(-1, 2);
        EnemyControllerBase enemy = Instantiate(enemyController, new Vector3(transform.root.position.x + random_x, transform.root.position.y, transform.root.position.z + random_z), Quaternion.Euler(0, -180, 0));
        gameManager.generateCount++;
        enemy.SetUpEnemy(gameManager);
    }

    /// <summary>
    /// Generatorの初期設定をして，生成する準備を行う
    /// </summary>
    /// <param name="gameManager"></param>
    public void SetUpGenerator(GameManager gameManager)
    {
        this.gameManager = gameManager;
        StartCoroutine(PrepareteGenerateEnemy());
    }

    /// <summary>
    /// 生成した数がgameManagerのenemyCountを超えるまで敵を生成する
    /// </summary>
    /// <returns></returns>
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
        yield return null;
        if (bossController != null)
        {
            EnemyControllerBase boss = Instantiate(bossController, new Vector3(transform.root.position.x, transform.root.position.y, transform.root.position.z), Quaternion.Euler(0, -180, 0));
            boss.SetUpEnemy(gameManager);
            Instantiate(EffectDataBase.instance.bossStartEffect, new Vector3(boss.transform.position.x, boss.transform.position.y + 0.5f, boss.transform.position.z), Quaternion.identity);
        }
    }

    
}
