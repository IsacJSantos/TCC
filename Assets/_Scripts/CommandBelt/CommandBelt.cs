using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandBelt : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private List<BaseCommandBlock> commandBlocksList;

    private Action finishCallback;
    private int currentBlockIndex;

    public void Init(Action finishCallback = null)
    {
        currentBlockIndex = 0;
        this.finishCallback = finishCallback;
        ExecuteBlock(commandBlocksList[currentBlockIndex]);
    }

    public void AddCommandToBelt(BaseCommandBlock commandBlock)
    {
        commandBlocksList.Add(commandBlock);
    }

    public void RemoveCommandFromBelt(BaseCommandBlock commandBlock)
    {
        if (commandBlocksList.Contains(commandBlock))
        {
            commandBlocksList.Remove(commandBlock);
            Destroy(commandBlock);
        }
    }

    private void ExecuteBlock(BaseCommandBlock baseCommandBlock)
    {
        print(currentBlockIndex);
        baseCommandBlock.Execute(OnBlockFinished, playerController.GetComponent<IEntity>());
    }

    private void OnBlockFinished()
    {
        currentBlockIndex++;

        if (EntityIsGrounded(playerController.GetComponent<IEntity>()) == false)
        {
            playerController.GetComponent<IEntity>().OnFall();
            return;
        }

        if (currentBlockIndex < commandBlocksList.Count)
            ExecuteBlock(commandBlocksList[currentBlockIndex]);
        else 
        {
            finishCallback?.Invoke();
        }
    }

    public int CountTotalCommands()
    {
        int totalCommands = 0;
        for (int i = 0; i < commandBlocksList.Count; i++)
        {
            totalCommands += commandBlocksList[i].CountCommands();
        }
        return totalCommands;
    }
    private bool EntityIsGrounded(IEntity entity)
    {
        return Physics.Raycast(entity.getEntityTransform.position, Vector3.down, 20, LayerMask.GetMask("Ground"));
    }
}
