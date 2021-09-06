using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BuildingsGenerator buildingsGenerator;
    [SerializeField]
    private EnemyGenerator enemy;
    [SerializeField, Header("��������")]
    private int limitTime;
    [SerializeField,Header("�c�莞��")]
    private int currentTime;
    private float timer;

    void Start()
    {
        //�����������t�B�[���h��Ɉړ�
        BuildingsController buildings = buildingsGenerator.GenerateBuildings();
        buildings.MoveBuildings();
        //TODO GameStart�̕����\����������
        //Enemy
        currentTime = limitTime;
        Debug.Log("�G�̐��������J�n");
        StartCoroutine(enemy.PrepareteGenerateEnemy());
    }


    void Update()
    {
        
        timer += Time.deltaTime;
        if(timer > 1)
        {
            currentTime--;
            timer = 0;
            if(currentTime <= 0)
            {
                currentTime = 0;
                Debug.Log("Game Over");
                Debug.Log("�G�̐����I��");
                enemy.isGenerate = false;
            }
        }
    }
}
