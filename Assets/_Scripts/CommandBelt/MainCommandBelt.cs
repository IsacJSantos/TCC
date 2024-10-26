using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCommandBelt : CommandBelt
{

    [SerializeField]
    private MethodBelt methodBelt;
    public MethodBelt getMethodBelt { get => methodBelt; }
}
