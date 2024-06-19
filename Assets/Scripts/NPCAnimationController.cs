using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NPCAnimationController : MonoBehaviour
{
    public Transform npcTransform;
    public Transform enemyTransform;

    public Vector3[] npcPathPoints;
    public Vector3[] enemyPathPoints;

    void Start()
    {
        MoveNPCAlongPath();

        MoveAndRotateEnemyAlongPath();
    }

    void MoveNPCAlongPath()
    {
        Sequence npcSequence = DOTween.Sequence();

        for (int i = 0; i < npcPathPoints.Length; i++)
        {
            npcSequence.Append(npcTransform.DOMove(npcPathPoints[i], 2f).SetEase(Ease.Linear));
        }

        npcSequence.SetLoops(-1, LoopType.Yoyo);
    }

    void MoveAndRotateEnemyAlongPath()
    {
        Sequence enemySequence = DOTween.Sequence();

        for (int i = 0; i < enemyPathPoints.Length; i++)
        {
            enemySequence.Append(enemyTransform.DOMove(enemyPathPoints[i], 2f).SetEase(Ease.Linear));
            enemySequence.Join(enemyTransform.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutSine));
        }

        enemySequence.SetLoops(-1, LoopType.Yoyo);
    }
}



