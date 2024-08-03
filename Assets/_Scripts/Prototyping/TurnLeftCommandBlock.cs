using UnityEngine;

public class TurnLeftCommandBlock : BaseCommandBlock
{
    protected override void OnExecute()
    {
        TurnEntity();
    }

    private async void TurnEntity()
    {
        currentEntity.Turn(-90);
        await System.Threading.Tasks.Task.Delay(1000);
        Finish();
    }
}
