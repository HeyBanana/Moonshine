using UnityEngine;

public abstract class BaseEntity : MonoBehaviour, ISerializebleEntity
{
    public abstract EntitySaveData GetSaveData();
    public abstract string GetSaveKey();
    public abstract void InitFromSaveData(EntitySaveData entitySaveData);
}
