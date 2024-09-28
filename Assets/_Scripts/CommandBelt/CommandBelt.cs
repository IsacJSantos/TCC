using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBelt : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private List<BaseCommandBlock> commandBlocksList;
    private int currentBlockIndex;

    public bool executeBlocks;

    private void OnValidate()
    {
        if (executeBlocks) 
        {
            executeBlocks = false;
            Init();
        }
    }

    public void Init()
    {
        currentBlockIndex = 0;
        ExecuteBlock(commandBlocksList[currentBlockIndex]);
    }

    public void AddCommandToBelt(BaseCommandBlock commandBlock) 
    {
        commandBlocksList.Add(commandBlock);
    }

    public void RemoveCommandFromBelt(BaseCommandBlock commandBlock) 
    {
        if (commandBlocksList.Contains(commandBlock))
            commandBlocksList.Remove(commandBlock);
    }

    private void ExecuteBlock(BaseCommandBlock baseCommandBlock)
    {
        print(currentBlockIndex);
        baseCommandBlock.Execute(OnBlockFinished, playerController.GetComponent<IEntity>());
    }

    private void OnBlockFinished()
    {
        currentBlockIndex++;
        if (currentBlockIndex < commandBlocksList.Count)
            ExecuteBlock(commandBlocksList[currentBlockIndex]);
    }
}
