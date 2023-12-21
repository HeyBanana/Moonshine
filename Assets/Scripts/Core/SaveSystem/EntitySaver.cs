using UnityEngine;

public class EntitySaver : MonoBehaviour
{
    private ISaveSystem saveSystem;

    private void Awake()
    {
        saveSystem = new SaveSystem();

        if (PlayerPrefs.GetInt(Context.GameLaunchModKey, 0) == 1)
         { 
            LoadAllEntity();
        }
    }

    public void SaveAllEntity()
    {
       var entities = GetComponentsInChildren<ISerializebleEntity>();
       
        foreach (var entity in entities) 
        {
            saveSystem.Save(entity.GetSaveKey(), entity.GetSaveData());
        }
    }

    public void LoadAllEntity()
    {
        var entitys = GetComponentsInChildren<ISerializebleEntity>();

        foreach (var entity in entitys)
        {
            var loadData = saveSystem.Load<EntitySaveData>(entity.GetSaveKey());

            if (loadData != null)
            {
                entity.InitFromSaveData(loadData);
            }
        }
    }    
}


