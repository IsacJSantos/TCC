using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvasController : MonoBehaviour
{
    [SerializeField]
    private MenuScreen currentMenuScreen;

    private void SwitchMenu(MenuScreen newMenu) 
    {
        currentMenuScreen?.Hide();
        currentMenuScreen = newMenu;
        currentMenuScreen.Show();
    }

    public void OnClick_OpenMenu(MenuScreen menuScreen) 
    {
        SwitchMenu(menuScreen);
    }
}
