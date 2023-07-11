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

    //객체별 개체값
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
<<<<<<< Updated upstream
=======
    [SerializeField] public int[] SkillPP = new int[4];
    [SerializeField] public bool isAlive = true;
    [SerializeField] public Sprite Icon;
    [SerializeField] public Sprite Image;
    [SerializeField] public GameObject obj;

    [HideInInspector] public int defalut_MaxHp;
    [HideInInspector] public int defalut_Attack;
    [HideInInspector] public int defalut_Defence;
    [HideInInspector] public int defalut_SpAttack;
    [HideInInspector] public int defalut_SpDefence;
    [HideInInspector] public int defalut_Speed;
    private int[] required_Exp;
>>>>>>> Stashed changes
    public enum Type
    {
        Normal, Fight, Poison, Earth, Flight, Bug, Rock, Ghost, Steel, Fire, Water, Electricty, Grass, Ice, Esper, Dragon, Evil, Fairy, None
    }

    //스텟 랭크업,다운
    [HideInInspector] public float AttackRank = 0;
    [HideInInspector] public float SpAttackRank = 0;
    [HideInInspector] public float DefenceRank = 0;
    [HideInInspector] public float SpDefenceRank = 0;
    [HideInInspector] public float SpeedRank = 0;
    [HideInInspector] public float HitrateRank = 0;
    //레벨업 랜덤 계수
    private int LevelUpHp = 0;
    private int LevelUpAttack = 0;
    private int LevelUpDefence = 0;
    private int LevelUpSpAttack = 0;
    private int LevelUpSpDefence = 0;
    private int LevelUpSpeed = 0;
    public void LevelUp()
    {
<<<<<<< Updated upstream
        LevelUpHp += random.Next(1, 3);
        LevelUpAttack += random.Next(1, 3);
        LevelUpDefence += random.Next(1, 3);
        LevelUpSpAttack += random.Next(1, 3);
        LevelUpSpDefence += random.Next(1, 3);
        LevelUpSpeed += random.Next(1, 3);
=======
        MaxHp = defalut_MaxHp + (Level * LevelUpHp);
        Attack = defalut_Attack + (Level * LevelUpAttack);
        Defence = defalut_Defence + (Level * LevelUpDefence);
        SpAttack = defalut_SpAttack + (Level * LevelUpSpAttack);
        SpDefence = defalut_SpDefence + (Level * LevelUpSpDefence);
        Speed = defalut_Speed + (Level * LevelUpSpeed);
    }
    public void CheckLevelUp()
    {
        while (Exp > required_Exp[Level])
        {
            Exp -= required_Exp[Level];
            Level++;
            hp += 2;
        }
>>>>>>> Stashed changes
    }

    //스킬들
    public List<SkillData> skills = new List<SkillData>();

    public void AddSkill(SkillData skill)
    {
        skills.Add(skill);
    }
    public void RemoveSkill(int count)
    {
        skills.RemoveAt(count);
    }
    public void ClearSkill()
    {
        skills.Clear();
    }
    string jsonFileName = "DataBase/Pokemon";
    PokemonData[] pokemonArray;
    protected virtual void Awake()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(jsonFileName);
        pokemonArray = JsonMapper.ToObject<PokemonData[]>(jsonFile.text);
<<<<<<< Updated upstream
=======
        required_Exp = new int[100];
        for (int i = 0; i < 100; i++)
        {
            required_Exp[i] = 50 * i;
        }
>>>>>>> Stashed changes
    }

    public PokemonData[] GetPokemonArray()
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
    public int Exp;
    public int Level;
    public int Attack;
    public int Defence;
    public int SpAttack;
    public int SpDefence;
    public int Speed;
    public int Type1;
    public int Type2;
    public int Skill1;
    public int Skill2;
    public int Skill3;
    public int Skill4;
    public GameObject obj;
}

