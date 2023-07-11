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
    [SerializeField] Slider Enemy_Hpbar;

    [Header("로비 관련 오브젝트")]
    [SerializeField] GameObject Robby_obj;
    [SerializeField] GameObject Robby_Cursor;
    [SerializeField] Image[] Robby_BackGround;
    [SerializeField] Text[] Robby_Txt;

    [Header("플레이어 스킬/전투 관련")]
    [SerializeField] GameObject PlayerSkill_obj;
    [SerializeField] GameObject PlayerSkill_Cursor;
    [SerializeField] Text[] Skill_Name_txt;
    [SerializeField] Text[] Skill_PP_Txt;
    [SerializeField] Image[] Skill_Type_Image;
    [SerializeField] Image[] Skill_BackGround_Image;
    [SerializeField] Sprite[] Skill_Type_Sprite;

    [Header("효과 문구")]
    [SerializeField] GameObject Effect_obj;
    [SerializeField] Text Effect_Txt;



    [Header("게임관련 변수들")]

    //로비 관련 변수
    public int Robby_Num;
    private Vector3 Default_Robby_Cursor = new Vector3(350, -65, 0);
    private Vector3 Move_Robby_Cursor = new Vector3(0, 120, 0);

    //전투 스킬 관련 변수
    public int Fight_Num;
    private int Enemy_Num;
    Color[] Skill_Type_Color = new Color[19];
    Color[] Skill_Icon_Color = new Color[19];
    private Vector3 Default_Fight_Cursor = new Vector3(-300, 480, 0);
    private Vector3 Move_Fight_Cursor = new Vector3(0, 120, 0);

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
<<<<<<< Updated upstream
        BattleManager = FindObjectOfType<BattleManager>();
        SetSkillTypeColor();
        FindPokemon();
        UpdateStatsUI();
        UpdateSkillUI();
        Player_Hpbar.value = PlayerPokemon.MaxHp;
        Enemy_Hpbar.value = EnemyPokemon.MaxHp;
=======
        PlayerControl.Instance.gameObject.SetActive(false);
        battleManager = FindObjectOfType<BattleManager>();
        playerData = FindObjectOfType<PlayerData>();
        SetSkillTypeColor();
    }
    private void Update()
    {
        if (isRobby)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                RobbyUpKey();

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                RobbyDownKey();
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                RobbyEneterKey();
                return;
            }
        } //로비에서 입력
        if (isFight)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                FightUpKey();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                FightDownKey();
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                if (PlayerPokemon.skills[Fight_Num].PP == 0)
                {
                    Text_Play("PP가 부족하여 스킬을 사용하실 수 없습니다.", 0.4f);
                    return;
                }
                FightEnterKey();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                FightExitKey();
            }
        } // 파이트 상태일때 입력
        if (isItem)
        {

        } //가방상태일때 입력
        if (isPokemon)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                PokemonUpKey();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PokemonDownKey();
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                PokemonEnterKey();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PokemonExitKey();
            }
        } //포켓몬 교체시 입력
>>>>>>> Stashed changes
    }
    #region StatsUI 관련 메서드
    public void UpdateStatsUI() // 위아래 플레이어,상대 포켓몬 상태창 UI 업데이트
    {
        UpdatePlayerStatsUI();
        UpdateEnemyStatsUI();
        UpdateHpBar(PlayerPokemon, Player_Hpbar);
        UpdateHpBar(EnemyPokemon, Enemy_Hpbar);
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
        Enemy_Hpbar.value = EnemyPokemon.Hp / EnemyPokemon.MaxHp;
    }
    public void UpdateHpBar(PokemonStats Target, Slider Target_Slider) //자연스럽게 Hpbar를 내리기위한 메서드
    {
        float targetHp_Value = Target.Hp;
        float durationTime = 1f;

        StartCoroutine(HpUpdate_Co(targetHp_Value, durationTime, Target_Slider));
    }
    private IEnumerator HpUpdate_Co(float targetHp_Value, float durationTime, Slider Target) //자연스럽게 HPbar를 내리기위한 코루틴
    {
        float elapsedTime = 0f;
        float startHpValue = Target.value;
        while (elapsedTime < durationTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / durationTime);
            float smoothedValue = Mathf.Lerp(startHpValue, targetHp_Value, t);
            Target.value = smoothedValue;
            yield return null;

        }
        Target.value = targetHp_Value;
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
        for (int i = 0; i < Skill_PP_Txt.Length; i++)
        {
            Skill_PP_Txt[i].text = string.Format("{0} / {1}", PlayerPokemon.skills[i].PP, PlayerPokemon.skills[i].MaxPP);
            Skill_Type_Image[i].sprite = Skill_Type_Sprite[(int)PlayerPokemon.skills[i].propertyType];
            Skill_Type_Image[i].color = Skill_Icon_Color[(int)PlayerPokemon.skills[i].propertyType];
            Skill_BackGround_Image[i].color = Skill_Type_Color[i];
        }
    }
    public void FightUpKey()
    {
        PlayerSkill_Cursor.transform.position += Move_Fight_Cursor;
        Fight_Num--;
        UpdateSkillUI();
    }
    public void FightDownKey()
    {
        PlayerSkill_Cursor.transform.position -= Move_Fight_Cursor;
        Fight_Num++;
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
<<<<<<< Updated upstream
        //플레이어
        BattleManager.OnDamage(Attacker.skills[Num], Attacker, Target);
        Attacker.GetComponent<Animator>().SetTrigger($"Attack{Num}");
        Be_Attacked(Target);
=======
        isFight = false;
        isAttack = true;
        PlayerSkill_obj.SetActive(false);
        initializeAnimation(Attacker, Target);
        while (Attacker.SkillPP[Num] <= 0) // pp가 0 일시 사용 못하도록
        {
            Num = Random.Range(0, 4);
        }
        Attacker.SkillPP[Num]--;
        Attacker.GetComponent<Animator>().SetTrigger($"Attack{Num + 1}");
        battleManager.OnDamage(Attacker.skills[Num], Attacker, Target);
        Text_Play(string.Format("{0}의 \n{1}!", Attacker.Name, Attacker.skills[Num].Name), 0.8f); //데미지 문구        
    }
