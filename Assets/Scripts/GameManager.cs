using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemyCount;
    public int generateCount;
    public bool isGenerate;
    public ARState currentGameState;
    public UIManager uiManager;
    public List<EnemyControllerBase> enemiesList = new List<EnemyControllerBase>();
    public DefenseBase defenseBase;
    public StageManager stage;
    public int limitTime = 60;
    private float timer;
    public bool isStop;
    public float skillPoint;
    public AudioSource audioSource;
    public bool isSkill;
    public GameObject mainCamera;
    public GameObject arSessionOrigin;
    

    IEnumerator Start()
    {
        //プラットフォームに応じてカメラとARステートの自動切換え
        SwitchCameraAndARStateToPlatform();
        //ゲームの初期設定
        GameStartToCommon();
        if (currentGameState == ARState.Debug)
        {
            //ARの場合はステージを生成したときにARStateが切り替わる
            currentGameState = ARState.Ready;
            stage = Instantiate(DataBaseManager.instance.stageDataSO.stageDatasList[GameData.instance.stageNo].stagePrefab, transform.position, Quaternion.identity); ;
            for (int i = 0; i< stage.enemyGenerators.Length; i++)
            {
                stage.enemyGenerators[i].SetUpGenerator(this);
            }
            defenseBase = stage.defenseBase;
            yield return StartCoroutine(uiManager.CreateOpeningLogo());
            audioSource.Play();
            yield return StartCoroutine(uiManager.openingLogo.LogoEffect());
            uiManager.UpdateDisplayHPGage();
            uiManager.UpdateDisplaySkillGage();
            currentGameState = ARState.Play;
        }
    }

    /// <summary>
    /// 制限時間とコンボタイマーを回す
    /// </summary>
    void Update()
    {
        if(currentGameState == ARState.Play)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                limitTime--;
                uiManager.UpdateDisplayTimer();
                timer = 0;
                if (limitTime <= 0)
                {
                    limitTime = 0;
                    GameOver();
                }
            }
            ScoreManager.instance.ResetComboTimer();
            uiManager.UpdateDisplayCombo();
        }
    }

    /// <summary>
    /// enemiesListの数が0よりも小さくなったらARStateをGameUPにして，リザルトシーンに遷移
    /// </summary>
    public void CheckClear()
    {
        //if (enemyCount <= 0 && currentGameState == ARState.Play)
        if (enemiesList.Count <= 0 && currentGameState == ARState.Play)

        {
            enemyCount = 0;
            currentGameState = ARState.GameUp;
            CulculateScore();
            StartCoroutine(uiManager.CreateClearLogo());
            SceneStateManager.instance.PreparateLoadSceneState(SceneState.Result, 6.0f);
        }
    }

    /// <summary>
    /// トータルクリアポイントの計算
    /// </summary>
    private void CulculateScore()
    {
        ScoreManager.instance.timeBonas = limitTime * 100;
        ScoreManager.instance.comboBonas = ScoreManager.instance.comboCount * 10;
        ScoreManager.instance.clearPoint = ScoreManager.instance.timeBonas + ScoreManager.instance.comboBonas + ScoreManager.instance.score;
        ScoreManager.instance.totalClearPoint += ScoreManager.instance.clearPoint;
    }
    
    /// <summary>
    /// 全ての敵の動きを止め，ゲームオーバーシーンに遷移
    /// </summary>
    public void GameOver()
    {
        currentGameState = ARState.GameUp;
        for (int i = 0; i < enemiesList.Count; i++)
        {
            enemiesList[i].tween.Kill();
        }
        StartCoroutine(uiManager.CreateGameOverLogo());
        SceneStateManager.instance.PreparateLoadSceneState(SceneState.StageSelect, 6.0f);
    }

    /// <summary>
    /// スコアとコンボカウント，スキルポイントを初期化し，UIを更新する
    /// 敵の数はGameDataの指定されたStageNoの数に合わせる
    /// </summary>
    public void GameStartToCommon()
    {
        ScoreManager.instance.score = 0;
        ScoreManager.instance.comboCount = 0;
        skillPoint = 0;
        uiManager.UpdateDisplaySkillButton();
        uiManager.UpdateDisplayTimer();
        //uiManager.UpdateDisplayHPGage();
        uiManager.UpdateDisplaySkillGage();
        uiManager.UpdateDisplayCombo();
        enemyCount = DataBaseManager.instance.stageDataSO.stageDatasList[GameData.instance.stageNo].enemyCount;
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// プラットフォームに応じてカメラとARステートの自動切換え
    /// </summary>
    private void SwitchCameraAndARStateToPlatform()
    {
#if UNITY_EDITOR
        currentGameState = ARState.Debug;
        arSessionOrigin.SetActive(false);
#elif UNITY_ANDROID
        currentGameState = ARState.Tracking;
        mainCamera.SetActive(false);
#endif
    }

    public void UpdateSkillPoint(int point)
    {
        //skillPoint += point;
        skillPoint = Mathf.Clamp(skillPoint + point, 0, 10);
    }
    

}

