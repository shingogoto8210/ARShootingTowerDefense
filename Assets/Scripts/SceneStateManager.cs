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

    public void PreparateLoadSceneState(SceneState sceneState,float seconds)
    {
        StartCoroutine(LoadSceneState(sceneState,seconds));
    }

    public IEnumerator LoadSceneState(SceneState sceneState,float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneState.ToString());
    }
}
