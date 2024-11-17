using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBeltContainer : MonoBehaviour, IBeltContainer
{
    [SerializeField]
    private CommandBelt commandBelt;

    public void OnDropCommand(CommandSelector commandSelector)
    {
        CommandEntry commandEntry = Instantiate(commandSelector.commandEntryPrefab, transform);
        commandEntry.Init(commandBelt);
        commandBelt.AddCommandToBelt(commandEntry.command);
    }
}
