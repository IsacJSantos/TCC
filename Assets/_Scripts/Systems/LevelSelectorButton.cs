using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorButton : MonoBehaviour
{
    [SerializeField]
    private LevelSelectorController selectorController;
    [SerializeField]
    private int levelID;
    [SerializeField]
    private Button button;
    [SerializeField]
    private GameObject lockedGroup;

    private void Start()
    {
        bool levelUnlocked = levelID == 1 ? true : PlayerPrefs.GetInt("Level" + levelID, 0) == 1;

        lockedGroup.SetActive(!levelUnlocked);
        button.interactable = levelUnlocked;
    }

    public void OnClick_SelectLevel()
    {
        selectorController.SelectLevel(levelID);
    }
}
