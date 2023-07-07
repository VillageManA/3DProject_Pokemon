using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class SaveManager : MonoBehaviour
{
    //싱글톤 선언
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
        // 딕셔너리를 JSON 문자열로 변환
        string json = JsonUtility.ToJson(inventoryData);

        // JSON 문자열을 파일로 저장
        string filePath = Path.Combine(Application.persistentDataPath, "inventory.json");
        File.WriteAllText(filePath, json);
    }

    public Dictionary<ItemData, int> LoadInventory()
    {
        Dictionary<ItemData, int> inventoryData = new Dictionary<ItemData, int>();

        // 저장된 JSON 파일을 불러옴
        string filePath = Path.Combine(Application.persistentDataPath, "inventory.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            // JSON 문자열을 딕셔너리로 역직렬화
            inventoryData = JsonUtility.FromJson<Dictionary<ItemData, int>>(json);
        }

        return inventoryData;
    }
}
