using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommandBelt : MonoBehaviour
{
    [SerializeField]
    protected IEntity currentEntity;
    public IEntity getCurrentEntity { get => currentEntity; }

    [SerializeField]
    private List<BaseCommandBlock> commandBlocksList;
    public List<BaseCommandBlock> getCommandBlocks { get => commandBlocksList; }
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
    public void Init(IEntity entity, Action finishCallback = null)
    {
        currentBlockIndex = 0;
        currentEntity = entity;
        this.finishCallback = finishCallback;
        ExecuteBlock(commandBlocksList[currentBlockIndex]);
    }

    public virtual void AddCommandToBelt(BaseCommandBlock commandBlock)
    {
        if (commandBlocksList.Count < maxBlocksAmount)
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

    public virtual void RemoveCommandFromBelt(BaseCommandBlock commandBlock)
    {
        if (commandBlocksList.Contains(commandBlock))
        {
            commandBlocksList.Remove(commandBlock);
            Destroy(commandBlock);
            blocksAmout++;
            UpdateBlocksAmountText();
        }
    }

    public virtual void RemoveAllFromBeltCommands()
    {
        for (int i = 0; i < commandBlocksList.Count; i++)
        {
            Destroy(commandBlocksList[i].gameObject);
        }
        commandBlocksList.Clear();
    }

    private void UpdateBlocksAmountText()
    {
        if (blocksAmountText == null) return;

        blocksAmountText.text = blocksAmout.ToString();
    }

    private void ExecuteBlock(BaseCommandBlock baseCommandBlock)
    {
        print(currentBlockIndex);
        baseCommandBlock.Execute(OnBlockFinished, currentEntity);
    }

    private void OnBlockFinished()
    {
        currentBlockIndex++;

        if (EntityIsGrounded(currentEntity) == false)
        {
            currentEntity.OnFall();
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
