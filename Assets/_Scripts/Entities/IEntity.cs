using UnityEngine;

public interface IEntity
{
    public Transform getEntityTransform { get; }
    public void Move(int steps);

    public void Turn(float degrees);

    public void Interact();
}
