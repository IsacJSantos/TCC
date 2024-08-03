using UnityEngine;

public class CubeEntity : MonoBehaviour, IEntity
{
    public Transform getEntityTransform => this.transform;

    public void Move(int steps)
    {
        transform.Translate(Vector3.forward * steps, Space.Self);
    }

    public void Turn(float degrees)
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + degrees, transform.localEulerAngles.z);
    }
}
