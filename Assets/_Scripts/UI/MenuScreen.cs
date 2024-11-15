using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    public virtual void Show() 
    {
        canvas.enabled = true;
    }

    public virtual void Hide() 
    {
        canvas.enabled = false;
    }
}
