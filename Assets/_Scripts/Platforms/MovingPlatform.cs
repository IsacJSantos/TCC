using DG.Tweening;
using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField]
    private Transform platform;
    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;

    private Transform currentPoint;

    [ContextMenu("Interact")]
    public override void Interact()
    {
        Move();
    }

    private void Move()
    {
        platform.DOKill();
        if (currentPoint == pointB)
        {
            currentPoint = pointA;
            platform.DOMove(pointA.position, 0.8f).SetEase(Ease.InQuad).Play();
        }
        else
        {
            currentPoint = pointB;
            platform.DOMove(pointB.position, 0.8f).SetEase(Ease.InQuad).Play();
        }
    }


}
