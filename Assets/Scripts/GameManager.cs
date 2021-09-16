using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField]
    //private BuildingsGenerator buildingsGenerator;
    //[SerializeField]
    //private EnemyGenerator enemy;
    [SerializeField, Header("��������")]
    private int limitTime;
    [Header("�c�莞��")]
    public int currentTime;
    private float timer;
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private ARManager arManager;

    void Start()
    {
        //�����������t�B�[���h��Ɉړ�
        //BuildingsController buildings = buildingsGenerator.GenerateBuildings();
        //buildings.MoveBuildings();
        currentTime = limitTime;
        uiManager.UpdateDisplayTimer();
        //StartCoroutine(enemy.PrepareteGenerateEnemy());
    }


    void Update()
    {
        if(arManager.currentARState == ARState.Play)
        timer += Time.deltaTime;
        if(timer > 1)
        {
            currentTime--;
            uiManager.UpdateDisplayTimer();
            timer = 0;
            if(currentTime <= 0)
            {
                currentTime = 0;
                Debug.Log("Clear");
                //enemy.isGenerate = false;
                SceneManager.LoadScene("Clear");

            }
        }
    }
}
