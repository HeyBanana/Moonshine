using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   public static  bool GameIsPause = false;
   public AudioClip PauseMusicClip = null;
   public GameObject GameMusicManager = null;

    public GameObject pauseMenuUI;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

     void Pause()
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
