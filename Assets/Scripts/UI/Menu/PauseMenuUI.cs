using Moonshine.Core;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    private static bool GameIsPause = false;

    public GameObject pauseMenuUI;

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

    public void LoadMenu()
    {
        Debug.Log("Loading menu....");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game....");
    }
}
