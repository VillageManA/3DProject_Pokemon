using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class temp : MonoBehaviour
{
    PlayerData player;

    private void OnEnable()
    {
        player = FindObjectOfType<PlayerData>();
        //player.player_Pokemon = SaveManager.instance.LoadPlayerPokemonList();
        Debug.Log(player.player_Pokemon[1].Name);
        //player.player_Pokemon_List = player.ListToArray();
        Debug.Log(player.player_Pokemon_List[1].Name);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SaveManager.instance.SavePlayerPokemonList(player.player_Pokemon);
            SceneManager.LoadScene("Battle");
        }
    }
}
