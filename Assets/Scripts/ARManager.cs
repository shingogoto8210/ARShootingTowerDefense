using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR.ARFoundation;
//using UnityEngine.XR.ARSubsystems;

public class ARManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private GameObject arWeaponObj;
    [SerializeField]
    private GameManager gameManager;
    private SpawnField spawnField;
    [SerializeField]
    private GameObject mainCamera;

    /// <summary>
    /// ARStateの初期設定
    /// </summary>
    void Start()
    {
        spawnField = GetComponent<SpawnField>();
        arWeaponObj.SetActive(false);
        if (gameManager.currentGameState == ARState.Debug)
        {
            this.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
        }
        else
        {
            gameManager.currentGameState = ARState.Tracking;
        }
    }

    /// <summary>
    /// 現在のARStateを確認して，次のARStateに切り替える
    /// </summary>
    void Update()
    {
        if(gameManager.currentGameState == ARState.Debug)
        {
            return;
        }
        if(Input.touchCount < 0)
        {
            return;
        }
        if(gameManager.currentGameState == ARState.Tracking)
        {
            spawnField.SpawnFieldObj();
            uiManager.DisplayDebug(gameManager.currentGameState.ToString());
        }else if(gameManager.currentGameState == ARState.Ready)
        {
            uiManager.DisplayDebug(gameManager.currentGameState.ToString());
            arWeaponObj.SetActive(true);
            gameManager.currentGameState = ARState.Wait;
            uiManager.DisplayDebug(gameManager.currentGameState.ToString());
            StartCoroutine(PreparateGameReady());
        }else if(gameManager.currentGameState == ARState.Play)
        {
            uiManager.DisplayDebug(gameManager.currentGameState.ToString());
        }
    }

    /// <summary>
    /// ARStateをReadyからPlayに切り替える
    /// </summary>
    /// <returns></returns>
    private IEnumerator PreparateGameReady()
    {
        yield return new WaitForSeconds(6.0f);
        uiManager.UpdateDisplayHPGage();
        gameManager.currentGameState = ARState.Play;
    }
}
