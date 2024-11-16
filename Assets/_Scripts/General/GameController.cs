using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField]
    private int currentSceneID;
    public int getCurrentSceneID { get => currentSceneID; }

    private void Awake()
    {
        Events.Victory += OnVictory;
    }
    private void OnDestroy()
    {
        Events.Victory -= OnVictory;
    }

    private void OnVictory()
    {
        UnlockLevel(currentSceneID + 1);
    }

    public void UnlockLevel(int levelID)
    {
        PlayerPrefs.SetInt("Level" + levelID, 1);
    }
}
