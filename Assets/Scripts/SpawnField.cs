using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class SpawnField : MonoBehaviour
{
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public bool isSpawnField;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private UIManager uiManager;

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        isSpawnField = false;
    }

    /// <summary>
    /// タップした場所にステージを生成して，gameManagerの初期設定を行う
    /// </summary>
    public void SpawnFieldObj()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon) && isSpawnField == false)
                {
                    Pose hitPose = hits[0].pose;
                    StageManager stage = Instantiate(DataBaseManager.instance.stageDataSO.stageDatasList[GameData.instance.stageNo].stagePrefab, new Vector3(hitPose.position.x, hitPose.position.y, hitPose.position.z + 2.0f), hitPose.rotation);
                    gameManager.currentGameState = ARState.Ready;
                    gameManager.stage = stage;
                    gameManager.defenseBase = stage.defenseBase;
                    for(int i = 0;i < stage.enemyGenerators.Length; i++)
                    {
                        stage.enemyGenerators[i].SetUpGenerator(gameManager);
                    }
                    StartCoroutine(uiManager.CreateOpeningLogo());
                    gameManager.audioSource.Play();
                    StartCoroutine(uiManager.openingLogo.LogoEffect());
                    isSpawnField = true;
                }
            }
        }
    }
}
