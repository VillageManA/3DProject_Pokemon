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
            hp = value;
        }
    }

    //��ü�� ��ü��
    [SerializeField] public string Name;
    [SerializeField] public int MaxHp;
    [SerializeField] public int Attack;
    [SerializeField] public int Defence;
    [SerializeField] public int SpAttack;
    [SerializeField] public int SpDefence;
    [SerializeField] public int Speed;
    [SerializeField] public int Level;
    [SerializeField] public int Exp;
    [SerializeField] public Type Type1;
    [SerializeField] public Type Type2;
    public enum Type
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

    //��ų��
    public List<SkillData> skills = new List<SkillData>();

    public void AddSkill(SkillData skill)
    {
        skills.Add(skill);
    }
    public void RemoveSkill(int count)
    {
        skills.RemoveAt(count);
    }

    string jsonFileName = "DataBase/Pokemon";
    PokemonData[] pokemonArray;
    protected virtual void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(jsonFileName);
        pokemonArray = JsonMapper.ToObject<PokemonData[]>(jsonFile.text);    
    }

    protected PokemonData[] GetPokemonArray()
    {
        return pokemonArray;
    }
}
public class PokemonData
{
    public string Name;
    public int Num;
    public int MaxHp;
    public int Hp;
    public int Attack;
    public int Defence;
    public int SpAttack;
    public int SpDefence;
    public int Speed;
    public int Type1;
    public int Type2;
}

