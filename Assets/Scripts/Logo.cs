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
    private Image imgStart;
    [SerializeField]
    private Image imgClear;

    public IEnumerator PlayOpening()
    {
        canvasGroup.alpha = 0.0f;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(imgClear.DOFade(0.0f, 0.1f));
        sequence.Append(canvasGroup. DOFade(1.0f, 0.5f));
        sequence.Append(imgStart.DOFade(1.0f, 0.5f));
        sequence.AppendInterval(3.0f);
        sequence.Append(canvasGroup.DOFade(0.0f, 0.5f));
        yield return new WaitForSeconds(5.0f);
    }

    public IEnumerator PlayClear()
    {
        canvasGroup.alpha = 0.0f;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(imgStart.DOFade(0.0f, 0.1f));
        sequence.Append(canvasGroup.DOFade(1.0f, 0.5f));
        sequence.Append(imgClear.DOFade(1.0f, 0.5f));
        sequence.AppendInterval(2.0f);
        sequence.Append(imgClear.DOFade(0.0f, 0.5f));
        sequence.Append(imgStart.DOFade(1.0f, 0.5f));
        sequence.AppendInterval(2.0f);
        sequence.Append(canvasGroup.DOFade(0.0f, 0.5f));
        yield return new WaitForSeconds(8.0f);
    }


}