>>>>>>> Stashed changes

    }
<<<<<<< Updated upstream
    public void Be_Attacked(PokemonStats Target)
=======
    public void FirstEnemyAttack() // 상대방의 선공
    {
        StartCoroutine(FirstAttack_co(EnemyPokemon, PlayerPokemon, Enemy_Num, Fight_Num));
    }
    private IEnumerator FirstAttack_co(PokemonStats FirstPokemon, PokemonStats otherPokemon, int firstAttack_Num, int otherAttack_Num) //공격 딜레이를 위한 코루틴
    {
        Attack(FirstPokemon, otherPokemon, firstAttack_Num);
        yield return new WaitUntil(() => isAttack == false);
        yield return new WaitForSeconds(1f);
        CheckDead();
        if (!otherPokemon.isAlive)
        {
            ExitBattle();
        }
        yield return new WaitForSeconds(0.8f);
        Attack(otherPokemon, FirstPokemon, otherAttack_Num);
        yield return new WaitUntil(() => isAttack == false);
        yield return new WaitForSeconds(1f);
        CheckDead();
        if (!FirstPokemon.isAlive)
        {
            ExitBattle();
        }
        yield return new WaitForSeconds(0.8f);
        EndTurn();
    }
    public void Be_Attacked(PokemonStats Target) //피격모션 이벤트
