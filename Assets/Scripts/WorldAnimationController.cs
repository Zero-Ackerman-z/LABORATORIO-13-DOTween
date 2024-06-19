using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WorldAnimationController : MonoBehaviour
{
    public Renderer objectRenderer;
    public Light gameLight;
    public Transform worldObject;

    void Start()
    {
        ChangeObjectColor();
        ChangeMaterialProperties();
        ChangeLightIntensity();
        ChangeLightColor();
        AppearObject();
        CombinedWorldAnimation();
    }

    void ChangeObjectColor()
    {
        Material objectMaterial = objectRenderer.material;
        objectMaterial.DOColor(Color.red, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    void ChangeMaterialProperties()
    {
        //  intensidad del brillo  material.
        objectRenderer.material.DOFloat(2.0f, "_Glossiness", 1.5f).SetEase(Ease.InOutQuad);
    }

    void ChangeLightIntensity()
    {
        //  intensidad luz.
        gameLight.DOIntensity(5f, 2f).SetEase(Ease.InOutCubic);
    }

    void ChangeLightColor()
    {
        // luz 
        gameLight.DOColor(Color.blue, 3f).SetEase(Ease.InOutQuad);
    }

    void AppearObject()
    {
        // Desvanece  objeto 
        objectRenderer.material.DOFade(1f, 2f).From(0f).SetEase(Ease.InOutQuad);
    }

    void CombinedWorldAnimation()
    {
        // Animación  de escalamiento y rotación
        Sequence sequence = DOTween.Sequence();
        sequence.Append(worldObject.DOScale(new Vector3(2f, 2f, 2f), 1f))
                .Join(worldObject.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.LocalAxisAdd))
                .SetLoops(-1, LoopType.Yoyo);
    }
}
