using Moonshine.Core;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    private static bool GameIsPause = false;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private EntitySaver entitySaver;

    private void Update()
    {
        if (GameInput.Instanse.IsPausePressed())
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Save()
    {
        entitySaver.SaveAllEntity();
    }

    public void Load()
    {
        Resume();

        Loader.Load(Loader.Scene.FirstLevel, Loader.LaunchMode.Load);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.StartMenu);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game....");
    }
}
