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
    /// ƒ‰ƒ“ƒ_ƒ€‚ÈêŠ‚É“G‚ğ¶¬‚µ‚ÄC“G‚Ì‰Šúİ’è‚ğs‚¤
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
    /// Generator‚Ì‰Šúİ’è‚ğ‚µ‚ÄC¶¬‚·‚é€”õ‚ğs‚¤
    /// </summary>
    /// <param name="gameManager"></param>
    public void SetUpGenerator(GameManager gameManager)
    {
        this.gameManager = gameManager;
        StartCoroutine(PrepareteGenerateEnemy());
    }

    /// <summary>
    /// ¶¬‚µ‚½”‚ªgameManager‚ÌenemyCount‚ğ’´‚¦‚é‚Ü‚Å“G‚ğ¶¬‚·‚é
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
