using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Center : MonoBehaviour
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
            PlayerControl.Instance.gameObject.SetActive(false);
            PlayerControl.Instance.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
            SceneManager.LoadScene("PokemonCenter");
        }
    }
}
