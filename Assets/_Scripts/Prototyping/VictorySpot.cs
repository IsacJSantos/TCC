using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySpot : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        VictoryAndDefeatCanvas.victoryAction?.Invoke();
    }
}
