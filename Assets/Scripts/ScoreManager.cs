using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int comboCount;
    public float comboTimer;
    [SerializeField]
    private GameManager gameManager;
    public int clearPoint;
    public int timeBonas;
    public int comboBonas;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(gameManager.currentGameState == ARState.Play)
        {
            comboTimer += Time.deltaTime;
            if (comboTimer >= 5.0f)
            {
                comboTimer = 0;
                comboCount = 0;
            }
        }
    }

    public void CulculateScore()
    {
        timeBonas = gameManager.limitTime * 10;
        comboBonas = ScoreManager.instance.comboCount * 100;
        clearPoint = timeBonas + comboBonas + ScoreManager.instance.score;
    }
}
