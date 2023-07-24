using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

[System.Serializable]
public class PokemonStats : MonoBehaviour
{
    [SerializeField] private int hp;
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
    [SerializeField] public int[] SkillPP = new int[4];
    [SerializeField] public bool isAlive = true;
    [SerializeField] public Sprite Icon;
    [SerializeField] public Sprite Image;

    [SerializeReference] public int defalut_MaxHp;
    [SerializeReference] public int defalut_Attack;
    [SerializeReference] public int defalut_Defence;
    [SerializeReference] public int defalut_SpAttack;
    [SerializeReference] public int defalut_SpDefence;
    [SerializeReference] public int defalut_Speed;
    public int[] required_Exp;
    public enum Type
    {
        Normal, Fight, Poison, Earth, Flight, Bug, Rock, Ghost, Steel, Fire, Water, Electricty, Grass, Ice, Esper, Dragon, Evil, Fairy, None
    }

    //스텟 랭크업,다운
    public float AttackRank = 0;
    public float SpAttackRank = 0;
    public float DefenceRank = 0;
    public float SpDefenceRank = 0;
    public float SpeedRank = 0;
    public float HitrateRank = 0;
    //레벨업 랜덤 계수
    private int LevelUpHp = 2;
    private int LevelUpAttack = 2;
    private int LevelUpDefence = 1;
    private int LevelUpSpAttack = 2;
    private int LevelUpSpDefence = 1;
    private int LevelUpSpeed = 1;
    public void Setting_LevelStats()
    {
        MaxHp = defalut_MaxHp + (Level * LevelUpHp);
        Attack = defalut_Attack + (Level * LevelUpAttack);
        Defence = defalut_Defence + (Level * LevelUpDefence);
        SpAttack = defalut_SpAttack + (Level * LevelUpSpAttack);
        SpDefence = defalut_SpDefence + (Level * LevelUpSpDefence);
        Speed = defalut_Speed + (Level * LevelUpSpeed);
    }
    public void CheckLevelUp()
    {
        while(Exp > required_Exp[Level])
        {
            AudioManager.Instance.PlaySfx(Define.SFX.LevelUp);
            Exp -= required_Exp[Level];
            Level++;
            hp += 2;
        }
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
        required_Exp= new int[100];
        for(int i =0; i<100; i++)
        {
            required_Exp[i] = 50 * i;
        }
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
    public bool isAlive;
}

