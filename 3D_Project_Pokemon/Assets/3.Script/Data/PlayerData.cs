using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private Vector3 player_Position;
    private Vector3 instantiate_zone = new Vector3(999, 999, 999);
    public List<PokemonStats> player_Pokemon = new List<PokemonStats>();
    public PokemonStats[] player_Pokemon_List;

    [Header("미리 준비된 6마리 포켓몬")]
    [SerializeField] public PokemonStats[] setting_Pokemon;
    private void Start()
    {   
        player_Pokemon = SaveManager.instance.LoadPlayerPokemonList();
        Debug.Log(player_Pokemon[0].Name);
        player_Pokemon_List = ListToArray();
        Debug.Log(player_Pokemon_List[0].Name);

    }
    private void SetPosition()
    {
        gameObject.transform.position = player_Position;
    }
    public void AddPokemon(PokemonStats Target)
    {
        PokemonStats newpokemon = new PokemonStats();
        newpokemon = Instantiate(Target, instantiate_zone, Quaternion.identity);
        player_Pokemon.Add(newpokemon);
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


}
