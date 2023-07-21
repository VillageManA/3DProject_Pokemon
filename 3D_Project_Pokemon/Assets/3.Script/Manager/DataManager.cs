using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    PokemonStats pokemonStats;
    PokemonData[] pokemonData;
    [SerializeField] GameObject[] pokemon;
    [SerializeField] SkillData[] PokemonSkill;
    [SerializeField] Sprite[] Pokemon_Icon;
    [SerializeField] Sprite[] Pokemon_Image;
    private void Awake()
    {
        pokemonStats = FindObjectOfType<PokemonStats>();
        pokemonData = pokemonStats.GetPokemonArray();


        SkillData[] skillDataArray = Resources.LoadAll<SkillData>("Skill");
        PokemonSkill = new SkillData[skillDataArray.Length];
        foreach (SkillData skillData in skillDataArray)
        {
            int index = skillData.Num;
            PokemonSkill[index] = skillData;
        }

        for (int i = 0; i < pokemon.Length; i++)
        {
            if (pokemon[i].TryGetComponent(out PokemonStats stat))
            {
                stat.Name = pokemonData[i].Name;
                stat.defalut_MaxHp = pokemonData[i].MaxHp;
                stat.defalut_Attack = pokemonData[i].Attack;
                stat.defalut_Defence = pokemonData[i].Defence;
                stat.defalut_SpAttack = pokemonData[i].SpAttack;
                stat.defalut_SpDefence = pokemonData[i].SpDefence;
                stat.defalut_Speed = pokemonData[i].Speed;
                stat.Type1 = (PokemonStats.Type)pokemonData[i].Type1;
                stat.Type2 = (PokemonStats.Type)pokemonData[i].Type2;
                stat.Icon = Pokemon_Icon[i];
                stat.Image = Pokemon_Image[i];
                stat.isAlive = true;
                stat.Setting_LevelStats();
                stat.Hp = pokemonData[i].MaxHp;
                stat.ClearSkill();
                stat.AddSkill(PokemonSkill[pokemonData[i].Skill1]);
                stat.AddSkill(PokemonSkill[pokemonData[i].Skill2]);
                stat.AddSkill(PokemonSkill[pokemonData[i].Skill3]);
                stat.AddSkill(PokemonSkill[pokemonData[i].Skill4]);
                stat.SkillPP = new int[4];
                for (int k = 0; k < 4; k++)
                {
                    stat.SkillPP[k] = pokemon[i].GetComponent<PokemonStats>().skills[k].MaxPP;
                }

            }
            //pokemon[i].GetComponent<PokemonStats>().Name = pokemonData[i].Name;
            //pokemon[i].GetComponent<PokemonStats>().defalut_MaxHp = pokemonData[i].MaxHp;
            //pokemon[i].GetComponent<PokemonStats>().defalut_Attack = pokemonData[i].Attack;
            //pokemon[i].GetComponent<PokemonStats>().defalut_Defence = pokemonData[i].Defence;
            //pokemon[i].GetComponent<PokemonStats>().defalut_SpAttack = pokemonData[i].SpAttack;
            //pokemon[i].GetComponent<PokemonStats>().defalut_SpDefence = pokemonData[i].SpDefence;
            //pokemon[i].GetComponent<PokemonStats>().defalut_Speed = pokemonData[i].Speed;
            //pokemon[i].GetComponent<PokemonStats>().Type1 = (PokemonStats.Type)pokemonData[i].Type1;
            //pokemon[i].GetComponent<PokemonStats>().Type2 = (PokemonStats.Type)pokemonData[i].Type2;
            //pokemon[i].GetComponent<PokemonStats>().Icon = Pokemon_Icon[i];
            //pokemon[i].GetComponent<PokemonStats>().Image = Pokemon_Image[i];
            //pokemon[i].GetComponent<PokemonStats>().isAlive = true;
            //pokemon[i].GetComponent<PokemonStats>().Setting_LevelStats();
            //pokemon[i].GetComponent<PokemonStats>().Hp = pokemonData[i].MaxHp;
            //pokemon[i].GetComponent<PokemonStats>().ClearSkill();
            //pokemon[i].GetComponent<PokemonStats>().AddSkill(PokemonSkill[pokemonData[i].Skill1]);
            //pokemon[i].GetComponent<PokemonStats>().AddSkill(PokemonSkill[pokemonData[i].Skill2]);
            //pokemon[i].GetComponent<PokemonStats>().AddSkill(PokemonSkill[pokemonData[i].Skill3]);
            //pokemon[i].GetComponent<PokemonStats>().AddSkill(PokemonSkill[pokemonData[i].Skill4]);
            //pokemon[i].GetComponent<PokemonStats>().SkillPP = new int[4];
            //for (int k = 0; k < 4; k++)
            //{
            //    pokemon[i].GetComponent<PokemonStats>().SkillPP[k] = pokemon[i].GetComponent<PokemonStats>().skills[k].MaxPP;
            //}
        }

    }

}