>>>>>>> Stashed changes
    {
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
    #region Pokemon 관련 메서드
    #endregion
    #region Run 관련 메서드
    public void BattleRun()
    {
        int ran = Random.Range(0, 100);
        if(ran<95)
        {
            //배틀종료
        }
    }
    #endregion
<<<<<<< Updated upstream

    public void ExitBattle()
    {
=======
    #region 텍스트 관련
    public void Text_Play(string str, float num)
    {
        PlayerUI_obj.SetActive(false);
        EnemyUI_obj.SetActive(false);
        Effect_obj.SetActive(true);
        Effect_Txt.text = string.Format(str);
        Invoke("Text_Close", num);
    }
    public void Text_Close()
    {

        Effect_obj.SetActive(false);
    }
    #endregion

    public void CheckDead()
    {
        if (PlayerPokemon.Hp == 0)
        {
            PlayerPokemon.isAlive = false;
        }
        if (EnemyPokemon.Hp == 0)
        {
            EnemyPokemon.isAlive = false;
        }
        if (!PlayerPokemon.isAlive)
        {
            Text_Play("눈앞이 깜깜해졌다", 0.8f);
        }
        if (!EnemyPokemon.isAlive)
        {
            Text_Play("경험치를 획득했다!", 0.8f);
            PlayerPokemon.Exp += 50 * EnemyPokemon.Level;
            PlayerPokemon.CheckLevelUp();
        }
        //Text_Play($"{Target.Name}이/가 쓰러졌다!");
        //배틀종료
    }
    public void SetColor_Slider(Slider Target)
    {
        Image fillImage = Target.transform.Find("Fill Area/Fill").GetComponent<Image>();

        if (Target.value <= 0.25f)
        {
            fillImage.GetComponent<Image>().color = RedHp;
        }
        if (Target.value > 0.25f && Target.value <= 0.5f)
        {
            fillImage.GetComponent<Image>().color = OrangeHp;
        }
        if (Target.value > 0.5f && Target.value <= 1f)
        {
            fillImage.GetComponent<Image>().color = GreenHp;
        }
    } //체력바 색 업데이트
    public void ExitBattle()
    {
        SaveManager.instance.SavePlayerPokemonList(playerData.player_Pokemon);
        SceneManager.LoadSceneAsync("MainField");
>>>>>>> Stashed changes
        //배틀 종료 
        //데이터 베이스 정리하고 저쪽씬 로드
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
        //스킬타입에 따른 컬러
        Skill_Type_Color[0] = new Color(223 / 255f, 223 / 255f, 223 / 255f);
        Skill_Type_Color[1] = new Color(243 / 255f, 123 / 255f, 151 / 255f);
        Skill_Type_Color[2] = new Color(205 / 255f, 135 / 255f, 241 / 255f);
        Skill_Type_Color[3] = new Color(236 / 255f, 133 / 255f, 77 / 255f);
        Skill_Type_Color[4] = new Color(158 / 255f, 200 / 255f, 255 / 255f);
        Skill_Type_Color[5] = new Color(172 / 255f, 219 / 255f, 82 / 255f);
        Skill_Type_Color[6] = new Color(192 / 255f, 178 / 255f, 132 / 137f);
        Skill_Type_Color[7] = new Color(126 / 255f, 140 / 255f, 204 / 255f);
        Skill_Type_Color[8] = new Color(114 / 255f, 173 / 255f, 195 / 255f);
        Skill_Type_Color[9] = new Color(236 / 255f, 149 / 255f, 79 / 255f);
        Skill_Type_Color[10] = new Color(104 / 255f, 171 / 255f, 238 / 255f);
        Skill_Type_Color[11] = new Color(228 / 255f, 210 / 255f, 65 / 255f);
        Skill_Type_Color[12] = new Color(127 / 255f, 209 / 255f, 119 / 255f);
        Skill_Type_Color[13] = new Color(148 / 255f, 248 / 255f, 231 / 255f);
        Skill_Type_Color[14] = new Color(245 / 255f, 138 / 255f, 143 / 255f);
        Skill_Type_Color[15] = new Color(75 / 255f, 158 / 255f, 217 / 255f);
        Skill_Type_Color[16] = new Color(155 / 255f, 142 / 255f, 210 / 255f);
        Skill_Type_Color[17] = new Color(238 / 255f, 147 / 255f, 231 / 255f);
        Skill_Type_Color[18] = new Color(223 / 255f, 223 / 255f, 223 / 255f);
        //스킬 타입에 따른 아이콘 컬러
        Skill_Icon_Color[0] = new Color(202 / 255f, 205 / 255f, 210 / 255f);
        Skill_Icon_Color[1] = new Color(255 / 255f, 204 / 255f, 225 / 255f);
        Skill_Icon_Color[2] = new Color(238 / 255f, 184 / 255f, 241 / 255f);
        Skill_Icon_Color[3] = new Color(248 / 255f, 201 / 255f, 151 / 255f);
        Skill_Icon_Color[4] = new Color(201 / 255f, 226 / 255f, 255 / 255f);
        Skill_Icon_Color[5] = new Color(232 / 255f, 236 / 255f, 159 / 255f);
        Skill_Icon_Color[6] = new Color(236 / 255f, 226 / 255f, 175 / 255f);
        Skill_Icon_Color[7] = new Color(165 / 255f, 181 / 255f, 226 / 255f);
        Skill_Icon_Color[8] = new Color(168 / 255f, 218 / 255f, 222 / 255f);
        Skill_Icon_Color[9] = new Color(241 / 255f, 215 / 255f, 158 / 255f);
        Skill_Icon_Color[10] = new Color(157 / 255f, 222 / 255f, 236 / 255f);
        Skill_Icon_Color[11] = new Color(235 / 255f, 235 / 255f, 143 / 255f);
        Skill_Icon_Color[12] = new Color(191 / 255f, 229 / 255f, 176 / 255f);
        Skill_Icon_Color[13] = new Color(208 / 255f, 255 / 255f, 255 / 255f);
        Skill_Icon_Color[14] = new Color(246 / 255f, 212 / 255f, 213 / 255f);
        Skill_Icon_Color[15] = new Color(141 / 255f, 216 / 255f, 245 / 255f);
        Skill_Icon_Color[16] = new Color(193 / 255f, 187 / 255f, 221 / 255f);
        Skill_Icon_Color[17] = new Color(255 / 255f, 208 / 255f, 255 / 255f);
        Skill_Icon_Color[18] = new Color(202 / 255f, 205 / 255f, 210 / 255f);
    }

}
