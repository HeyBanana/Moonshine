using UnityEngine;

public interface ISaveSystem
{
    void Save<T>(string key, T saveObject);
    
    T Load<T>(string key);
}

public class SaveSystem : ISaveSystem
{
    public void Save<T>(string key, T saveObject)
    { 
        var json = JsonUtility.ToJson(saveObject);
        PlayerPrefs.SetString(key, json);
    }

    public T Load<T>(string key)
    {
        string json = PlayerPrefs.GetString(key, "");

        if (string.IsNullOrEmpty(json))
            return default;

        T res = JsonUtility.FromJson<T>(json);
        return res;
    }
}