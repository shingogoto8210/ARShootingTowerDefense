using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Logo : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Image img;

    public IEnumerator LogoEffect()
    {
        canvasGroup.alpha = 0.0f;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(canvasGroup. DOFade(1.0f, 0.5f));
        sequence.Append(img.DOFade(1.0f, 0.5f));
        sequence.AppendInterval(3.0f);
        sequence.Append(canvasGroup.DOFade(0.0f, 0.5f));
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
