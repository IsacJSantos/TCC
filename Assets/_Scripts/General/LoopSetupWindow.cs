using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoopSetupWindow : MonoBehaviour
{
    [SerializeField]
    private int maxRepetitions = 10;
    [SerializeField]
    private TextMeshProUGUI repetitionsText;
    [SerializeField]
    private LoopSetupCommandBelt loopSetupCommandBelt;

    private LoopCommandBlock currentLoopCommandBlock;
    private int currentRepetitions;
    public void Show(LoopCommandBlock loopCommandBlock)
    {
        currentLoopCommandBlock = loopCommandBlock;
        SetView();
    }

    private void SetView()
    {
        List<BaseCommandBlock> loopCommands = currentLoopCommandBlock.getCommandBlockList;
        for (int i = 0; i < loopCommands.Count; i++)
        {
            loopSetupCommandBelt.AddCommandToBelt(loopCommands[i]);
            loopCommands[i].gameObject.SetActive(true);
        }
    }

    public void AddCommandBlock()
    {

    }

    public void RemoveCommandBlock()
    {

    }

    public void OnClick_AddRepetitions()
    {
        currentRepetitions = Mathf.Clamp(currentRepetitions + 1, 0, maxRepetitions);
        repetitionsText.text = currentRepetitions.ToString();
    }

    public void OnClick_RemoveRepetitions()
    {
        currentRepetitions = Mathf.Clamp(currentRepetitions - 1, 0, maxRepetitions);
        repetitionsText.text = currentRepetitions.ToString();
    }
}
