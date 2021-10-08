using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    void Start()
    {
        uiManager.UpdateDisplayTotalClearPoint();
    }

}
