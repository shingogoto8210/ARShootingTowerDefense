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

}
