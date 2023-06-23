using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ivysaur : PokemonStats
{
    protected override void Start()
    {
        base.Start();

        //스킬데이터 가져오기
        SkillData RazorLeaf = Resources.Load<SkillData>("Razor Leaf");
        SkillData VineWhip = Resources.Load<SkillData>("Vine Whip");
        SkillData Tackle = Resources.Load<SkillData>("Tackle");
        SkillData Cut = Resources.Load<SkillData>("Cut");
        //스킬 리스트에 추가하기
        AddSkill(RazorLeaf);
        AddSkill(VineWhip);
        AddSkill(Cut);
        AddSkill(Tackle);
        //Json 파일에서 스킬 데이터 읽어오기

        PokemonData ivysaur = GetPokemonArray()[1];
        MaxHp = ivysaur.MaxHp;
        Hp = ivysaur.MaxHp;
        Attack = ivysaur.Attack;
        Defence = ivysaur.Defence;
        SpAttack = ivysaur.SpAttack;
        SpDefence = ivysaur.SpDefence;
        Speed = ivysaur.Speed;
        Type1 = (Type)ivysaur.Type1;
        Type2 = (Type)ivysaur.Type2;

        Debug.Log("최대체력" + MaxHp);
        Debug.Log("체력" + Hp);
        Debug.Log("공격력" + Attack);
        Debug.Log("방어력" + Defence);
        Debug.Log("특공" + SpAttack);
        Debug.Log("특방" + SpDefence);
        Debug.Log("스피드" + Speed);
        Debug.Log("속성1" + Type1);
        Debug.Log("속성2" + Type2);
    }

}
