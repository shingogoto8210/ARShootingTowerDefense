using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private EnemyControllerBase laserEnemy;
    [SerializeField]
    private EnemyControllerBase enemy;
    [SerializeField]
    private EnemyControllerBase boss;
    public GameManager gameManager;
    private float timer;
    private int generateTimer;
    [SerializeField]
    private int maxGenerateTimer;
    [SerializeField]
    private Text txtGenerateCount;
    void Start()
    {
        gameManager = boss.gameManager;
        generateTimer = maxGenerateTimer;
    }

    void Update()
    {
        if (gameManager.currentGameState == ARState.Play && gameManager.isStop == false)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                generateTimer--;
                UpdateDisplayShotLaserCount();
                if (generateTimer <= 0)
                {
                    Generate();
                    generateTimer = maxGenerateTimer;
                   // Debug.Log(maxShotTimer);
                }
            }
        }
    }


    private void Generate()
    {
        GameObject effect = Instantiate(EffectDataBase.instance.enemySummonEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.0f);
        EnemyControllerBase enemy_0 = Instantiate(laserEnemy, new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z), Quaternion.Euler(0,-180,0));
        EnemyControllerBase enemy_1 = Instantiate(enemy, new Vector3(transform.position.x, gameManager.stage.transform.position.y, transform.position.z), Quaternion.Euler(0, -180, 0));
        EnemyControllerBase enemy_2 = Instantiate(laserEnemy, new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z), Quaternion.Euler(0, -180, 0));
        enemy_0.SetUpEnemy(gameManager);
        enemy_1.SetUpEnemy(gameManager);
        enemy_2.SetUpEnemy(gameManager);


    }

    private void UpdateDisplayShotLaserCount()
    {
        txtGenerateCount.text = generateTimer.ToString();
    }
}
