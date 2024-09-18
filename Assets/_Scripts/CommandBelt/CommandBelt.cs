using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBelt : MonoBehaviour
{
    [SerializeField]
    private CubeEntity cubeEntity;

    [SerializeField]
    private List<BaseCommandBlock> baseCommandBlocks;
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
        ExecuteBlock(baseCommandBlocks[currentBlockIndex]);
    }

    public void AddCommandToBelt(BaseCommandBlock commandBlock) 
    {
        baseCommandBlocks.Add(commandBlock);
    }

    public void RemoveCommandFromBelt(BaseCommandBlock commandBlock) 
    {
        if (baseCommandBlocks.Contains(commandBlock))
            baseCommandBlocks.Remove(commandBlock);
    }

    private void ExecuteBlock(BaseCommandBlock baseCommandBlock)
    {
        print(currentBlockIndex);
        baseCommandBlock.Execute(OnFinish, cubeEntity.GetComponent<IEntity>());
    }

    private void OnFinish()
    {
        currentBlockIndex++;
        if (currentBlockIndex < baseCommandBlocks.Count)
            ExecuteBlock(baseCommandBlocks[currentBlockIndex]);
    }
}
