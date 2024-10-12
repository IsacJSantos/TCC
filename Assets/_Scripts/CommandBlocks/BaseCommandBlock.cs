using System;
using UnityEngine;

public abstract class BaseCommandBlock : MonoBehaviour
{
    protected IEntity currentEntity;
    [SerializeField]
    protected CommandBlockType blockType;
    public CommandBlockType getBlockType { get => blockType; }

    private Action finishCallback;

    private bool counted;
    public bool getCounted { get => counted; }

    public void Execute(Action finishCallback, IEntity entity)
    {
        currentEntity = entity;
        this.finishCallback = finishCallback;
        OnExecute();
    }

    public virtual int CountCommands() 
    {
        if(counted == false) 
        {
            counted = true;
            return 1;
        }

        return 0;
    }

    protected void Finish()
    {
        finishCallback?.Invoke();
        print("Finish");
    }

    protected abstract void OnExecute();

}
