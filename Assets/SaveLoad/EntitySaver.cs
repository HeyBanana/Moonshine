using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EntitySaver : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt(Context.GameLaunchModKey, 0) == 1)
         { 
            LoadAllEntity();
        }
    }
    public void SaveAllEntity()
    {
       var entitys = GetComponentsInChildren<ISerializebleEntity>();
       
        foreach (var entity in entitys) 
        {
            var savedata = entity.GetSaveData();
            Context.Instance.SaveSystem.Save<EntitySaveData>(entity.GetSaveKey(), entity.GetSaveData());
        }

    }
    public void LoadAllEntity()
    {
        var entitys = GetComponentsInChildren<ISerializebleEntity>();

        foreach (var entity in entitys)
        {
            var loaddata = Context.Instance.SaveSystem.Load<EntitySaveData>(entity.GetSaveKey());
            if (loaddata != null)
            {
                entity.InitFromSaveData(loaddata);
            }
            
        }

    }    

}


