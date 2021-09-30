using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class SpawnField : MonoBehaviour
{
    [SerializeField]
    private GameObject fieldPrefab;
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
                    Instantiate(fieldPrefab, new Vector3(hitPose.position.x, hitPose.position.y, hitPose.position.z + 2.0f), hitPose.rotation);
                    gameManager.currentGameState = ARState.Ready;
                    StartCoroutine(uiManager.CreateOpeningLogo());
                    StartCoroutine(uiManager.openingLogo.LogoEffect());
                    isSpawnField = true;
                }
            }
        }
    }
}
