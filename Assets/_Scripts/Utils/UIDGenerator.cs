using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIDGenerator
{
    public static int GetUniqueID()
    {
        return Random.Range(1000, 10000);
    }
}
