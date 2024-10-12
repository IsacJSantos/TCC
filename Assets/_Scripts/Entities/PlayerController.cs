using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour, IEntity
{
    public Transform getEntityTransform => transform;

    public void Interact()
    {

    }

    public void Turn(float degrees)
    {
        Vector3 newRotation = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + degrees, transform.localEulerAngles.z);
        transform.DORotate(newRotation, 0.3f);
    }
    public void OnFall()
    {
        Debug.Log("FALL!");   
    }
}
