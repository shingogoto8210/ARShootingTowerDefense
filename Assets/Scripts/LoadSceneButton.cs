using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField]
    private int stageNo;
    public void OnClickLoadToMain()
    {
        SceneStateManager.instance.PreparateLoadSceneState(SceneState.Main,0.1f);
        GameData.instance.stageNo = stageNo;
    }
    
    public void OnClickLoadToStageSelect()
    {
        SceneStateManager.instance.PreparateLoadSceneState(SceneState.StageSelect, 0.1f);

    }
}
