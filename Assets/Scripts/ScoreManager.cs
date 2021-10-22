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

    /// <summary>
    /// �R���{���𑝂₵�C�R���{�^�C�}�[�����Z�b�g����
    /// </summary>
    public void CountCombo()
    {
        comboCount++;
        comboTimer = 0;
    }

    /// <summary>
    ///�@5�b�ȓ��Ɏ��̍U���������Ȃ���΁C�R���{�������Z�b�g�����
    /// </summary>
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
