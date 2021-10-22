using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour
{
    public static SceneStateManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// シーン遷移の準備
    /// </summary>
    /// <param name="sceneState"></param>
    /// <param name="seconds"></param>
    public void PreparateLoadSceneState(SceneState sceneState,float seconds)
    {
        StartCoroutine(LoadSceneState(sceneState,seconds));
    }

    /// <summary>
    /// 引数でもらったシーンに遷移する
    /// </summary>
    /// <param name="sceneState"></param>
    /// <param name="seconds"></param>
    /// <returns></returns>
    public IEnumerator LoadSceneState(SceneState sceneState,float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneState.ToString());
    }
}
