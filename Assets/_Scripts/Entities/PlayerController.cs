using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour, IEntity
{
    [SerializeField]
    private Animator animator;
    public Transform getEntityTransform => transform;

    public void Interact()
    {
        animator.SetTrigger("Interact");
    }

    public void Turn(float degrees)
    {
        Vector3 newRotation = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + degrees, transform.localEulerAngles.z);
        transform.DORotate(newRotation, 0.3f);
    }

    void IEntity.OnMove()
    {
        animator.SetTrigger("Walk");
    }

    public async void OnFall()
    {
        animator.SetTrigger("Fall");
        await System.Threading.Tasks.Task.Delay(1000);
        Events.Defeat?.Invoke();
    }

    public void TriggerInteractionPlatform()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 3, 1 << 6))
        {
            hit.collider.GetComponent<InteractionPlatform>().Interact();
        }
    }
}
