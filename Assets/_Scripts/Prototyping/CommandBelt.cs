using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBelt : MonoBehaviour
{
    [SerializeField]
    private CubeEntity cubeEntity;

    [SerializeField]
    private BaseCommandBlock[] baseCommandBlocks;
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

    private void ExecuteBlock(BaseCommandBlock baseCommandBlock)
    {
        print(currentBlockIndex);
        baseCommandBlock.Execute(OnFinish, cubeEntity.GetComponent<IEntity>());
    }

    private void OnFinish()
    {
        currentBlockIndex++;
        if (currentBlockIndex < baseCommandBlocks.Length)
            ExecuteBlock(baseCommandBlocks[currentBlockIndex]);
    }
}
