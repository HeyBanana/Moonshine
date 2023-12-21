public interface ISerializebleEntity
{
    public EntitySaveData GetSaveData();
    public void InitFromSaveData(EntitySaveData entitySaveData);
    public string GetSaveKey();
}
