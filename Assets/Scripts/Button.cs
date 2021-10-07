using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void OnClick()
    {
        SceneStateManager.instance.PreparateLoadSceneState(SceneState.Main,0.1f);
    }
}
