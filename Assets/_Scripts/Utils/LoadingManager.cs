using UnityEngine.SceneManagement;

public class LoadingManager : Singleton<LoadingManager>
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
