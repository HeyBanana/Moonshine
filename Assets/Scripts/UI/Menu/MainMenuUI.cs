using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        Loader.Load(Loader.Scene.FirstLevel, Loader.LaunchMode.New);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Load()
    {
        Loader.Load(Loader.Scene.FirstLevel, Loader.LaunchMode.Load);
    }
}
