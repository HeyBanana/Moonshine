using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class PlayerEntity : BaseEntity, ISerializebleEntity
{
    [SerializeField] CharacterController characterController;

    // ToDo: Player specific logic will be here 

    public EntitySaveData GetSaveData()
    {
        //Helth, Ammo,Weapon etc
        var savedata = new EntitySaveData();
        savedata.CurentPosition = WorldPosition;
        return savedata;
    }

    public string GetSaveKey()
    {

        return "Player";
    }

    
    public void InitFromSaveData(EntitySaveData entitySaveData)
    {
        //Weapon, Health ect
        characterController.enabled = false;  
        transform.position = entitySaveData.CurentPosition;
        characterController.enabled = true;
        
    }

    
}
