using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommandBelt : MonoBehaviour
{
    [SerializeField]
    protected PlayerController playerController;

    [SerializeField]
    private List<BaseCommandBlock> commandBlocksList;
    [SerializeField]
    private TextMeshProUGUI blocksAmountText;
    [SerializeField]
    protected int maxBlocksAmount;
    [SerializeField]
    protected int blocksAmout;

    [SerializeField]
    private LayerMask groundLayerMask;

    private Action finishCallback;
    private int currentBlockIndex;

    private void Start()
    {
        blocksAmout = maxBlocksAmount;
        UpdateBlocksAmountText();
    }
    public void Init(Action finishCallback = null)
    {
        currentBlockIndex = 0;
        this.finishCallback = finishCallback;
        ExecuteBlock(commandBlocksList[currentBlockIndex]);
    }

    public void AddCommandToBelt(BaseCommandBlock commandBlock)
    {
        if(commandBlocksList.Count < maxBlocksAmount) 
        {
            commandBlocksList.Add(commandBlock);
            blocksAmout--;
            UpdateBlocksAmountText();
        }
        else 
        {
            Destroy(commandBlock.gameObject);
        }
    }

    public void RemoveCommandFromBelt(BaseCommandBlock commandBlock)
    {
        if (commandBlocksList.Contains(commandBlock))
        {
            commandBlocksList.Remove(commandBlock);
            Destroy(commandBlock);
            blocksAmout++;
            UpdateBlocksAmountText();
        }
    }

    private void UpdateBlocksAmountText() 
    {
        blocksAmountText.text = blocksAmout.ToString();
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
            OnAllBlocksFinished();
        }
    }

    protected virtual void OnAllBlocksFinished() 
    {
        finishCallback?.Invoke();
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
        return Physics.Raycast(entity.getEntityTransform.position, Vector3.down, 20, groundLayerMask);
    }
}
