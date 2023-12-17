using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEntity : BaseEntity, ISerializebleEntity
{
    // ToDo: Player specific logic will be here 
    public EntitySaveData GetSaveData(PlayerEntity playerEntity)
    {
        var saveData = new EntitySaveData();

        saveData.CurentPosition = WorldPosition;
        
        return saveData;
    }

    public string GetSaveKey()
    {
       
        return "Player";
    }

    public void InitFromSaveData(EntitySaveData entitySaveData)
    
    {
        transform.position = entitySaveData.CurentPosition;    
    }
    
       
}
