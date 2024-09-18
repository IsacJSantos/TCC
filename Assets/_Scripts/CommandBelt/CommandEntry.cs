using TMPro;
using UnityEngine;

public class CommandEntry : MonoBehaviour
{
    public BaseCommandBlock command;

    CommandBeltCanvas commandBeltCanvas;
    public void Init(CommandBeltCanvas commandBeltCanvas)
    {
        this.commandBeltCanvas = commandBeltCanvas;
    }

    public void OnClick_RemoveCommand()
    {
        commandBeltCanvas.RemoveCommandFromBelt(command);
        Destroy(gameObject);
    }
}
