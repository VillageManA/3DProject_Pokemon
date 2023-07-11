using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class temp_Intro : MonoBehaviour
{
    PlayerData playerdata;
    private void Awake()
    {
        playerdata = FindObjectOfType<PlayerData>();
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SaveManager.instance.SavePlayerPokemonList(playerdata.player_Pokemon);
            SceneManager.LoadSceneAsync("MainField");
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            if (playerdata.player_Pokemon_List == null || playerdata.player_Pokemon_List.Length == 0)
            {
                playerdata.AddPokemon(playerdata.setting_Pokemon[0]);
                playerdata.AddPokemon(playerdata.setting_Pokemon[1]);
                playerdata.player_Pokemon_List = playerdata.ListToArray();
            }
        }
    }
}
