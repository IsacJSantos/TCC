using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    [SerializeField]
    private Canvas menuCanvas;
    [SerializeField]
    private Canvas pauseMenuCanvas;
    [SerializeField]
    private Canvas vicoryMenuCanvas;
    [SerializeField]
    private Canvas defeatMenuCanvas;



    private void Awake()
    {
        Events.Victory += ShowVictoryScreen;
        Events.Defeat += ShowDefeatScreen;
    }

    private void OnDestroy()
    {
        Events.Victory -= ShowVictoryScreen;
        Events.Defeat -= ShowDefeatScreen;
    }
    public void OnClick_PauseGame()
    {
        pauseMenuCanvas.enabled = true;
        Time.timeScale = 0;
    }

    public void OnClick_ResumeGame()
    {
        pauseMenuCanvas.enabled = false;
        Time.timeScale = 1;
    }

    public void OnClick_BackToMain()
    {
        LoadingManager.Instance.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void OnClick_RestartGame()
    {
        Time.timeScale = 1;
        LoadingManager.Instance.LoadScene("Level" + GameController.Instance.getCurrentSceneID);
    }

    public void OnClick_LoadNextLevel()
    {
        LoadingManager.Instance.LoadScene("Level" + (GameController.Instance.getCurrentSceneID + 1));
    }

    public void ShowVictoryScreen()
    {
        vicoryMenuCanvas.enabled = true;
    }

    public void ShowDefeatScreen()
    {
        defeatMenuCanvas.enabled = true;
    }
}
