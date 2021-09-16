using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class SpawnField : MonoBehaviour
{
    [SerializeField]
    private GameObject fieldObj;
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool isSpawnField;

    // Start is called before the first frame update
    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        isSpawnField = false;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnFieldObj();
    }

    void SpawnFieldObj()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon) && isSpawnField == false)
                {
                    Pose hitPose = hits[0].pose;
                    Instantiate(fieldObj, hitPose.position, hitPose.rotation);
                    isSpawnField = true;
                }
            }
        }
    }
}
