using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour, IEntity
{
    public Transform getEntityTransform => throw new System.NotImplementedException();

    public void Interact()
    {

    }

    public void Move(int steps)
    {
        Vector3 newPos = transform.position + (transform.forward * steps);       
        transform.DOMove(newPos, 0.3f);
    }

    public void Turn(float degrees)
    {
        Vector3 newRotation = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + degrees, transform.localEulerAngles.z);
        transform.DORotate(newRotation, 0.3f);
    }
}
