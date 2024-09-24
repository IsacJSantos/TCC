using UnityEngine;

public class CommandBeltCanvas : MonoBehaviour
{
    [SerializeField]
    private CommandBelt commandBelt;
    [SerializeField]
    private Transform commandBeltContainer;

    public void RemoveCommandFromBelt(BaseCommandBlock baseCommandBlock) 
    {
        commandBelt.RemoveCommandFromBelt(baseCommandBlock);
    }

    public void OnClick_Execute() 
    {
        commandBelt.Init();
    }

    public void OnClick_AddCommand(CommandEntry commandEntryPrefab) 
    {
        if(commandEntryPrefab != null)
        {
            CommandEntry commandEntry = Instantiate(commandEntryPrefab, commandBeltContainer);
            commandEntry.Init(this);
            commandBelt.AddCommandToBelt(commandEntry.command);
        }
    }
}
