using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonCenterNPC : MonoBehaviour
{
    PlayerData playerdata;
    [SerializeField] MainFieldText mainFieldText;
    private void Awake()
    {
        playerdata = FindObjectOfType<PlayerData>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                for (int i = 0; i < playerdata.player_Pokemon.Count; i++)
                {
                    playerdata.player_Pokemon[i].Hp = playerdata.player_Pokemon[i].MaxHp; //체력회복
                    for (int j = 0; j < 4; j++) //pp회복
                    {
                        playerdata.player_Pokemon[i].SkillPP[j] = playerdata.player_Pokemon[i].skills[j].MaxPP;

                    }
                }
                mainFieldText.TextPlay("회복되었단다.");
                return;
            }
        }
    }
}
