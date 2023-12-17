using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISerializebleEntity
{
    public EntitySaveData GetSaveData();
    public void InitFromSaveData(EntitySaveData entitySaveData);
    public string GetSaveKey();

     
}
