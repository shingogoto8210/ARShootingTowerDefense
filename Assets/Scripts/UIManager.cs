using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text txtScore;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private Text txtDebugMessage;

    public void UpdateDisplayScore()
    {
        txtScore.text = ScoreManager.instance.score.ToString();
    }

    public void DisplayDebug(string message)
    {
        txtDebugMessage.text = message;
    }


}
