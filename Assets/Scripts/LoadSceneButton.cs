using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField]
    private int stageNo;
    [SerializeField]
    private Image imgShot;
    [SerializeField]
    private Transform canvasTran;
    [SerializeField]
    private CanvasGroup canvasGroup;

    /// <summary>
    /// メインシーンに遷移
    /// </summary>
    public void OnClickLoadToMain()
    {
        SceneStateManager.instance.PreparateLoadSceneState(SceneState.Main,0.1f);
        GameData.instance.stageNo = stageNo;
    }
    
    /// <summary>
    /// TitleシーンからStageSelectシーンに遷移
    /// </summary>
    public void OnClickLoadToStageSelectFromTitle()
    {
        if(imgShot != null)
        {
            Instantiate(imgShot,canvasTran,false);
            GetComponent<AudioSource>().Play();

        }
        SceneStateManager.instance.PreparateLoadSceneState(SceneState.StageSelect, 1.5f);
        canvasGroup.DOFade(0.0f, 1.5f);
    }

    /// <summary>
    /// リザルトシーンからStageSelectシーンに遷移
    /// </summary>
    public void OnClickLoadToStageSelectFromResult()
    {
        SceneStateManager.instance.PreparateLoadSceneState(SceneState.StageSelect, 1.5f);
        canvasGroup.DOFade(0.0f, 1.5f);
    }
}
