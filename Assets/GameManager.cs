using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        
        SaveData saveData = new SaveData();
        saveData.playerHealth = 100;
        saveData.playerAmmo = 100;
        saveData.playerGold = 200;
        saveData.playerPositionX = 10f;
        saveData.playerPositionY = 5f;
        saveData.playerPositionZ = 1f;
        SaveLoadManager.SaveGame(saveData);

        
        SaveData loadedData = SaveLoadManager.LoadGame();
        if (loadedData != null)
        {
            Debug.Log("Player health: " + loadedData.playerHealth);
            Debug.Log("Player position: (" + loadedData.playerPositionX + ", " + loadedData.playerPositionY + ")");
        }
    }
}