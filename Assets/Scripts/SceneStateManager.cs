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
    /// �V�[���J�ڂ̏���
    /// </summary>
    /// <param name="sceneState"></param>
    /// <param name="seconds"></param>
    public void PreparateLoadSceneState(SceneState sceneState,float seconds)
    {
        StartCoroutine(LoadSceneState(sceneState,seconds));
    }

    /// <summary>
    /// �����ł�������V�[���ɑJ�ڂ���
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
