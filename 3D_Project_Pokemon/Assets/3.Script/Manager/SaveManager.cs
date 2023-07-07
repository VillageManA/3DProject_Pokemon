using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class SaveManager : MonoBehaviour
{
    //�̱��� ����
    public static SaveManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    string jsonFileName_Player = "DataBase/PlayerData.json";
    string jsonFileName_Pokemon = "DataBase/PokemonData.json";

    public void SaveInventory(Dictionary<ItemData, int> inventoryData)
    {
        // ��ųʸ��� JSON ���ڿ��� ��ȯ
        string json = JsonUtility.ToJson(inventoryData);

        // JSON ���ڿ��� ���Ϸ� ����
        string filePath = Path.Combine(Application.persistentDataPath, "inventory.json");
        File.WriteAllText(filePath, json);
    }

    public Dictionary<ItemData, int> LoadInventory()
    {
        Dictionary<ItemData, int> inventoryData = new Dictionary<ItemData, int>();

        // ����� JSON ������ �ҷ���
        string filePath = Path.Combine(Application.persistentDataPath, "inventory.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            // JSON ���ڿ��� ��ųʸ��� ������ȭ
            inventoryData = JsonUtility.FromJson<Dictionary<ItemData, int>>(json);
        }

        return inventoryData;
    }
}
