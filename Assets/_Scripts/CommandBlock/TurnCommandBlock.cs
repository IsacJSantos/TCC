using UnityEngine;

public class TurnCommandBlock : BaseCommandBlock
{
    [SerializeField]
    private float turnDegrees;
    protected override void OnExecute()
    {
        TurnEntity();
    }

    private async void TurnEntity()
    {
        currentEntity.Turn(turnDegrees);
        await System.Threading.Tasks.Task.Delay(1000);
        Finish();
    }
}
