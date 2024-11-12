using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCommandBlock : BaseCommandBlock
{
    protected override void OnExecute()
    {
        Interact();
    }

    private async void Interact()
    {
        currentEntity.Interact();
        await System.Threading.Tasks.Task.Delay(1000);
        Finish();
    }
}
