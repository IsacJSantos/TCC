using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCommandBlock : BaseCommandBlock
{
    protected override void OnExecute()
    {
        currentEntity.Interact();
        Finish();
    }

   
}
