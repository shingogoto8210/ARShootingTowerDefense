using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    private void Start()
    {
        uiManager.UpdateDisplayResult();
    }
}
