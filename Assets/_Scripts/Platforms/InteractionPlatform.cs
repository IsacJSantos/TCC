using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlatform : Platform
{
    [SerializeField]
    private Platform platformToInteract;
    public override void Interact()
    {
        platformToInteract.Interact();
    }

   
}
