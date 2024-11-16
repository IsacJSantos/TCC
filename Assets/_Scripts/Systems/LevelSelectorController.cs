using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorController : MonoBehaviour
{
    public void SelectLevel(int levelID)
    {
        LoadingManager.Instance.LoadScene("Level" + levelID);
    }
}
