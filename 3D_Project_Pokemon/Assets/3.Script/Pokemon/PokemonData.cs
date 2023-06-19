using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PokemonData : MonoBehaviour
{
    private int hp;
    public int Hp
    {
        get { return hp; }
        set
        {
            Hp = value;
        }
    }

    [SerializeField] private int MaxHp;
    [SerializeField] private int Attack;
    [SerializeField] private int SpAttack;
    [SerializeField] private int Defence;
    [SerializeField] private int SpDefence;
    [SerializeField] private int Speed;

    public int AttackRank = 0;
    public int SpAttackRank = 0;
    public int DefenceRank = 0;
    public int SpDefenceRank = 0;
    public int SpeedRank = 0;
    public int HitrateRank = 0;
    

}
