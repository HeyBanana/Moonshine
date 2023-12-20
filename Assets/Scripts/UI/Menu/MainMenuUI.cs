using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void PlayGame()
    {
        Loader.Load(Loader.Scene.FirstLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
