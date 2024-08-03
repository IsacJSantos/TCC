using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommandBlock : BaseCommandBlock
{
    protected override void OnExecute()
    {
        MoveEntity();
    }

    private async void MoveEntity() 
    {
        currentEntity.Move(1);
        await System.Threading.Tasks.Task.Delay(1000);
        Finish();
    }
}
