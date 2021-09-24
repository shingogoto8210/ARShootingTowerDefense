using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ARManager arManager;
    [SerializeField]
    private SpawnField spawnField;
    public int enemyCount;
    public int maxEnemyCount;
    [SerializeField]
    private Logo logo;
    public ARState currentGameState;
    public int nextStageNo;
    private StageData nextStageData;
    [SerializeField]
    private ChangeOpeningLogo changeOpeningLogo;

    IEnumerator Start()
    {
        enemyCount = maxEnemyCount;
        if (currentGameState == ARState.Debug)
        {
            currentGameState = ARState.Ready;
            yield return StartCoroutine(logo.PlayOpening());
            currentGameState = ARState.Play;
        }
    }


    void Update()
    {
        if (enemyCount <= 0 && currentGameState == ARState.Play)
        {
            enemyCount = 0;
            Destroy(spawnField.fieldObj);
            //StartCoroutine(logo.PlayClear());
            currentGameState = ARState.Ready;
            nextStageNo++;
            changeOpeningLogo.ChangeLogo();
            StartCoroutine(SetUpNextStage());
        }
    }

    public IEnumerator SetUpNextStage()
    {
        nextStageData = DataBaseManager.instance.stageDataSO.stageDatasList[nextStageNo];
        maxEnemyCount = nextStageData.enemyCount;
        enemyCount = maxEnemyCount;
        Instantiate(nextStageData.stagePrefab,spawnField.fieldPos,Quaternion.identity);
        yield return StartCoroutine(logo.PlayClear());
        currentGameState = ARState.Play;
        if(nextStageNo == DataBaseManager.instance.stageDataSO.stageDatasList.Count)
        {
            currentGameState = ARState.GameUp;
            SceneManager.LoadScene("Clear");
        }
    }
}
