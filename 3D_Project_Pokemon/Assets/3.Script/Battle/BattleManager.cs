using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    //Ÿ�Է�ũ
    public float DamageRank = 1;
    //�ڼӷ�ũ
    public float PropertyRank = 1;
    //�������ͽ� ��ũ
    public float AttackerAttackRank = 1;
    public float AttackerSpAttackRank = 1;
    public float AttackerDefenceRank = 1;
    public float AttackerSpDefenceRank = 1;
    public float AttackerSpeedRank = 1;
    public float AttackerHitrateRank = 1;

    public float TargetAttackRank = 1;
    public float TargetSpAttackRank = 1;
    public float TargetDefenceRank = 1;
    public float TargetSpDefenceRank = 1;
    public float TargetSpeedRank = 1;
    public float TargetHitrateRank = 1;

    //���� ������
    private float Damage = 0;
    [SerializeField] Text Explain_txt;
    public void OnDamage(SkillData skill, PokemonStats attacker, PokemonStats target)
    {
        CheckProPertyType(skill, attacker);
        CheckDamageType(skill, target);
        CheckStateRank(attacker, target);
        if (skill.AttackType == SkillData.attackType.Attack)
        {
            Damage = ((attacker.Attack * AttackerAttackRank) * skill.Damage * (attacker.Level * 2 / 5 + 2) / (target.Defence * TargetDefenceRank) / 50 + 2) * PropertyRank * DamageRank;
        }
        if (skill.AttackType == SkillData.attackType.Speicial)
        {
            Damage = ((attacker.SpAttack * AttackerSpAttackRank) * skill.Damage * (attacker.Level * 2 / 5 + 2) / (target.SpDefence * TargetSpDefenceRank) / 50 + 2) * PropertyRank * DamageRank;
        }


        if(DamageRank==0)
        {
            Damage = 0;
        }

        target.Hp -= (int)Damage;
        Debug.Log("{0}���� {1}��ŭ�� �������� �־���!" + target.name + Damage);

        //��Ʋ �������� �ʱ�ȭ
        PropertyRank = 1;
        DamageRank = 1;
    }
    public void CheckDamageType(SkillData skill, PokemonStats pokemon)
    {
        if (skill.propertyType == SkillData.PropertyType.Normal)
        {
            if (pokemon.Type1 == PokemonStats.Type.Rock || pokemon.Type2 == PokemonStats.Type.Rock)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Ghost || pokemon.Type2 == PokemonStats.Type.Ghost)
            {
                DamageRank *= 0f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 0.5f;
            }

        } //�븻Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Fight)
        {
            if (pokemon.Type1 == PokemonStats.Type.Normal || pokemon.Type2 == PokemonStats.Type.Normal)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Ice || pokemon.Type2 == PokemonStats.Type.Ice)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Poison || pokemon.Type2 == PokemonStats.Type.Poison)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Flight || pokemon.Type2 == PokemonStats.Type.Flight)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Esper || pokemon.Type2 == PokemonStats.Type.Esper)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Bug || pokemon.Type2 == PokemonStats.Type.Bug)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Rock || pokemon.Type2 == PokemonStats.Type.Rock)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Ghost || pokemon.Type2 == PokemonStats.Type.Ghost)
            {
                DamageRank *= 0f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Evil || pokemon.Type2 == PokemonStats.Type.Evil)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Fairy || pokemon.Type2 == PokemonStats.Type.Fairy)
            {
                DamageRank *= 0.5f;
            }
        }//����Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Poison)
        {
            if (pokemon.Type1 == PokemonStats.Type.Grass || pokemon.Type2 == PokemonStats.Type.Grass)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Poison || pokemon.Type2 == PokemonStats.Type.Poison)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Earth || pokemon.Type2 == PokemonStats.Type.Earth)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Rock || pokemon.Type2 == PokemonStats.Type.Rock)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Ghost || pokemon.Type2 == PokemonStats.Type.Ghost)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 0f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Fairy || pokemon.Type2 == PokemonStats.Type.Fairy)
            {
                DamageRank *= 2f;
            }

        }//��Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Earth)
        {
            if (pokemon.Type1 == PokemonStats.Type.Fire || pokemon.Type2 == PokemonStats.Type.Fire)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Grass || pokemon.Type2 == PokemonStats.Type.Grass)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Electricty || pokemon.Type2 == PokemonStats.Type.Electricty)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Poison || pokemon.Type2 == PokemonStats.Type.Poison)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Flight || pokemon.Type2 == PokemonStats.Type.Flight)
            {
                DamageRank *= 0f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Bug || pokemon.Type2 == PokemonStats.Type.Bug)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Rock || pokemon.Type2 == PokemonStats.Type.Rock)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 2f;
            }
        }//��Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Flight)
        {
            if (pokemon.Type1 == PokemonStats.Type.Grass || pokemon.Type2 == PokemonStats.Type.Grass)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Electricty || pokemon.Type2 == PokemonStats.Type.Electricty)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Fight || pokemon.Type2 == PokemonStats.Type.Fight)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Bug || pokemon.Type2 == PokemonStats.Type.Bug)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Rock || pokemon.Type2 == PokemonStats.Type.Rock)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 0.5f;
            }
        }//����Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Bug)
        {
            if (pokemon.Type1 == PokemonStats.Type.Fire || pokemon.Type2 == PokemonStats.Type.Fire)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Grass || pokemon.Type2 == PokemonStats.Type.Grass)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Fight || pokemon.Type2 == PokemonStats.Type.Fight)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Poison || pokemon.Type2 == PokemonStats.Type.Poison)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Flight || pokemon.Type2 == PokemonStats.Type.Flight)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Esper || pokemon.Type2 == PokemonStats.Type.Esper)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Ghost || pokemon.Type2 == PokemonStats.Type.Ghost)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Evil || pokemon.Type2 == PokemonStats.Type.Evil)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Fairy || pokemon.Type2 == PokemonStats.Type.Fairy)
            {
                DamageRank *= 0.5f;
            }
        }//����Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Rock)
        {
            if (pokemon.Type1 == PokemonStats.Type.Fire || pokemon.Type2 == PokemonStats.Type.Fire)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Ice || pokemon.Type2 == PokemonStats.Type.Ice)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Fight || pokemon.Type2 == PokemonStats.Type.Fight)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Earth || pokemon.Type2 == PokemonStats.Type.Earth)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Flight || pokemon.Type2 == PokemonStats.Type.Flight)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Bug || pokemon.Type2 == PokemonStats.Type.Bug)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 0.5f;
            }
        }//����Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Ghost)
        {
            if (pokemon.Type1 == PokemonStats.Type.Normal || pokemon.Type2 == PokemonStats.Type.Normal)
            {
                DamageRank *= 0f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Esper || pokemon.Type2 == PokemonStats.Type.Esper)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Ghost || pokemon.Type2 == PokemonStats.Type.Ghost)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Evil || pokemon.Type2 == PokemonStats.Type.Evil)
            {
                DamageRank *= 0.5f;
            }
        }//��ƮŸ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Steel)
        {
            if (pokemon.Type1 == PokemonStats.Type.Fire || pokemon.Type2 == PokemonStats.Type.Fire)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Water || pokemon.Type2 == PokemonStats.Type.Water)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Electricty || pokemon.Type2 == PokemonStats.Type.Electricty)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Ice || pokemon.Type2 == PokemonStats.Type.Ice)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Rock || pokemon.Type2 == PokemonStats.Type.Rock)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Fairy || pokemon.Type2 == PokemonStats.Type.Fairy)
            {
                DamageRank *= 2f;
            }
        }//��öŸ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Fire)
        {
            if (pokemon.Type1 == PokemonStats.Type.Fire || pokemon.Type2 == PokemonStats.Type.Fire)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Water || pokemon.Type2 == PokemonStats.Type.Water)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Grass || pokemon.Type2 == PokemonStats.Type.Grass)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Ice || pokemon.Type2 == PokemonStats.Type.Ice)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Bug || pokemon.Type2 == PokemonStats.Type.Bug)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Rock || pokemon.Type2 == PokemonStats.Type.Rock)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Dragon || pokemon.Type2 == PokemonStats.Type.Dragon)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 2f;
            }
        }//��Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Water)
        {
            if (pokemon.Type1 == PokemonStats.Type.Fire || pokemon.Type2 == PokemonStats.Type.Fire)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Water || pokemon.Type2 == PokemonStats.Type.Water)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Grass || pokemon.Type2 == PokemonStats.Type.Grass)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Earth || pokemon.Type2 == PokemonStats.Type.Earth)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Rock || pokemon.Type2 == PokemonStats.Type.Rock)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Dragon || pokemon.Type2 == PokemonStats.Type.Dragon)
            {
                DamageRank *= 0.5f;
            }
        }//��Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Electricty)
        {
            if (pokemon.Type1 == PokemonStats.Type.Water || pokemon.Type2 == PokemonStats.Type.Water)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Grass || pokemon.Type2 == PokemonStats.Type.Grass)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Electricty || pokemon.Type2 == PokemonStats.Type.Electricty)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Earth || pokemon.Type2 == PokemonStats.Type.Earth)
            {
                DamageRank *= 0f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Flight || pokemon.Type2 == PokemonStats.Type.Flight)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Dragon || pokemon.Type2 == PokemonStats.Type.Dragon)
            {
                DamageRank *= 0.5f;
            }
        }//����Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Grass)
        {
            if (pokemon.Type1 == PokemonStats.Type.Fire || pokemon.Type2 == PokemonStats.Type.Fire)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Water || pokemon.Type2 == PokemonStats.Type.Water)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Grass || pokemon.Type2 == PokemonStats.Type.Grass)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Poison || pokemon.Type2 == PokemonStats.Type.Poison)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Earth || pokemon.Type2 == PokemonStats.Type.Earth)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Flight || pokemon.Type2 == PokemonStats.Type.Flight)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Bug || pokemon.Type2 == PokemonStats.Type.Bug)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Rock || pokemon.Type2 == PokemonStats.Type.Rock)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Dragon || pokemon.Type2 == PokemonStats.Type.Dragon)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 0.5f;
            }
        }//ǮŸ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Ice)
        {
            if (pokemon.Type1 == PokemonStats.Type.Fire || pokemon.Type2 == PokemonStats.Type.Fire)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Water || pokemon.Type2 == PokemonStats.Type.Water)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Grass || pokemon.Type2 == PokemonStats.Type.Grass)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Ice || pokemon.Type2 == PokemonStats.Type.Ice)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Earth || pokemon.Type2 == PokemonStats.Type.Earth)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Flight || pokemon.Type2 == PokemonStats.Type.Flight)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Dragon || pokemon.Type2 == PokemonStats.Type.Dragon)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 0.5f;
            }
        }//����Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Esper)
        {
            if (pokemon.Type1 == PokemonStats.Type.Fight || pokemon.Type2 == PokemonStats.Type.Fight)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Poison || pokemon.Type2 == PokemonStats.Type.Poison)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Esper || pokemon.Type2 == PokemonStats.Type.Esper)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Evil || pokemon.Type2 == PokemonStats.Type.Evil)
            {
                DamageRank *= 0f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 0.5f;
            }
        }//������Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Dragon)
        {
            if (pokemon.Type1 == PokemonStats.Type.Dragon || pokemon.Type2 == PokemonStats.Type.Dragon)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Fairy || pokemon.Type2 == PokemonStats.Type.Fairy)
            {
                DamageRank *= 0f;
            }
        }//�巡��Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Evil)
        {
            if (pokemon.Type1 == PokemonStats.Type.Ice || pokemon.Type2 == PokemonStats.Type.Ice)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Esper || pokemon.Type2 == PokemonStats.Type.Esper)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Rock || pokemon.Type2 == PokemonStats.Type.Rock)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Dragon || pokemon.Type2 == PokemonStats.Type.Dragon)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Fairy || pokemon.Type2 == PokemonStats.Type.Fairy)
            {
                DamageRank *= 0.5f;
            }
        }//��Ÿ�� ��ũ ������ �Ǻ�
        if (skill.propertyType == SkillData.PropertyType.Fairy)
        {
            if (pokemon.Type1 == PokemonStats.Type.Fire || pokemon.Type2 == PokemonStats.Type.Fire)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Fight || pokemon.Type2 == PokemonStats.Type.Fight)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Poison || pokemon.Type2 == PokemonStats.Type.Poison)
            {
                DamageRank *= 0.5f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Dragon || pokemon.Type2 == PokemonStats.Type.Dragon)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Evil || pokemon.Type2 == PokemonStats.Type.Evil)
            {
                DamageRank *= 2f;
            }
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                DamageRank *= 0.5f;
            }
        }//��Ÿ�� ��ũ ������ �Ǻ�

    }
    public void CheckProPertyType(SkillData skill, PokemonStats pokemon)
    {
        if(skill.propertyType == (SkillData.PropertyType)pokemon.Type1 || skill.propertyType == (SkillData.PropertyType)pokemon.Type2)
        {
            PropertyRank *= 1.5f;
        }
        #region �ּ�(�ڼ�Ȯ��)
        /*
        if (skill.propertyType == SkillData.PropertyType.Normal)
        {
            if (pokemon.Type1 == PokemonStats.Type.Normal || pokemon.Type2 == PokemonStats.Type.Normal)
            {
                PropertyRank *= 1.5f;
            }
        }//�븻Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Fight)
        {
            if (pokemon.Type1 == PokemonStats.Type.Fight || pokemon.Type2 == PokemonStats.Type.Fight)
            {
                PropertyRank *= 1.5f;
            }
        } //����Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Poison)
        {
            if (pokemon.Type1 == PokemonStats.Type.Poison || pokemon.Type2 == PokemonStats.Type.Poison)
            {
                PropertyRank *= 1.5f;
            }
        }//��Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Earth)
        {
            if (pokemon.Type1 == PokemonStats.Type.Earth || pokemon.Type2 == PokemonStats.Type.Earth)
            {
                PropertyRank *= 1.5f;
            }
        }//��Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Flight)
        {
            if (pokemon.Type1 == PokemonStats.Type.Flight || pokemon.Type2 == PokemonStats.Type.Flight)
            {
                PropertyRank *= 1.5f;
            }
        }//����Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Bug)
        {
            if (pokemon.Type1 == PokemonStats.Type.Bug || pokemon.Type2 == PokemonStats.Type.Bug)
            {
                PropertyRank *= 1.5f;
            }
        } // ����Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Rock)
        {
            if (pokemon.Type1 == PokemonStats.Type.Rock || pokemon.Type2 == PokemonStats.Type.Rock)
            {
                PropertyRank *= 1.5f;
            }
        } //����Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Ghost)
        {
            if (pokemon.Type1 == PokemonStats.Type.Ghost || pokemon.Type2 == PokemonStats.Type.Ghost)
            {
                PropertyRank *= 1.5f;
            }
        }//��ƮŸ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Steel)
        {
            if (pokemon.Type1 == PokemonStats.Type.Steel || pokemon.Type2 == PokemonStats.Type.Steel)
            {
                PropertyRank *= 1.5f;
            }
        }//��öŸ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Fire)
        {
            if (pokemon.Type1 == PokemonStats.Type.Fire || pokemon.Type2 == PokemonStats.Type.Fire)
            {
                PropertyRank *= 1.5f;
            }
        }//��Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Water)
        {
            if (pokemon.Type1 == PokemonStats.Type.Water || pokemon.Type2 == PokemonStats.Type.Water)
            {
                PropertyRank *= 1.5f;
            }
        }//��Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Electricty)
        {
            if (pokemon.Type1 == PokemonStats.Type.Electricty || pokemon.Type2 == PokemonStats.Type.Electricty)
            {
                PropertyRank *= 1.5f;
            }
        }//����Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Grass)
        {
            if (pokemon.Type1 == PokemonStats.Type.Grass || pokemon.Type2 == PokemonStats.Type.Grass)
            {
                PropertyRank *= 1.5f;
            }
        }//ǮŸ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Ice)
        {
            if (pokemon.Type1 == PokemonStats.Type.Ice || pokemon.Type2 == PokemonStats.Type.Ice)
            {
                PropertyRank *= 1.5f;
            }
        }//����Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Esper)
        {
            if (pokemon.Type1 == PokemonStats.Type.Esper || pokemon.Type2 == PokemonStats.Type.Esper)
            {
                PropertyRank *= 1.5f;
            }
        }//������Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Dragon)
        {
            if (pokemon.Type1 == PokemonStats.Type.Dragon || pokemon.Type2 == PokemonStats.Type.Dragon)
            {
                PropertyRank *= 1.5f;
            }
        }//�巡��Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Evil)
        {
            if (pokemon.Type1 == PokemonStats.Type.Evil || pokemon.Type2 == PokemonStats.Type.Evil)
            {
                PropertyRank *= 1.5f;
            }
        }//��Ÿ�� �ڼ�Ȯ��
        if (skill.propertyType == SkillData.PropertyType.Fairy)
        {
            if (pokemon.Type1 == PokemonStats.Type.Fairy || pokemon.Type2 == PokemonStats.Type.Fairy)
            {
                PropertyRank *= 1.5f;
            }
        }//��Ÿ�� �ڼ�Ȯ��
        */
        #endregion
    }
    public void CheckStateRank(PokemonStats attacker, PokemonStats target)
    {
        switch (attacker.AttackRank)
        {
            case 6:
                {
                    AttackerAttackRank = 4f;
                }
                break;
            case 5:
                {
                    AttackerAttackRank = 3.5f;
                }
                break;
            case 4:
                {
                    AttackerAttackRank = 3f;
                }
                break;
            case 3:
                {
                    AttackerAttackRank = 2.5f;
                }
                break;
            case 2:
                {
                    AttackerAttackRank = 2f;
                }
                break;
            case 1:
                {
                    AttackerAttackRank = 1.5f;
                }
                break;
            case -1:
                {
                    AttackerAttackRank = 0.66f;
                }
                break;
            case -2:
                {
                    AttackerAttackRank = 0.5f;
                }
                break;
            case -3:
                {
                    AttackerAttackRank = 0.4f;
                }
                break;
            case -4:
                {
                    AttackerAttackRank = 0.33f;
                }
                break;
            case -5:
                {
                    AttackerAttackRank = 0.29f;
                }
                break;
            case -6:
                {
                    AttackerAttackRank = 0.25f;
                }
                break;

        }//���� ��ũ�� Ȯ��
        switch (attacker.SpAttackRank)
        {
            case 6:
                {
                    AttackerSpAttackRank = 4f;
                }
                break;
            case 5:
                {
                    AttackerSpAttackRank = 3.5f;
                }
                break;
            case 4:
                {
                    AttackerSpAttackRank = 3f;
                }
                break;
            case 3:
                {
                    AttackerSpAttackRank = 2.5f;
                }
                break;
            case 2:
                {
                    AttackerSpAttackRank = 2f;
                }
                break;
            case 1:
                {
                    AttackerSpAttackRank = 1.5f;
                }
                break;
            case -1:
                {
                    AttackerSpAttackRank = 0.66f;
                }
                break;
            case -2:
                {
                    AttackerSpAttackRank = 0.5f;
                }
                break;
            case -3:
                {
                    AttackerSpAttackRank = 0.4f;
                }
                break;
            case -4:
                {
                    AttackerSpAttackRank = 0.33f;
                }
                break;
            case -5:
                {
                    AttackerSpAttackRank = 0.29f;
                }
                break;
            case -6:
                {
                    AttackerSpAttackRank = 0.25f;
                }
                break;

        }//Ư������ ��ũ�� Ȯ��
        switch (target.DefenceRank)
        {
            case 6:
                {
                    TargetDefenceRank = 4f;
                }
                break;
            case 5:
                {
                    TargetDefenceRank = 3.5f;
                }
                break;
            case 4:
                {
                    TargetDefenceRank = 3f;
                }
                break;
            case 3:
                {
                    TargetDefenceRank = 2.5f;
                }
                break;
            case 2:
                {
                    TargetDefenceRank = 2f;
                }
                break;
            case 1:
                {
                    TargetDefenceRank = 1.5f;
                }
                break;
            case -1:
                {
                    TargetDefenceRank = 0.66f;
                }
                break;
            case -2:
                {
                    TargetDefenceRank = 0.5f;
                }
                break;
            case -3:
                {
                    TargetDefenceRank = 0.4f;
                }
                break;
            case -4:
                {
                    TargetDefenceRank = 0.33f;
                }
                break;
            case -5:
                {
                    TargetDefenceRank = 0.29f;
                }
                break;
            case -6:
                {
                    TargetDefenceRank = 0.25f;
                }
                break;

        } // Ÿ�� ��� ��ũ�ٿ� Ȯ��
        switch (target.SpDefenceRank)
        {
            case 6:
                {
                    TargetSpDefenceRank = 4f;
                }
                break;
            case 5:
                {
                    TargetSpDefenceRank = 3.5f;
                }
                break;
            case 4:
                {
                    TargetSpDefenceRank = 3f;
                }
                break;
            case 3:
                {
                    TargetSpDefenceRank = 2.5f;
                }
                break;
            case 2:
                {
                    TargetSpDefenceRank = 2f;
                }
                break;
            case 1:
                {
                    TargetSpDefenceRank = 1.5f;
                }
                break;
            case -1:
                {
                    TargetSpDefenceRank = 0.66f;
                }
                break;
            case -2:
                {
                    TargetSpDefenceRank = 0.5f;
                }
                break;
            case -3:
                {
                    TargetSpDefenceRank = 0.4f;
                }
                break;
            case -4:
                {
                    TargetSpDefenceRank = 0.33f;
                }
                break;
            case -5:
                {
                    TargetSpDefenceRank = 0.29f;
                }
                break;
            case -6:
                {
                    TargetSpDefenceRank = 0.25f;
                }
                break;

        } // Ÿ�� Ư����� ��ũ�ٿ� Ȯ��

        #region �ӵ����ϴ°� ���⼭ �ϴ����𸣰��� todo ��μ�
        /*
        switch (attacker.SpeedRank)
        {
            case 6:
                {
                    AttackerSpeedRank = 4f;
                }
                break;
            case 5:
                {
                    AttackerSpeedRank = 3.5f;
                }
                break;
            case 4:
                {
                    AttackerSpeedRank = 3f;
                }
                break;
            case 3:
                {
                    AttackerSpeedRank = 2.5f;
                }
                break;
            case 2:
                {
                    AttackerSpeedRank = 2f;
                }
                break;
            case 1:
                {
                    AttackerSpeedRank = 1.5f;
                }
                break;
            case -1:
                {
                    AttackerSpeedRank = 0.66f;
                }
                break;
            case -2:
                {
                    AttackerSpeedRank = 0.5f;
                }
                break;
            case -3:
                {
                    AttackerSpeedRank = 0.4f;
                }
                break;
            case -4:
                {
                    AttackerSpeedRank = 0.33f;
                }
                break;
            case -5:
                {
                    AttackerSpeedRank = 0.29f;
                }
                break;
            case -6:
                {
                    AttackerSpeedRank = 0.25f;
                }
                break;

        } // ������ ���ǵ� ��ũ�ٿ� Ȯ��
        switch (target.SpeedRank)
        {
            case 6:
                {
                    TargetSpeedRank = 4f;
                }
                break;
            case 5:
                {
                    TargetSpeedRank = 3.5f;
                }
                break;
            case 4:
                {
                    TargetSpeedRank = 3f;
                }
                break;
            case 3:
                {
                    TargetSpeedRank = 2.5f;
                }
                break;
            case 2:
                {
                    TargetSpeedRank = 2f;
                }
                break;
            case 1:
                {
                    TargetSpeedRank = 1.5f;
                }
                break;
            case -1:
                {
                    TargetSpeedRank = 0.66f;
                }
                break;
            case -2:
                {
                    TargetSpeedRank = 0.5f;
                }
                break;
            case -3:
                {
                    TargetSpeedRank = 0.4f;
                }
                break;
            case -4:
                {
                    TargetSpeedRank = 0.33f;
                }
                break;
            case -5:
                {
                    TargetSpeedRank = 0.29f;
                }
                break;
            case -6:
                {
                    TargetSpeedRank = 0.25f;
                }
                break;

        } // Ÿ�� ���ǵ� ��ũ�ٿ� Ȯ��
        */


        #endregion
    }
}
