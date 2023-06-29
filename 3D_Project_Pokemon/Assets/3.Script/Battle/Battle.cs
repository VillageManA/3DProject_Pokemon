using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public bool isRobby;
    public bool isFight;
    public bool isItem;
    public bool isPokemon;
    public bool isAttack;

    PokemonStats PlayerPokemon;
    PokemonStats EnemyPokemon;
    BattleManager BattleManager;

    [Header("UI 오브젝트")]
    [Header("플레이어")]
    [SerializeField] GameObject PlayerUI_obj;
    [SerializeField] Text Player_Name;
    [SerializeField] Text Player_Level;
    [SerializeField] Text Player_Hp;
    [SerializeField] Slider Player_Hpbar;

    [Header("Enemy")]
    [SerializeField] GameObject EnemyUI_obj;
    [SerializeField] Text Enemy_Name;
    [SerializeField] Text Enemy_Level;
    [SerializeField] Text Enemy_Hp;
    [SerializeField] Slider Enemy_Hpbar;

    [Header("로비 관련 오브젝트")]
    [SerializeField] GameObject Robby_obj;
    [SerializeField] GameObject Robby_Cursor;
    [SerializeField] Image[] Robby_BackGround;
    [SerializeField] Text[] Robby_Txt;

    [Header("플레이어 스킬/전투 관련")]
    [SerializeField] GameObject PlayerSkill_obj;
    [SerializeField] GameObject PlayerSkill_Cursor;
    [SerializeField] Text[] SkillName_txt;
    [SerializeField] Text[] SkillPP_Txt;
    [SerializeField] Image[] SkillType_Image;
    [SerializeField] Image[] SkillBackGround_Image;
    [SerializeField] Sprite[] SkillTypeSprite;

    [Header("효과 문구")]
    [SerializeField] GameObject Effect_obj;
    [SerializeField] Text Effect_Txt;



    [Header("게임관련 변수들")]

    //로비 관련 변수
    public int Robby_Num;
    private Vector3 Default_Robby_Cursor;
    private Vector3 Move_Robby_Cursor;

    //전투 스킬 관련 변수
    public int Fight_Num;
    private int Enemy_Num;
    Color[] SkillTypeColor;
    private Vector3 Default_Fight_Cursor;
    private Vector3 Move_Fight_Cursor;

    //가방 관련 변수
    public int Item_Num;
    private Vector3 Default_Item_Cursor;
    private Vector3 Move_Item_Cursor;

    //포켓몬 관련 변수
    public int PokemonUI_Num;
    private Vector3 Default_Pokemon_Cursor;
    private Vector3 Move_Pokemon_Cursor;

    private void Awake()
    {
        BattleManager = FindObjectOfType<BattleManager>();
        SetSkillTypeColor();
        FindPokemon();
        UpdateStatsUI();
        UpdateSkillUI();
    }
    #region StatsUI 관련 메서드
    public void UpdateStatsUI() // 위아래 플레이어,상대 포켓몬 상태창 UI 업데이트
    {
        UpdatePlayerStatsUI();
        UpdateEnemyStatsUI();
    }
    public void UpdatePlayerStatsUI() //플레이어 상태창 UI 업데이트
    {
        Player_Name.text = PlayerPokemon.Name;
        Player_Level.text = string.Format("{0}", PlayerPokemon.Level);
        Player_Hp.text = string.Format("{0} / {1}", PlayerPokemon.Hp, PlayerPokemon.MaxHp);
        Player_Hpbar.value = PlayerPokemon.Hp / PlayerPokemon.MaxHp;
    }
    public void UpdateEnemyStatsUI() // 상대 포켓몬 상태창 UI 업데이트
    {
        Enemy_Name.text = EnemyPokemon.Name;
        Enemy_Level.text = string.Format("{0}", EnemyPokemon.Level);
        Enemy_Hp.text = string.Format("{0} / {1}", EnemyPokemon.Hp, EnemyPokemon.MaxHp);
        Enemy_Hpbar.value = EnemyPokemon.Hp / EnemyPokemon.MaxHp;
    }
    #endregion
    #region Robby 관련 메서드
    public void UpdateRobbyUI() //로비 4칸 창 UI 업데이트
    {
        for (int i = 0; i < 4; i++)
        {
            Robby_BackGround[i].color = Color.white;
            Robby_Txt[i].color = Color.black;
        }
        Robby_BackGround[Robby_Num].color = Color.black;
        Robby_Txt[Robby_Num].color = Color.white;
    }
    public void RobbyUpKey()
    {
        Robby_Cursor.transform.position += Move_Robby_Cursor;
        Robby_Num++;
        UpdateRobbyUI();
    }
    public void RobbyDownKey()
    {
        Robby_Cursor.transform.position -= Move_Robby_Cursor;
        Robby_Num--;
        UpdateRobbyUI();
    }
    public void RobbyEneterKey()
    {
        switch (Robby_Num)
        {
            case 0:
                {
                    isRobby = false;
                    isFight = true;
                    Robby_obj.SetActive(false);
                    PlayerSkill_obj.SetActive(true);
                }
                break;
            case 1:
                {
                    isRobby = false;
                    isPokemon = true;

                }
                break;
            case 2:
                {
                    isRobby = false;
                    isItem = true;
                }
                break;
            case 3:
                {
                    isRobby = false;
                    //확률로 배틀 런
                }
                break;
        }
    }
    #endregion

    #region Fight 관련 메서드
    public void UpdateSkillUI() // 플레이어의 스킬4칸창 UI 업데이트
    {
        for (int i = 0; i < SkillPP_Txt.Length; i++)
        {
            SkillPP_Txt[i].text = string.Format("{0} / {1}", PlayerPokemon.skills[i].PP, PlayerPokemon.skills[i].MaxPP);
            SkillType_Image[i].sprite = SkillTypeSprite[(int)PlayerPokemon.skills[i].propertyType];
            SkillBackGround_Image[i].color = SkillTypeColor[i];

        }
    }
    public void FightUpKey()
    {
        PlayerSkill_Cursor.transform.position += Move_Fight_Cursor;
        Fight_Num++;
        UpdateSkillUI();
    }
    public void FightDownKey()
    {
        PlayerSkill_Cursor.transform.position -= Move_Fight_Cursor;
        Fight_Num--;
        UpdateSkillUI();
    }
    public void FightEnterKey()
    {
        Enemy_Num = Random.Range(0, 4);
        //공격칸 구현

        if (PlayerPokemon.Speed > EnemyPokemon.Speed) // 내가 속도가 빠르다면
        {
            Attack(PlayerPokemon, EnemyPokemon, Fight_Num);
            Attack(EnemyPokemon, PlayerPokemon, Enemy_Num);

        }
        else if (PlayerPokemon.Speed < EnemyPokemon.Speed) //상대가 속도가 빠르다면
        {
            Attack(EnemyPokemon, PlayerPokemon, Enemy_Num);

            Attack(PlayerPokemon, EnemyPokemon, Fight_Num);
        }
        else if (PlayerPokemon.Speed == EnemyPokemon.Speed) //동속시 랜덤
        {
            int ran = Random.Range(0, 1);
            switch (ran)
            {
                case 0:
                    {
                        Attack(PlayerPokemon, EnemyPokemon, Fight_Num);

                        Attack(EnemyPokemon, PlayerPokemon, Enemy_Num);
                    }
                    break;
                case 1:
                    {
                        Attack(EnemyPokemon, PlayerPokemon, Enemy_Num);
                        Attack(PlayerPokemon, EnemyPokemon, Fight_Num);
                    }
                    break;
            }
        }
    }
    public void Attack(PokemonStats Attacker, PokemonStats Target, int Num)
    {  
        //플레이어
        BattleManager.OnDamage(Attacker.skills[Num], Attacker, Target);
        Attacker.GetComponent<Animator>().SetTrigger($"Attack{Num}");
        Target.GetComponent<Animator>().SetTrigger("Be_Attacked");
        UpdateStatsUI();

    }

    public void FightExitKey()
    {
        isFight = false;
        isRobby = true;
        PlayerSkill_obj.SetActive(false);
        Robby_obj.SetActive(true);
    }
    #endregion
    public void FindPokemon()
    {
        GameObject Enemy = GameObject.FindGameObjectWithTag("Pokemon");
        EnemyPokemon = Enemy.GetComponent<PokemonStats>();
        GameObject Player = GameObject.FindGameObjectWithTag("PlayerPokemon");
        PlayerPokemon = Player.GetComponent<PokemonStats>();
    }
    public void SetSkillTypeColor()
    {
        //스킬타입에 따른 컬러
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
