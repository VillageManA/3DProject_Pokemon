using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public bool isRobby;
    public bool isFight;
    public bool isItem;
    public bool isPokemon;

    PokemonStats PlayerPokemon;
    PokemonStats EnemyPokemon;
    BattleManager BattleManager;

    [Header("UI 오브젝트")]
    [Header("플레이어")]
    [SerializeField] GameObject PlayerUI_obj;
    [SerializeField] Text Player_Name;
    [SerializeField] Text Player_Level;
    [SerializeField] Text Player_Hp;

    [Header("Enemy")]
    [SerializeField] GameObject EnemyUI_obj;
    [SerializeField] Text Enemy_Name;
    [SerializeField] Text Enemy_Level;
    [SerializeField] Text Enemy_Hp;

    [Header("로비 관련 오브젝트")]
    [SerializeField] GameObject Robby_obj;
    [SerializeField] GameObject Robby_Cursor;
    [SerializeField] Image[] Robby_BackGround;
    [SerializeField] Text[] Robby_Txt;

    [Header("플레이어 스킬")]
    [SerializeField] GameObject[] PlayerSkill_obj;
    [SerializeField] GameObject PlayerSkill_Cursor;
    [SerializeField] Text[] SkillName_txt;
    [SerializeField] Text[] SkillPP_Txt;
    [SerializeField] Image[] SkillType_Image;
    [SerializeField] Image[] SkillBackGround_Image;
    [SerializeField] Sprite[] SkillTypeSprite;
    Color[] SkillTypeColor;

    public int Skill_Num;

    private void Awake()
    {
        BattleManager = FindObjectOfType<BattleManager>();
        SetSkillTypeColor();
        FindPokemon();
        UpdateStatsUI();
        UpdateSkillUI();
    }
    public void UpdateRobbyUI()
    {

    }
    public void UpdateStatsUI()
    {
        Player_Name.text = PlayerPokemon.Name;
        Player_Level.text = string.Format("{0}", PlayerPokemon.Level);
        Player_Hp.text = string.Format("{0} / {1}", PlayerPokemon.Hp, PlayerPokemon.MaxHp);

        Enemy_Name.text = EnemyPokemon.Name;
        Enemy_Level.text = string.Format("{0}", EnemyPokemon.Level);
        Enemy_Hp.text = string.Format("{0} / {1}", EnemyPokemon.Hp, EnemyPokemon.MaxHp);
    }
    public void UpdateSkillUI()
    {
        for (int i = 0; i < SkillPP_Txt.Length; i++)
        {
            SkillPP_Txt[i].text = string.Format("{0} / {1}", PlayerPokemon.skills[i].PP, PlayerPokemon.skills[i].MaxPP);
            SkillType_Image[i].sprite = SkillTypeSprite[(int)PlayerPokemon.skills[i].propertyType];
            SkillBackGround_Image[i].color = SkillTypeColor[i];

        }
    }
    public void FindPokemon()
    {
        GameObject Enemy = GameObject.FindGameObjectWithTag("Pokemon");
        EnemyPokemon = Enemy.GetComponent<PokemonStats>();
        GameObject Player = GameObject.FindGameObjectWithTag("PlayerPokemon");
        PlayerPokemon = Player.GetComponent<PokemonStats>();
    }
    public void SetSkillTypeColor()
    {
        SkillTypeColor[0] = new Color(223 / 255f, 223 / 255f, 223 / 255f);
        SkillTypeColor[1] = new Color(208 / 255f, 86 / 255f, 140 / 255f);
        SkillTypeColor[2] = new Color(167 / 255f, 104 / 255f, 193 / 255f);
        SkillTypeColor[3] = new Color(206 / 255f, 122 / 255f, 86 / 255f);
        SkillTypeColor[4] = new Color(129 / 255f, 159 / 255f, 200 / 255f);
        SkillTypeColor[5] = new Color(155 / 255f, 208 / 255f, 70 / 255f);
        SkillTypeColor[6] = new Color(185 / 255f, 173 / 255f, 132 / 255f);
        SkillTypeColor[7] = new Color(129 / 255f, 223 / 255f, 119 / 255f);
        SkillTypeColor[8] = new Color(100 / 255f, 142 / 255f, 153 / 255f);
        SkillTypeColor[9] = new Color(211 / 255f, 130 / 255f, 77 / 255f);
        SkillTypeColor[10] = new Color(108 / 255f, 168 / 255f, 227 / 255f);
        SkillTypeColor[11] = new Color(228 / 255f, 210 / 255f, 65 / 255f);
        SkillTypeColor[12] = new Color(112 / 255f, 188 / 255f, 108 / 255f);
        SkillTypeColor[13] = new Color(124 / 255f, 204 / 255f, 182 / 255f);
        SkillTypeColor[14] = new Color(176 / 255f, 91 / 255f, 105 / 255f);
        SkillTypeColor[15] = new Color(80 / 255f, 152 / 255f, 204 / 255f);
        SkillTypeColor[16] = new Color(115 / 255f, 98 / 255f, 154 / 255f);
        SkillTypeColor[17] = new Color(199 / 255f, 110 / 255f, 197 / 255f);
        SkillTypeColor[18] = new Color(223 / 255f, 223 / 255f, 223 / 255f);
    }

}
