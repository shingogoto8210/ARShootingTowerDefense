using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOpeningLogo : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    private Image image;
    [SerializeField]
    private Sprite[] imgStage;

    public void ChangeLogo()
    {
        image = GetComponent<Image>();
        switch (gameManager.nextStageNo)
        {
            case 1:
                image.sprite = imgStage[0];
                    break;
            case 2:
                image.sprite = imgStage[1];
                break;

            case 3:
                image.sprite = imgStage[2];
                break;

            default:
                image.sprite = imgStage[0];
                break;

        }
    }
}
