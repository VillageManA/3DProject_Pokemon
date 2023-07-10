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
        string json = JsonMapper.ToJson(inventoryData);

        // JSON 문자열을 파일로 저장
        string filePath = Path.Combine(Application.persistentDataPath, "inventory.json");

        // 파일이 존재하지 않으면 생성
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }
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
    public void SavePlayerPokemonList(List<PokemonStats> pokemonList)
    {
        List<PokemonData> pokemonDataList = new List<PokemonData>();

        foreach (PokemonStats pokemon in pokemonList)
        {
            PokemonData pokemonData = new PokemonData();

            // 매핑을 수행하여 PokemonData에 필요한 속성을 복사
            pokemonData.Name = pokemon.Name;
            pokemonData.MaxHp = pokemon.MaxHp;
            pokemonData.Hp = pokemon.Hp;
            pokemonData.Attack = pokemon.Attack;
            pokemonData.Defence = pokemon.Defence;
            pokemonData.SpAttack = pokemon.SpAttack;
            pokemonData.SpDefence = pokemon.SpDefence;
            pokemonData.Speed = pokemon.Speed;
            pokemonData.Type1 = (int)pokemon.Type1;
            pokemonData.Type2 = (int)pokemon.Type2;
            // 나머지 속성 복사    

            pokemonDataList.Add(pokemonData);
        }
        // 포켓몬 데이터 리스트를 JSON 문자열로 변환
        string json = JsonMapper.ToJson(pokemonDataList);

        // JSON 문자열을 파일로 저장
        string filePath = Path.Combine(Application.persistentDataPath, "player_pokemon.json");
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }
        Debug.Log(filePath);
        File.WriteAllText(filePath, json);
    }

    public List<PokemonStats> LoadPlayerPokemonList()
    {
        List<PokemonStats> pokemonList = new List<PokemonStats>();

        // 저장된 JSON 파일을 불러옴
        string filePath = Path.Combine(Application.persistentDataPath, "player_pokemon.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            // JSON 문자열을 포켓몬 데이터 리스트로 역직렬화
            List<PokemonData> pokemonDataList = JsonMapper.ToObject<List<PokemonData>>(json);

            foreach (PokemonData pokemonData in pokemonDataList)
            {
                PokemonStats pokemon = new PokemonStats();

                // 매핑을 수행하여 PokemonStats에 필요한 속성을 복사
                pokemon.Name = pokemonData.Name;
                pokemon.MaxHp = pokemonData.MaxHp;
                pokemon.Hp = pokemonData.Hp;
                pokemon.Attack = pokemonData.Attack;
                pokemon.Defence = pokemonData.Defence;
                pokemon.SpAttack = pokemonData.SpAttack;
                pokemon.SpDefence = pokemonData.SpDefence;
                pokemon.Speed = pokemonData.Speed;
                pokemon.Type1 = (PokemonStats.Type)pokemonData.Type1;
                pokemon.Type2 = (PokemonStats.Type)pokemonData.Type2;
                // 나머지 속성 복사

                pokemonList.Add(pokemon);
            }
        }
        return pokemonList;
    }

}
