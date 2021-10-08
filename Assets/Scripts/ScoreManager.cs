using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int comboCount;
    public float comboTimer;
    public int clearPoint;
    public int timeBonas;
    public int comboBonas;
    public int totalClearPoint;

    void Awake()
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

    public void CountCombo()
    {
        comboCount++;
        comboTimer = 0;
    }

    public void ResetComboTimer()
    {
        comboTimer += Time.deltaTime;
        if (comboTimer >= 5.0f)
        {
            comboTimer = 0;
            comboCount = 0;
        }
    }
}
