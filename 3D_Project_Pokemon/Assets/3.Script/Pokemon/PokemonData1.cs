using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class PokemonData1 : MonoBehaviour
{
    System.Random random = new System.Random();
    private int hp;
    public int Hp
    {
        get { return hp; }
        set
        {
            Hp = value;
        }
    }

    //��ü�� ��ü��
    [SerializeField] private int MaxHp;
    [SerializeField] private int Attack;
    [SerializeField] private int Defence;
    [SerializeField] private int SpAttack;
    [SerializeField] private int SpDefence;
    [SerializeField] private int Speed;
    [SerializeField] private Type Type1;
    [SerializeField] private Type Type2;
    private enum Type
    {
        Normal, Fight, Poison, Earth, Flight, Bug, Rock, Ghost, Steel, Fire, Water, Electricty, Grass, Ice, Esper, Dragon, Evil, Fairy, None
    }

    //���� ��ũ��,�ٿ�
    public float AttackRank = 0;
    public float SpAttackRank = 0;
    public float DefenceRank = 0;
    public float SpDefenceRank = 0;
    public float SpeedRank = 0;
    public float HitrateRank = 0;
    
    //������ ���� ���
    private int LevelUpHp;
    private int LevelUpAttack;
    private int LevelUpDefence;
    private int LevelUpSpAttack;
    private int LevelUpSpDefence;
    private int LevelUpSpeed;
    public void LevelUp()
    {
        LevelUpHp += random.Next(1, 3);
        LevelUpAttack += random.Next(1, 3);
        LevelUpDefence += random.Next(1, 3);
        LevelUpSpAttack += random.Next(1, 3);
        LevelUpSpDefence += random.Next(1, 3);
        LevelUpSpeed += random.Next(1, 3);
    }
   

}
