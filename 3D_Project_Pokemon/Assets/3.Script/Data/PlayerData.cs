using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private Vector3 instantiate_zone = new Vector3(999, 999, 999);
    public List<PokemonStats> player_Pokemon = new List<PokemonStats>();
    public PokemonStats[] player_Pokemon_List;

    [Header("미리 준비된 6마리 포켓몬")]
    [SerializeField] public PokemonStats[] setting_Pokemon;
    private void Start()
    {
        player_Pokemon = SaveManager.instance.LoadPlayerPokemonList();
        player_Pokemon_List = ListToArray();
        //player_Pokemon.Clear();



        foreach (PokemonStats loadedPokemon in player_Pokemon_List)
        {
            string pokemonName = loadedPokemon.Name;
            //Debug.Log(loadedPokemon.Name);
            // 프리팹을 찾아서 추가
            PokemonStats prefab = FindPokemonPrefab(pokemonName);
            if (prefab != null)
            {
                AddPokemon(prefab);
            }
        }
        setInitialization();
        player_Pokemon_List = ListToArray();

    }

    public void AddPokemon(PokemonStats Target)
    {
        if (Target != null)
        {
            PokemonStats newPokemonPrefab = FindPokemonPrefab(Target.Name);
            if (newPokemonPrefab != null)
            {
                PokemonStats newPokemon = Instantiate(newPokemonPrefab, instantiate_zone, Quaternion.identity);
                player_Pokemon.Add(newPokemon);
            }
        }
    }
    public void RemovePokemon(PokemonStats Target)
    {
        player_Pokemon.Remove(Target);
    }


    public PokemonStats[] SettingPokemon()
    {
        player_Pokemon.Clear();
        for (int i = 0; i < 6; i++)
        {
            AddPokemon(setting_Pokemon[i]);
        }
        PokemonStats[] pokemon = player_Pokemon.ToArray();
        return pokemon;

    }
    public PokemonStats[] ListToArray()
    {
        PokemonStats[] pokemon = player_Pokemon.ToArray();
        return pokemon;
    }

    private PokemonStats FindPokemonPrefab(string name)
    {
        // Resources 폴더에서 모든 포켓몬 프리팹을 로드합니다.
        PokemonStats[] allPrefabs = Resources.LoadAll<PokemonStats>("Model");

        foreach (PokemonStats prefab in allPrefabs)
        {
            if (prefab.Name == name)
            {
                return prefab;
            }
        }

        return null;
    }

    public void setInitialization()
    {
        for (int i = 0; i < player_Pokemon_List.Length; i++)
        {
            player_Pokemon[i + player_Pokemon_List.Length].Level = player_Pokemon[i].Level;
            player_Pokemon[i + player_Pokemon_List.Length].MaxHp = player_Pokemon[i].MaxHp;
            player_Pokemon[i + player_Pokemon_List.Length].Hp = player_Pokemon[i].Hp;
            player_Pokemon[i + player_Pokemon_List.Length].Exp = player_Pokemon[i].Exp;
            player_Pokemon[i + player_Pokemon_List.Length].Attack = player_Pokemon[i].Attack;
            player_Pokemon[i + player_Pokemon_List.Length].SpAttack = player_Pokemon[i].SpAttack;
            player_Pokemon[i + player_Pokemon_List.Length].Defence = player_Pokemon[i].Defence;
            player_Pokemon[i + player_Pokemon_List.Length].SpDefence = player_Pokemon[i].SpDefence;
            player_Pokemon[i + player_Pokemon_List.Length].Speed = player_Pokemon[i].Speed;
            player_Pokemon[i + player_Pokemon_List.Length].SkillPP[0] = player_Pokemon[i].SkillPP[0];
            player_Pokemon[i + player_Pokemon_List.Length].SkillPP[1] = player_Pokemon[i].SkillPP[1];
            player_Pokemon[i + player_Pokemon_List.Length].SkillPP[2] = player_Pokemon[i].SkillPP[2];
            player_Pokemon[i + player_Pokemon_List.Length].SkillPP[3] = player_Pokemon[i].SkillPP[3];
            player_Pokemon[i + player_Pokemon_List.Length].isAlive = player_Pokemon[i].isAlive;
            player_Pokemon[i].Setting_LevelStats();
        }
        for (int i = 0; i < player_Pokemon_List.Length; i++)
        {
            player_Pokemon.RemoveAt(0);
        }
    }
}
