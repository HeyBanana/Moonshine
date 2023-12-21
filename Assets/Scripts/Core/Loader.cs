using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader
{
    public enum Scene
    {
        StartMenu,
        FirstLevel
    }

    public enum LaunchMode
    {
        New,
        Load
    }

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public static void Load(Scene scene, LaunchMode launchMode)
    {
        PlayerPrefs.SetInt(Context.GameLaunchModKey, (int)launchMode);
        SceneManager.LoadScene(scene.ToString());
    }
}
