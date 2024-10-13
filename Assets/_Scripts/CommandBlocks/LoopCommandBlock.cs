using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopCommandBlock : BaseCommandBlock
{
    [SerializeField]
    private int maxIterations;
    [SerializeField]
    private List<BaseCommandBlock> commandBlocksList;
    private int currentBlockIndex;
    private int iterationCount;
    protected override void OnExecute()
    {
        ExecuteBlock(commandBlocksList[0]);
    }

    public override int CountCommands()
    {
        int count = base.CountCommands();
        for (int i = 0; i < commandBlocksList.Count; i++)
        {
            count += commandBlocksList[i].CountCommands();
        }
        return count;
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
        iterationCount++;
        if (iterationCount >= maxIterations)
            Finish();
        else 
        {
            currentBlockIndex = 0;
            ExecuteBlock(commandBlocksList[0]);
        }
    }

    public void AddCommand(BaseCommandBlock commandBlock)
    {
        commandBlocksList.Add(commandBlock);
    }

    public void RemoveCommand(BaseCommandBlock commandBlock)
    {
        if (commandBlocksList.Contains(commandBlock))
        {
            commandBlocksList.Remove(commandBlock);
            Destroy(commandBlock);
        }
    }
}
