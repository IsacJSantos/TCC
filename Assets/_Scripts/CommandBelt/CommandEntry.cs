using TMPro;
using UnityEngine;

public class CommandEntry : MonoBehaviour
{
    public BaseCommandBlock command;

    CommandBelt commandBelt;
    public void Init(CommandBelt commandBelt)
    {
        this.commandBelt = commandBelt;
        command.Init(commandBelt, this);
    }

    public void OnClick_RemoveCommand()
    {
        commandBelt.RemoveCommandFromBelt(command);
        Destroy(gameObject);
    }
}
