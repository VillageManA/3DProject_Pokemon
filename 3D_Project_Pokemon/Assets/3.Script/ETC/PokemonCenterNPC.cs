using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonCenterNPC : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for (int i = 0; i < other.GetComponent<PlayerData>().player_Pokemon.Count; i++)
                {

                    other.GetComponent<PlayerData>().player_Pokemon[i].Hp = other.GetComponent<PlayerData>().player_Pokemon[i].MaxHp; //ü��ȸ��

                    for (int j = 0; j < 4; j++) //ppȸ��
                    {
                        other.GetComponent<PlayerData>().player_Pokemon[i].SkillPP[j] = other.GetComponent<PlayerData>().player_Pokemon[i].skills[j].MaxPP;

                    }
                }
            }
        }
    }
}
