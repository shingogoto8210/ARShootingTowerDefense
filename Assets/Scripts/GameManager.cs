using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyCount;
    public int generateCount;
    public bool isGenerate;
    public ARState currentGameState;
    public UIManager uiManager;
    public List<EnemyController> enemiesList = new List<EnemyController>();
    public DefenseBase defenseBase;
    [SerializeField]
    private StageManager stage;
    public int stageNo;
    public int limitTime = 60;
    private float timer;
    

    IEnumerator Start()
    {
        uiManager.UpdateDisplayTimer();
        enemyCount = DataBaseManager.instance.stageDataSO.stageDatasList[stageNo].enemyCount;
        if (currentGameState == ARState.Debug)
        {
            currentGameState = ARState.Ready;
            for (int i = 0; i< stage.enemyGenerators.Length; i++)
            {
                stage.enemyGenerators[i].SetUpGenerator(this);
            }
            defenseBase = stage.defenseBase;
            yield return StartCoroutine(uiManager.CreateOpeningLogo());
            yield return StartCoroutine(uiManager.openingLogo.LogoEffect());
            currentGameState = ARState.Play;
        }
    }


    void Update()
    {
        if(currentGameState == ARState.Play)
        timer += Time.deltaTime;
        if(timer > 1)
        {
            limitTime--;
            uiManager.UpdateDisplayTimer();
            timer = 0;
            if(limitTime <= 0)
            {
                limitTime = 0;
                SceneStateManager.instance.PreparateLoadSceneState(SceneState.Title,1.0f);
            }
        }

        uiManager.UpdateDisplayCombo();
        if (enemyCount <= 0 && currentGameState == ARState.Play)
        {
            enemyCount = 0;
            StartCoroutine(uiManager.CreateClearLogo());
            StartCoroutine(uiManager.clearLogo.LogoEffect());
            currentGameState = ARState.GameUp;
            ScoreManager.instance.CulculateScore();
            SceneStateManager.instance.PreparateLoadSceneState(SceneState.Result,6.0f);
        }
        if(stage.defenseBase == null)
        {
            for(int i = 0;i < enemiesList.Count; i++)
            {
                enemiesList[i].tween.Kill();
            }
            SceneStateManager.instance.PreparateLoadSceneState(SceneState.Title,6.0f);
        }
        
    }

}

