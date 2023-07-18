using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusPokemon : MonoBehaviour
{
    PlayerData playerData;
    MainFieldText mainfieldText;

    [SerializeField] PokemonStats[] SettingPokemon;
    private int Pokenum=0;
    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        mainfieldText = FindObjectOfType<MainFieldText>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (playerData.player_Pokemon.Count < 6)
                {
                    playerData.AddPokemon(SettingPokemon[Pokenum]);
                    mainfieldText.TextPlay($"{SettingPokemon[Pokenum].Name}이(가) 추가되었단다.");
                    Pokenum++;
                }

            }
        }
    }
}
