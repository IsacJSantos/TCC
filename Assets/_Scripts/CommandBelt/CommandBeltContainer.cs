using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBeltContainer : MonoBehaviour, IBeltContainer
{
    [SerializeField]
    private CommandBelt commandBelt;
    [SerializeField]
    private CommandBlockType[] ignoredBlockTypes;
    public void OnDropCommand(CommandSelector commandSelector)
    {
        if (isIgnoredBlock(commandSelector.commandEntryPrefab.command.getBlockType)) return;

        CommandEntry commandEntry = Instantiate(commandSelector.commandEntryPrefab, transform);
        commandEntry.Init(commandBelt);
        commandBelt.AddCommandToBelt(commandEntry.command);
    }

    private bool isIgnoredBlock(CommandBlockType blockType)
    {
        for (int i = 0; i < ignoredBlockTypes.Length; i++)
        {
            if (blockType == ignoredBlockTypes[i])
            {
                return true;
            }
        }
        return false;
    }
}
