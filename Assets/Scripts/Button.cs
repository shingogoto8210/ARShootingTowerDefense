using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    public void ToMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
