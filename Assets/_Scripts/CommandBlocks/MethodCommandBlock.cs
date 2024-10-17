using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodCommandBlock : BaseCommandBlock
{
    [SerializeField]
    private MethodBelt methodBelt;


    public override int CountCommands()
    {
        int count = base.CountCommands();
        count += methodBelt.CountCommands();
        return count;   
    }
    protected override void OnExecute()
    {
        methodBelt = MainCommandBelt.Instance.getMethodBeltA;
        methodBelt.InitMethod(currentEntity, OnMethodFinished);
    }

    private void OnMethodFinished()
    {
        Finish();
    }
}
