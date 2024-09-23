using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfStatementBlock : BaseCommandBlock
{
    [SerializeField]
    private List<BaseCommandBlock> commandBlocksList;
    [SerializeField]
    private bool condition;
    private int currentBlockIndex;
    protected override void OnExecute()
    {
        if (ConditionPassed())
            ExecuteBlock(commandBlocksList[0]);
        else
            Finish();
    }

    private bool ConditionPassed()
    {
        return condition;
    }

    private void ExecuteBlock(BaseCommandBlock commandBlock)
    {
        commandBlock.Execute(OnBlockFinished, currentEntity);
    }

    private void OnBlockFinished()
    {
        currentBlockIndex++;
        if (currentBlockIndex < commandBlocksList.Count)
            ExecuteBlock(commandBlocksList[currentBlockIndex]);
        else
            OnAllBlocksFinished();
    }

    private void OnAllBlocksFinished()
    {
        Finish();
    }
}
