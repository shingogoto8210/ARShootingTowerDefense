using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// StageSelectâÊñ ÇÃä«óù
/// </summary>
public class StageSelectManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private CanvasGroup canvasGroup;


    void Start()
    {
        canvasGroup.alpha = 0.0f;
        uiManager.UpdateDisplayTotalClearPoint();
        canvasGroup.DOFade(1.0f, 1.5f);
    }

}
