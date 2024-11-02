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
        if (commandBelt is MainCommandBelt)
        {
            MainCommandBelt mainCommandBelt = (MainCommandBelt)commandBelt;
            methodBelt = mainCommandBelt.getMethodBelt;
        }
        else
        {
            Debug.Log("Trying to add method call into a metho belt");
            commandEntry.OnClick_RemoveCommand();
        }

    }

    public override int CountCommands()
    {
        int count = base.CountCommands();
        count += methodBelt.CountTotalCommands();
        return count;
    }

    protected override void OnExecute()
    {
        methodBelt.Init(OnMethodFinished);
    }

    private void OnMethodFinished()
    {
        Finish();
    }
}