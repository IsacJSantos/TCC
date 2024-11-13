using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlatform : Platform
{
    [SerializeField]
    private Platform platformToInteract;
    [SerializeField]
    private Animation m_animation;
    public override void Interact()
    {
        platformToInteract.Interact();
        m_animation.Play();
    }

   
}
