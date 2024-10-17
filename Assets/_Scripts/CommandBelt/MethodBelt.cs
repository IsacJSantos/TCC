using System;
using System.Collections.Generic;
using UnityEngine;

public class MethodBelt : MonoBehaviour
{
    [SerializeField]
    private List<BaseCommandBlock> commandBlocksList;

    private int currentBlockIndex;
    private IEntity currentEntity;
    private Action finishCallback;

    public void InitMethod(IEntity entity, Action finishCallback) 
    {
        currentEntity = entity;
        this.finishCallback = finishCallback;
        ExecuteBlock(commandBlocksList[0]);
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

    public int CountCommands()
    {
        int count = 0;
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
        Finish();
    }

    private void Finish()
    {
        currentBlockIndex = 0;
        finishCallback?.Invoke();
    }

   
}
