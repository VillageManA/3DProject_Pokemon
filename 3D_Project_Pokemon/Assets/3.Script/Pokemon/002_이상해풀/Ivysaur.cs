using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ivysaur : PokemonStats
{
    protected override void Start()
    {
        base.Start();

        //��ų������ ��������
        SkillData RazorLeaf = Resources.Load<SkillData>("Razor Leaf");
        SkillData VineWhip = Resources.Load<SkillData>("Vine Whip");
        SkillData Tackle = Resources.Load<SkillData>("Tackle");
        SkillData Cut = Resources.Load<SkillData>("Cut");
        //��ų ����Ʈ�� �߰��ϱ�
        AddSkill(RazorLeaf);
        AddSkill(VineWhip);
        AddSkill(Cut);
        AddSkill(Tackle);
        //Json ���Ͽ��� ��ų ������ �о����

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

        Debug.Log("�ִ�ü��" + MaxHp);
        Debug.Log("ü��" + Hp);
        Debug.Log("���ݷ�" + Attack);
        Debug.Log("����" + Defence);
        Debug.Log("Ư��" + SpAttack);
        Debug.Log("Ư��" + SpDefence);
        Debug.Log("���ǵ�" + Speed);
        Debug.Log("�Ӽ�1" + Type1);
        Debug.Log("�Ӽ�2" + Type2);
    }

}
