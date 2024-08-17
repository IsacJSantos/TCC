using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryAndDefeatCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject victoryPanel;
    [SerializeField]
    private GameObject defeatPanel;

    public static Action defeatAction;
    public static Action victoryAction;

    private void Awake()
    {
        defeatAction += ShowDefeatPanel;
        victoryAction += ShowVictoryPanel;
    }

    private void OnDestroy()
    {
        defeatAction -= ShowDefeatPanel;
        victoryAction -= ShowVictoryPanel;
    }

    private void ShowVictoryPanel() 
    {
        victoryPanel.SetActive(true);
    }

    private void ShowDefeatPanel() 
    {
        defeatPanel.SetActive(true);
    }
}
