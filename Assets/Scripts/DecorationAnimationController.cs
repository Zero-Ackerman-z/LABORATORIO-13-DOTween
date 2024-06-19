using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DecorationAnimationController : MonoBehaviour
{
    public Transform rockTransform;
    public Transform statueTransform;
    public Transform plantTransform;

    void Start()
    {
        MoveRock();

        RotateStatue();

        ScalePlant();
    }

    void MoveRock()
    {
        // Movimiento de  forma suave y repetitiva.
        rockTransform.DOMove(new Vector3(5, 0, 0), 3f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    void RotateStatue()
    {
        // Rota  continua.
        statueTransform.DORotate(new Vector3(0, 360, 0), 10f, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }

    void ScalePlant()
    {
        //  pulse suavemente.
        plantTransform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutElastic);
    }
}