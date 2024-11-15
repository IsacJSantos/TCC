using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField]
    private int currentSceneID;
    public int getCurrentSceneID { get => currentSceneID; }
}
