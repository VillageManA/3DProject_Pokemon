using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private Vector3 player_Position;
    public List<PokemonStats> player_Pokemon = new List<PokemonStats>();

    [Header("미리 준비된 6마리 포켓몬")]
    [SerializeField] private PokemonStats[] setting_Pokemon;
    private void SetPosition()
    {
        gameObject.transform.position = player_Position;
    }
    public void AddPokemon(PokemonStats Target)
    {
        player_Pokemon.Add(Target);
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
