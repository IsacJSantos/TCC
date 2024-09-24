using System;
using UnityEngine;

public abstract class BaseCommandBlock : MonoBehaviour
{
    protected IEntity currentEntity;
    [SerializeField]
    protected CommandBlockType blockType;
    public CommandBlockType getBlockType { get => blockType; }

    private Action finishCallback;
    public void Execute(Action finishCallback, IEntity entity)
    {
        currentEntity = entity;
        this.finishCallback = finishCallback;
        OnExecute();
    }

    protected void Finish()
    {
        finishCallback?.Invoke();
        print("Finish");
    }

    protected abstract void OnExecute();
}
