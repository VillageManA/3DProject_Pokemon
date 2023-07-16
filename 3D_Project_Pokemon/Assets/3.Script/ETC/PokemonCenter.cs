using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PokemonCenter : MonoBehaviour
{
    PlayerData playerdata;

    private void Awake()
    {
        playerdata = FindObjectOfType<PlayerData>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SaveManager.instance.SavePlayerPokemonList(playerdata.player_Pokemon);
            SceneManager.LoadScene("MainField");
        }
    }
}
