using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAnimationController : MonoBehaviour
{
    public RectTransform buttonRectTransform;
    public RectTransform iconRectTransform;
    public RectTransform textRectTransform;
    public CanvasGroup canvasGroup;
    void Start()
    {
        CombinedUIAnimation();
    }

    void CombinedUIAnimation()
    {
        Sequence sequence = DOTween.Sequence();

        // Animación de escala 
        sequence.Append(buttonRectTransform.DOScale(new Vector3(1.2f, 1.2f, 1f), 0.5f));

        // Animación de opacidad 
        sequence.Join(canvasGroup.DOFade(0.8f, 0.5f));

        // Animación de rotación 
        sequence.Append(buttonRectTransform.DORotate(new Vector3(0, 0, 360), 1f, RotateMode.LocalAxisAdd))
                .SetLoops(2, LoopType.Yoyo);

        sequence.OnComplete(() => DeactivateCanvasGroup());
    }

    void DeactivateCanvasGroup()
    {
        canvasGroup.gameObject.SetActive(false);
    }
}