using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class PokemonStats : MonoBehaviour
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

    //°´Ã¼º° °³Ã¼°ª
    [SerializeField] private string Name;
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

    //½ºÅÝ ·©Å©¾÷,´Ù¿î
    public float AttackRank = 0;
    public float SpAttackRank = 0;
    public float DefenceRank = 0;
    public float SpDefenceRank = 0;
    public float SpeedRank = 0;
    public float HitrateRank = 0;

    //·¹º§¾÷ ·£´ý °è¼ö
    private int LevelUpHp = 0;
    private int LevelUpAttack = 0;
    private int LevelUpDefence = 0;
    private int LevelUpSpAttack = 0;
    private int LevelUpSpDefence = 0;
    private int LevelUpSpeed = 0;
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
