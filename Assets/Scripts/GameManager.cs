using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyCount;
    public int maxEnemyCount;
    public ARState currentGameState;
    [SerializeField]
    private UIManager uiManager;
    //[SerializeField]
    //private GameObject fieldPrefab;
    //[SerializeField]
    //private Transform fieldTran;

    IEnumerator Start()
    {
        enemyCount = maxEnemyCount;
        if (currentGameState == ARState.Debug)
        {
            //Instantiate(fieldPrefab, fieldTran.position, Quaternion.identity);
            currentGameState = ARState.Ready;
            yield return StartCoroutine(uiManager.CreateOpeningLogo());
            yield return StartCoroutine(uiManager.openingLogo.LogoEffect());
            currentGameState = ARState.Play;
        }
    }


    void Update()
    {
        uiManager.UpdateDisplayCombo();
        if (enemyCount <= 0 && currentGameState == ARState.Play)
        {
            enemyCount = 0;
            StartCoroutine(uiManager.CreateClearLogo());
            StartCoroutine(uiManager.clearLogo.LogoEffect());
            currentGameState = ARState.GameUp;
        }
    }
}

