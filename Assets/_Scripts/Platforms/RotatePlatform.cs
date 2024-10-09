using DG.Tweening;
using UnityEngine;

public class RotatePlatform : Platform
{
    [ContextMenu("Interact")]
    public override void Interact()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.DOKill(true);
        Vector3 newRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 90f, transform.eulerAngles.z);
        transform.DORotate(newRotation, 0.8f).SetEase(Ease.InQuad).Play();
    }
}
