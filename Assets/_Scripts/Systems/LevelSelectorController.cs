using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorController : MonoBehaviour
{
    public void OnClick_SelectLevel(int levelID)
    {
        LoadingManager.Instance.LoadScene("Level" + levelID);
    }
}
