using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LoopSetupCommandBelt : CommandBelt
{
    [SerializeField]
    private LoopSetupWindow loopSetupWindow;

    public override void AddCommandToBelt(BaseCommandBlock commandBlock)
    {
        base.AddCommandToBelt(commandBlock);
    }

    public override void RemoveCommandFromBelt(BaseCommandBlock commandBlock)
    {
        base.RemoveCommandFromBelt(commandBlock);
    }

}
