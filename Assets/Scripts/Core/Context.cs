public class Context
{
    public const string GameLaunchModKey = "GameLaunch";

    private static Context _instance;
    public static Context Instance => _instance ??= new Context();

    private Context()
    {
        Initialize();
        _instance = this;
    }

    private void Initialize()
    {
        // Future code
    }
}
