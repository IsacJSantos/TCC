using UnityEngine;

public class PlayerController : MonoBehaviour, IEntity
{
    public Transform getEntityTransform => throw new System.NotImplementedException();

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public void Move(int steps)
    {
        throw new System.NotImplementedException();
    }

    public void Turn(float degrees)
    {
        throw new System.NotImplementedException();
    }
}
