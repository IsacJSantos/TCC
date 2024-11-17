using TMPro;
using UnityEngine;

public class LoopCommandBlock : BaseCommandBlock
{
    public int maxIteractions;
    public int iteractions;
    [SerializeField]
    private TextMeshProUGUI iterationsText;
    [SerializeField]
    private CommandBelt loopCommandBelt;
    private int iterationCount;

    public override void Init(CommandBelt commandBelt, CommandEntry commandEntry)
    {
        base.Init(commandBelt, commandEntry);
        iterationsText.text = iteractions.ToString();
    }
    protected override void OnExecute()
    {
        iterationCount = 0;
        loopCommandBelt.Init(commandBelt.getCurrentEntity, OnAllBlocksFinished);
    }

    public override int CountCommands()
    {
        int count = base.CountCommands();
        count += loopCommandBelt.CountTotalCommands();
        return count;
    }

    private void OnAllBlocksFinished()
    {
        iterationCount++;
        if (iterationCount >= iteractions)
            Finish();
        else
        {
            loopCommandBelt.Init(commandBelt.getCurrentEntity, OnAllBlocksFinished);
        }
    }

    public void OnClick_IncreaseIterations()
    {
        iteractions = Mathf.Clamp(iteractions + 1, 0, maxIteractions);
        iterationsText.text = iteractions.ToString();
    }

    public void OnClick_DecreaseIterations()
    {
        iteractions = Mathf.Clamp(iteractions - 1, 0, maxIteractions);
        iterationsText.text = iteractions.ToString();
    }

    public void OnClick_RemoveBlock()
    {
        loopCommandBelt.RemoveAllFromBeltCommands();
    }
}
