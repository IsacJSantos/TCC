using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerAnimEvents : MonoBehaviour
{
    public UnityEvent OnInteract;

    public void Interact() 
    {
        OnInteract?.Invoke();
    }
}
