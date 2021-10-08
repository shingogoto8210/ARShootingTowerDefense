using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text txtScore;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private Text txtDebugMessage;
    [SerializeField]
    private Logo openingLogoPrefab;
    [SerializeField]
    private Logo clearLogoPrefab;
    [SerializeField]
    private Logo gameoverLogoPrefab;
    [SerializeField]
    private Transform canvasTran;
    public Logo openingLogo;
    public Logo clearLogo;
    public Logo gameoverLogo;
    [SerializeField]
    private Text txtCombo;
    [SerializeField]
    private Text txtTimer;
    [SerializeField]
    private Text txtComboBonus;
    [SerializeField]
    private Text txtTimeBonus;
    [SerializeField]
    private Text txtClearPoint;
    [SerializeField]
    private Text txtTotalClearPoint;



    public void UpdateDisplayScore()
    {
        txtScore.text = ScoreManager.instance.score.ToString();
    }

    public void DisplayDebug(string message)
    {
        txtDebugMessage.text = message;
    }

    public IEnumerator CreateOpeningLogo()
    {
        openingLogo = Instantiate(openingLogoPrefab, canvasTran, false);
        yield return null;
    }

    public IEnumerator CreateClearLogo()
    {
        clearLogo = Instantiate(clearLogoPrefab, canvasTran, false);
        yield return null;
    }

    public IEnumerator CreateGameOverLogo()
    {
        gameoverLogo = Instantiate(gameoverLogoPrefab, canvasTran, false);
        yield return null;
    }

    public void UpdateDisplayCombo()
    {
        txtCombo.text = ScoreManager.instance.comboCount.ToString();
    } 

    public void UpdateDisplayTimer()
    {
        txtTimer.text = gameManager.limitTime.ToString();
    }

    public void UpdateDisplayResult()
    {
        txtScore.text = ScoreManager.instance.score.ToString();
        txtComboBonus.text = ScoreManager.instance.comboBonas.ToString();
        txtTimeBonus.text = ScoreManager.instance.timeBonas.ToString();
        txtClearPoint.text = ScoreManager.instance.clearPoint.ToString();
    }

    public void UpdateDisplayTotalClearPoint()
    {
        txtTotalClearPoint.text = ScoreManager.instance.totalClearPoint.ToString();
    }

}
