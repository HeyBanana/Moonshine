using System.Collections.Generic;
using UnityEngine;

public class EntitySaver : MonoBehaviour
{
    private ISaveSystem saveSystem;

    [SerializeField] private List<Transform> entitiesToSave;

    private void Awake()
    {
        saveSystem = new SaveSystem();
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(Context.GameLaunchModKey, 0) == 1)
        {
            LoadAllEntity();
        }
    }

    public void SaveAllEntity()
    {
        foreach (var entity in entitiesToSave) 
        {
            var serializableEntity = entity.GetComponent<ISerializebleEntity>();
            saveSystem.Save(serializableEntity.GetSaveKey(), serializableEntity.GetSaveData());
        }
    }

    public void LoadAllEntity()
    {
        foreach (var entity in entitiesToSave)
        {
            var serializableEntity = entity.GetComponent<ISerializebleEntity>();

            var loadData = saveSystem.Load<EntitySaveData>(serializableEntity.GetSaveKey());

            if (loadData != null)
            {
                serializableEntity.InitFromSaveData(loadData);
            }
        }
    }    
}


