using UnityEngine;

public class CommandBeltCanvas : MonoBehaviour
{
    [SerializeField]
    private CommandBelt commandBelt;
    [SerializeField]
    private Transform commandBeltContainer;

    [SerializeField]
    private CommandEntry moveCommandEntryPrefab;
    [SerializeField]
    private CommandEntry turnLeftCommandEntryPrefab;
    [SerializeField]
    private CommandEntry turnRightCommandEntryPrefab;

    public void RemoveCommandFromBelt(BaseCommandBlock baseCommandBlock) 
    {
        commandBelt.RemoveCommandFromBelt(baseCommandBlock);
    }

    public void OnClick_Execute() 
    {
        commandBelt.Init();
    }

    public void OnClick_AddMoveCommand()
    {
        CommandEntry commandEntry = Instantiate(moveCommandEntryPrefab, commandBeltContainer);
        commandEntry.Init(this);
        commandBelt.AddCommandToBelt(commandEntry.command);
    }

    public void OnClick_AddTurnRightCommand()
    {
        CommandEntry commandEntry = Instantiate(turnRightCommandEntryPrefab, commandBeltContainer);
        commandEntry.Init(this);
        commandBelt.AddCommandToBelt(commandEntry.command);
    }

    public void OnClick_AddTurnLeftCommand()
    {
        CommandEntry commandEntry = Instantiate(turnLeftCommandEntryPrefab, commandBeltContainer);
        commandEntry.Init(this);
        commandBelt.AddCommandToBelt(commandEntry.command);
    }
}
