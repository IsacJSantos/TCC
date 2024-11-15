using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCommandBelt : CommandBelt
{
    [SerializeField]
    private MethodBelt methodBelt;
    public MethodBelt getMethodBelt { get => methodBelt; }

    protected override void OnAllBlocksFinished()
    {
        base.OnAllBlocksFinished();
        if (IsOnFinalBlock()) 
            Events.Victory?.Invoke();
        else
            Events.Defeat?.Invoke();       
    }

    private bool IsOnFinalBlock()
    {
        return Physics.Raycast(playerController.getEntityTransform.position, Vector3.down, 20, LayerMask.GetMask("VictoryGround"));
    }
}
