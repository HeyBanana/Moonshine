using UnityEngine.SceneManagement;

public class Loader
{
    public enum Scene
    {
        StartMenu,
        FirstLevel
    }

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
