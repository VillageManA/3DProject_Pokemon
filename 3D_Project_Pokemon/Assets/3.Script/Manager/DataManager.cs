using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    PokemonStats pokemonStats;
    PokemonData[] pokemonData;
    [SerializeField] GameObject[] pokemon;
    [SerializeField] SkillData[] PokemonSkill;
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
            pokemon[i].GetComponent<PokemonStats>().Name = pokemonData[i].Name;
<<<<<<< Updated upstream
            pokemon[i].GetComponent<PokemonStats>().MaxHp = pokemonData[i].MaxHp;
            pokemon[i].GetComponent<PokemonStats>().Hp = pokemonData[i].Hp;
            pokemon[i].GetComponent<PokemonStats>().Attack = pokemonData[i].Attack;
            pokemon[i].GetComponent<PokemonStats>().Defence = pokemonData[i].Defence;
            pokemon[i].GetComponent<PokemonStats>().SpAttack = pokemonData[i].SpAttack;
            pokemon[i].GetComponent<PokemonStats>().SpDefence = pokemonData[i].SpDefence;
            pokemon[i].GetComponent<PokemonStats>().Speed = pokemonData[i].Speed;
=======
            pokemon[i].GetComponent<PokemonStats>().obj = pokemon[i].gameObject;
            pokemon[i].GetComponent<PokemonStats>().defalut_MaxHp = pokemonData[i].MaxHp;
            pokemon[i].GetComponent<PokemonStats>().defalut_Attack = pokemonData[i].Attack;
            pokemon[i].GetComponent<PokemonStats>().defalut_Defence = pokemonData[i].Defence;
            pokemon[i].GetComponent<PokemonStats>().defalut_SpAttack = pokemonData[i].SpAttack;
            pokemon[i].GetComponent<PokemonStats>().defalut_SpDefence = pokemonData[i].SpDefence;
            pokemon[i].GetComponent<PokemonStats>().defalut_Speed = pokemonData[i].Speed;
            pokemon[i].GetComponent<PokemonStats>().Exp = pokemonData[i].Exp;
            pokemon[i].GetComponent<PokemonStats>().Level = pokemonData[i].Level;
>>>>>>> Stashed changes
            pokemon[i].GetComponent<PokemonStats>().Type1 = (PokemonStats.Type)pokemonData[i].Type1;
            pokemon[i].GetComponent<PokemonStats>().Type2 = (PokemonStats.Type)pokemonData[i].Type2;

            


            pokemon[i].GetComponent<PokemonStats>().ClearSkill();
            pokemon[i].GetComponent<PokemonStats>().AddSkill(PokemonSkill[pokemonData[i].Skill1]);
            pokemon[i].GetComponent<PokemonStats>().AddSkill(PokemonSkill[pokemonData[i].Skill2]);
            pokemon[i].GetComponent<PokemonStats>().AddSkill(PokemonSkill[pokemonData[i].Skill3]);
            pokemon[i].GetComponent<PokemonStats>().AddSkill(PokemonSkill[pokemonData[i].Skill4]);
<<<<<<< Updated upstream
=======
            pokemon[i].GetComponent<PokemonStats>().SkillPP = new int[4];

            for (int k = 0; k < 4; k++)
            {
                pokemon[i].GetComponent<PokemonStats>().SkillPP[k] = pokemon[i].GetComponent<PokemonStats>().skills[k].MaxPP;
            }
>>>>>>> Stashed changes

        }

    }
   

}
