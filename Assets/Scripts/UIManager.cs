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
    public SkillButton iceButton;
    [SerializeField]
    public SkillButton meteorButton;
    [SerializeField]
    public SkillButton lightningButton;


    /// <summary>
    /// �X�R�A�̍X�V
    /// </summary>
    public void UpdateDisplayScore()
    {
        txtScore.text = ScoreManager.instance.score.ToString();
    }

    /// <summary>
    /// ARState��Debug���b�Z�[�W�̍X�V
    /// </summary>
    /// <param name="message"></param>
    public void DisplayDebug(string message)
    {
        txtDebugMessage.text = message;
    }

    /// <summary>
    /// �I�[�v�j���O���S�̐���
    /// </summary>
    /// <returns></returns>
    public IEnumerator CreateOpeningLogo()
    {
        openingLogo = Instantiate(openingLogoPrefab, canvasTran, false);
        //yield return StartCoroutine(openingLogo.LogoEffect());
        yield return new WaitForSeconds(1.0f);
    }

    /// <summary>
    /// �N���A���S�̐���
    /// </summary>
    /// <returns></returns>
    public IEnumerator CreateClearLogo()
    {
        clearLogo = Instantiate(clearLogoPrefab, canvasTran, false);
        yield return StartCoroutine(clearLogo.LogoEffect());
    }

    /// <summary>
    /// �Q�[���I�[�o�[���S�̐���
    /// </summary>
    /// <returns></returns>
    public IEnumerator CreateGameOverLogo()
    {
        gameoverLogo = Instantiate(gameoverLogoPrefab, canvasTran, false);
        yield return StartCoroutine(gameoverLogo.LogoEffect());
    }

    /// <summary>
    /// �R���{���̍X�V
    /// </summary>
    public void UpdateDisplayCombo()
    {
        txtCombo.text = ScoreManager.instance.comboCount.ToString();
    }

    /// <summary>
    /// �^�C�}�[�̍X�V
    /// </summary>
    public void UpdateDisplayTimer()
    {
        txtTimer.text = gameManager.limitTime.ToString();
    }

    /// <summary>
    /// ���U���g��ʂ̍X�V
    /// </summary>
    public void UpdateDisplayResult()
    {
        txtScore.text = ScoreManager.instance.score.ToString();
        txtComboBonus.text = ScoreManager.instance.comboBonas.ToString();
        txtTimeBonus.text = ScoreManager.instance.timeBonas.ToString();
        txtClearPoint.text = ScoreManager.instance.clearPoint.ToString();
    }

    /// <summary>
    /// �X�e�[�W�Z���N�g��ʂ̃g�[�^���N���A�|�C���g�̍X�V
    /// </summary>
    public void UpdateDisplayTotalClearPoint()
    {
        txtTotalClearPoint.text = ScoreManager.instance.totalClearPoint.ToString();
    }

    /// <summary>
    /// HP�Q�[�W�̍X�V
    /// </summary>
    public void UpdateDisplayHPGage()
    {
        imgHPGage.fillAmount = gameManager.defenseBase.dbHP / gameManager.defenseBase.maxdbHP;
        if (imgHPGage.fillAmount <= 0)
        {
            imgHPGage.fillAmount = 0;
        }
    }

    /// <summary>
    /// �X�L���Q�[�W�̍X�V
    /// </summary>
    public void UpdateDisplaySkillGage()
    {
        imgSkillGage.fillAmount = gameManager.skillPoint / 10;
        if (imgSkillGage.fillAmount >= 10)
        {
            imgSkillGage.fillAmount = 10;
        }
        UpdateDisplaySkillButton();
    }

    /// <summary>
    /// �X�L���{�^���̍X�V
    /// </summary>
    public void UpdateDisplaySkillButton()
    {
        if (gameManager.skillPoint >= SkillButton.lightningPoint && gameManager.isSkill == false)
        {
            lightningButton.GetComponent<Button>().interactable = true;
            meteorButton.GetComponent<Button>().interactable = true;
            iceButton.GetComponent<Button>().interactable = true;
        }

        else if (gameManager.skillPoint >= SkillButton.meteorPoint && gameManager.isSkill == false)
        {
            lightningButton.GetComponent<Button>().interactable = false;
            meteorButton.GetComponent<Button>().interactable = true;
            iceButton.GetComponent<Button>().interactable = true;

        }
        else if (gameManager.skillPoint >= SkillButton.icePoint && gameManager.isSkill == false)
        {
            lightningButton.GetComponent<Button>().interactable = false;
            meteorButton.GetComponent<Button>().interactable = false;
            iceButton.GetComponent<Button>().interactable = true;
        }

        //if (gameManager.skillPoint < SkillButton.icePoint)
        else
        {
            lightningButton.GetComponent<Button>().interactable = false;
            meteorButton.GetComponent<Button>().interactable = false;
            iceButton.GetComponent<Button>().interactable = false;
        }
    }

    
}
