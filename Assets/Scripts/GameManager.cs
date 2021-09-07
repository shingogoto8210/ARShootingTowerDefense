using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BuildingsGenerator buildingsGenerator;
    [SerializeField]
    private EnemyGenerator enemy;
    [SerializeField, Header("制限時間")]
    private int limitTime;
    [Header("残り時間")]
    public int currentTime;
    private float timer;
    [SerializeField]
    private UIManager uiManager;

    void Start()
    {
        //建物生成→フィールド上に移動
        BuildingsController buildings = buildingsGenerator.GenerateBuildings();
        buildings.MoveBuildings();
        //TODO GameStartの文字表示→消える
        //Enemy
        currentTime = limitTime;
        uiManager.UpdateDisplayTimer();
        StartCoroutine(enemy.PrepareteGenerateEnemy());
    }


    void Update()
    {
        
        timer += Time.deltaTime;
        if(timer > 1)
        {
            currentTime--;
            uiManager.UpdateDisplayTimer();
            timer = 0;
            if(currentTime <= 0)
            {
                currentTime = 0;
                Debug.Log("Game Over");
                enemy.isGenerate = false;
            }
        }
    }
}
