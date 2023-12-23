using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        soundManager.PlayMenuClick();
        Loader.Load(Loader.Scene.FirstLevel, Loader.LaunchMode.New);
    }

    public void QuitGame()
    {
        soundManager.PlayMenuClick();
        Application.Quit();
    }

    public void Load()
    {
        soundManager.PlayMenuClick();
        Loader.Load(Loader.Scene.FirstLevel, Loader.LaunchMode.Load);
    }
}
