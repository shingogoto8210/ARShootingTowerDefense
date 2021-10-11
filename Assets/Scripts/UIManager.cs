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
    [SerializeField]
    private Image imgHPGage;
    [SerializeField]
    private Image imgSkillGage;
    [SerializeField]
    public GameObject iceButton;
    [SerializeField]
    public GameObject meteorButton;
    [SerializeField]
    public GameObject lightningButton;


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
        yield return StartCoroutine(openingLogo.LogoEffect());
    }

    public IEnumerator CreateClearLogo()
    {
        clearLogo = Instantiate(clearLogoPrefab, canvasTran, false);
        yield return StartCoroutine(clearLogo.LogoEffect());
    }

    public IEnumerator CreateGameOverLogo()
    {
        gameoverLogo = Instantiate(gameoverLogoPrefab, canvasTran, false);
        yield return StartCoroutine(gameoverLogo.LogoEffect());
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

    public void UpdateDisplayHPGage()
    {
        imgHPGage.fillAmount = gameManager.defenseBase.dbHP / gameManager.defenseBase.maxdbHP;
        if (imgHPGage.fillAmount <= 0)
        {
            imgHPGage.fillAmount = 0;
        }
    }

    public void UpdateDisplaySkillGage()
    {
        imgSkillGage.fillAmount = gameManager.skillPoint / 10;
        if (imgSkillGage.fillAmount >= 10)
        {
            imgSkillGage.fillAmount = 10;
        }
        UpdateDisplaySkillButton();
    }

    public void UpdateDisplaySkillButton()
    {
        if(gameManager.skillPoint >= 3)
        {
            lightningButton.GetComponent<Button>().interactable = true;
            meteorButton.GetComponent<Button>().interactable = false;
            iceButton.GetComponent<Button>().interactable = false;
        }
        if (gameManager.skillPoint >= 5)
        {
            lightningButton.GetComponent<Button>().interactable = true;
            meteorButton.GetComponent<Button>().interactable = true;
            iceButton.GetComponent<Button>().interactable = false;

        }
        if (gameManager.skillPoint >= 8)
        {
            lightningButton.GetComponent<Button>().interactable = true;
            meteorButton.GetComponent<Button>().interactable = true;
            iceButton.GetComponent<Button>().interactable = true;
        }
        if(gameManager.skillPoint < 3)
        {
            lightningButton.GetComponent<Button>().interactable = false;
            meteorButton.GetComponent<Button>().interactable = false;
            iceButton.GetComponent<Button>().interactable = false;
        }
        Debug.Log(gameManager.skillPoint);
    }

    
}
