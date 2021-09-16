using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private GameObject fieldObj;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> raycastHitList = new List<ARRaycastHit>();
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject weaponObj;
    public ARState currentARState;
    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }
    void Start()
    {
        if(currentARState == ARState.Debug)
        {

        }
        else
        {
            //fieldObj.SetActive(false);
            weaponObj.SetActive(false);
        }
    }

    void Update()
    {
        if(currentARState == ARState.Debug)
        {
            return;
        }
        if(Input.touchCount < 0)
        {
            return;
        }
        if(currentARState == ARState.Tracking)
        {
            TrackingPlane();
        }else if(currentARState == ARState.Ready)
        {
            currentARState = ARState.Wait;
            uiManager.DisplayDebug(currentARState.ToString());
            StartCoroutine(PreparateGameReady());
        }else if(currentARState == ARState.Play)
        {
            uiManager.DisplayDebug(currentARState.ToString());
        }
    }

    private void TrackingPlane()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                if (raycastManager.Raycast(touch.position, raycastHitList, TrackableType.PlaneWithinPolygon))
                {
                    uiManager.DisplayDebug("Raycast ê¨å˜");
                    Pose hitPose = raycastHitList[0].pose;
                    Instantiate(fieldObj, hitPose.position, hitPose.rotation);
                    weaponObj.SetActive(true);
                    currentARState = ARState.Ready;

                }
            }
        }
    }
    //private void TrackingPlane()
    //{
        //Touch touch = Input.GetTouch(0);
        //if(touch.phase != TouchPhase.Ended)
        //{
          //  return;
        //}
        //if (raycastManager.Raycast(touch.position, raycastHitList, TrackableType.PlaneWithinPolygon))
        //{
          //  Pose hitpose = raycastHitList[0].pose;
            //if (!fieldObj.activeSelf)
            //{
            //    uiManager.DisplayDebug("Raycast ê¨å˜");
              //  Instantiate(fieldObj, hitpose.position, Quaternion.identity);
                //fieldObj.SetActive(true);
                //weaponObj.SetActive(true);
                //currentARState = ARState.Ready;
            //}
            //else
            //{
                //uiManager.DisplayDebug("Raycast çœ");
                //fieldObj.transform.position = hitpose.position;
            //}
      //  }
        //else
        //{
        //    uiManager.DisplayDebug("RayCast é∏îs");
        //}
    //}

    private IEnumerator PreparateGameReady()
    {
        yield return new WaitForSeconds(2.0f);
        currentARState = ARState.Play;
    }
}
