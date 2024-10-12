using DG.Tweening;
using UnityEngine;

public interface IEntity
{
    public Transform getEntityTransform { get; }

    public void Move(int steps)
    {
        Vector3 newPos = getEntityTransform.position + (getEntityTransform.forward * steps);
        getEntityTransform.DOMove(newPos, 0.3f);
    }

    public void Turn(float degrees);

    public void Interact();

    public void OnFall();
}
