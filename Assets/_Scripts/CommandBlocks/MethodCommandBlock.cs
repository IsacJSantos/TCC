using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodCommandBlock : BaseCommandBlock
{
    [SerializeField]
    private MethodBelt methodBelt;

    public override void Init(CommandBelt commandBelt, CommandEntry commandEntry)
    {
        base.Init(commandBelt, commandEntry);
        methodBelt = CommandBeltController.Instance.getMethodCommandBelt;
    }

    public override int CountCommands()
    {
        int count = base.CountCommands();
        count += methodBelt.CountTotalCommands();
        return count;
    }

    protected override void OnExecute()
    {
        methodBelt.Init(commandBelt.getCurrentEntity, OnMethodFinished);
    }

    private void OnMethodFinished()
    {
        Finish();
    }
}
