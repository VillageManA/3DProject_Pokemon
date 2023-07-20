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

    public void SaveInventory(Dictionary<ItemData, int> inventoryData)
    {
        // ��ųʸ��� JSON ���ڿ��� ��ȯ
        string json = JsonMapper.ToJson(inventoryData);

        // JSON ���ڿ��� ���Ϸ� ����
        string filePath = Path.Combine(Application.persistentDataPath, "inventory.json");

        // ������ �������� ������ ����
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }
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
    public void SavePlayerPokemonList(List<PokemonStats> pokemonList)
    {
        List<PokemonData> pokemonDataList = new List<PokemonData>();

        foreach (PokemonStats pokemon in pokemonList)
        {
            PokemonData pokemonData = new PokemonData();

            // ������ �����Ͽ� PokemonData�� �ʿ��� �Ӽ��� ����
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
            pokemonData.Exp = pokemon.Exp;
            pokemonData.Level = pokemon.Level;
            pokemonData.Skill1 = pokemon.SkillPP[0];
            pokemonData.Skill2 = pokemon.SkillPP[1];
            pokemonData.Skill3 = pokemon.SkillPP[2];
            pokemonData.Skill4 = pokemon.SkillPP[3];
            pokemonData.isAlive = pokemon.isAlive;
            // ������ �Ӽ� ����    
            pokemonDataList.Add(pokemonData);
        }
        // ���ϸ� ������ ����Ʈ�� JSON ���ڿ��� ��ȯ
        string json = JsonMapper.ToJson(pokemonDataList);

        // JSON ���ڿ��� ���Ϸ� ����
        string filePath = Path.Combine(Application.persistentDataPath, "player_pokemon.json");
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }
        File.WriteAllText(filePath, json);



    }

    public List<PokemonStats> LoadPlayerPokemonList()
    {
        List<PokemonStats> pokemonList = new List<PokemonStats>();

        // ����� JSON ������ �ҷ���
        string filePath = Path.Combine(Application.persistentDataPath, "player_pokemon.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            // JSON ���ڿ��� ���ϸ� ������ ����Ʈ�� ������ȭ
            List<PokemonData> pokemonDataList = JsonMapper.ToObject<List<PokemonData>>(json);

            foreach (PokemonData pokemonData in pokemonDataList)
            {
                PokemonStats pokemon = new PokemonStats();

                // ������ �����Ͽ� PokemonStats�� �ʿ��� �Ӽ��� ����
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
                pokemon.Exp = pokemonData.Exp;
                pokemon.Level = pokemonData.Level;
                pokemon.SkillPP[0] = pokemonData.Skill1;
                pokemon.SkillPP[1] = pokemonData.Skill2;
                pokemon.SkillPP[2] = pokemonData.Skill3;
                pokemon.SkillPP[3] = pokemonData.Skill4;
                pokemon.isAlive = pokemonData.isAlive;
                //pokemon.obj = pokemonData.obj;
                // ������ �Ӽ� ����



                pokemonList.Add(pokemon);
            }
        }
        return pokemonList;
    }



}
