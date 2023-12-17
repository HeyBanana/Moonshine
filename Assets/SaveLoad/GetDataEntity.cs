using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDataEntity : MonoBehaviour
{
  public PlayerEntity PlayerEntity;
    public BaseEntity BaseEntity;

    private void Start()
    {
        PlayerEntity = new PlayerEntity();

        SaveEntity();
    }

    public void SaveEntity()
    {
        PlayerEntity.GetSaveData(PlayerEntity);
    }

    public void LoadEntity()
    {
        PlayerEntity = PlayerEntity.LoadEntity();
    }
}


