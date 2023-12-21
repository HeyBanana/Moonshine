using UnityEngine;

public class PlayerEntity : BaseEntity
{
    [SerializeField] CharacterController characterController;

    public override EntitySaveData GetSaveData()
    {
        var savedata = new EntitySaveData
        {
            CurentPosition = transform.position
        };

        return savedata;
    }

    public override string GetSaveKey() => "Player";
    
    public override void InitFromSaveData(EntitySaveData entitySaveData)
    {
        characterController.enabled = false;  
        transform.position = entitySaveData.CurentPosition;
        characterController.enabled = true;
    }
}
