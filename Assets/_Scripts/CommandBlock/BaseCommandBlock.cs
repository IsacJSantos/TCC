using System;
using UnityEngine;

public abstract class BaseCommandBlock : MonoBehaviour
{
    protected IEntity currentEntity;

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
