using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class temp : MonoBehaviour
{
    PlayerData player;

    private void Start()
    {
        PlayerControl.Instance.gameObject.SetActive(true);
        player = FindObjectOfType<PlayerData>();
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SaveManager.instance.SavePlayerPokemonList(player.player_Pokemon);
            SceneManager.LoadSceneAsync("Battle");
        }
    }
}
