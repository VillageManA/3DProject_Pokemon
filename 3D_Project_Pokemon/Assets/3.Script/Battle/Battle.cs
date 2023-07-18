using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public bool isRobby = true;
    public bool isFight;
    public bool isItem;
    public bool isPokemon;
    public bool isOption;
    public bool isInfo;
    public bool isAttack;

    [SerializeField] PokemonStats PlayerPokemon;
    [SerializeField] PokemonStats EnemyPokemon;
    BattleManager battleManager;
    [SerializeField] PlayerData playerData;
    [SerializeField] Animator player_Ani;

    [Header("UI ������Ʈ")]
    [Header("�÷��̾�")]
    [SerializeField] GameObject PlayerUI_obj;
    [SerializeField] GameObject player_Zone;
    [SerializeField] Text Player_Name;
    [SerializeField] Text Player_Level;
    [SerializeField] Text Player_Hp;
    [SerializeField] Slider Player_Hpbar;

    [Header("Enemy")]

    [SerializeField] PokemonStats[] enemyPokemonList;
    [SerializeField] Transform enemy_Zone;
    [SerializeField] GameObject EnemyUI_obj;
    [SerializeField] Text Enemy_Name;
    [SerializeField] Text Enemy_Level;
    [SerializeField] Slider Enemy_Hpbar;

    [Header("�κ� ���� ������Ʈ")]
    [SerializeField] GameObject Robby_obj;
    [SerializeField] GameObject Robby_Cursor;
    [SerializeField] Image[] Robby_BackGround;
    [SerializeField] Text[] Robby_Txt;

    [Header("�÷��̾� ��ų/���� ����")]
    [SerializeField] GameObject PlayerSkill_obj;
    [SerializeField] GameObject PlayerSkill_Cursor;
    [SerializeField] Text[] Skill_Name_txt;
    [SerializeField] Text[] Skill_PP_Txt;
    [SerializeField] Image[] Skill_Type_Image;
    [SerializeField] Image[] Skill_BackGround_Image;
    [SerializeField] Sprite[] Skill_Type_Sprite;

    [Header("���ϸ� ����")]
    [SerializeField] GameObject Pokemon_obj;
    [SerializeField] GameObject Pokemon_Cursor;
    [SerializeField] Image Pokemon_Right_Image;
    [SerializeField] GameObject[] Pokemon_Slot;
    [SerializeField] Text[] Pokemon_Name;
    [SerializeField] Text[] Pokemon_Level;
    [SerializeField] Text[] Pokemon_Hp;
    [SerializeField] Slider[] Pokemon_Hp_Bar;
    [SerializeField] Image[] Pokemon_Icon;

    [Header("�ɼ� ����")]
    [SerializeField] GameObject option_obj;
    [SerializeField] GameObject option_Selected_Zone;
    [SerializeField] GameObject option_Cursor;
    [SerializeField] Text[] option_Text;

    [Header("����â ����")]
    [SerializeField] GameObject Info_obj;
    [SerializeField] GameObject[] info_Pokemon_Status;
    [SerializeField] Image[] info_TopMenu_Icon;
    [SerializeField] Text Info_Name;
    [SerializeField] Text Info_Level;
    [SerializeField] Image info_Right_Image;

    [Header("����â ����")]
    [SerializeField] Text Info_Hp;
    [SerializeField] Text Info_Attack;
    [SerializeField] Text Info_Defence;
    [SerializeField] Text Info_SpAttack;
    [SerializeField] Text Info_SpDefence;
    [SerializeField] Text Info_Speed;

    [Header("����â ��ų")]
    [SerializeField] Text[] Info_Skill_Name;
    [SerializeField] Text[] Info_Skill_PP;
    [SerializeField] Image[] Info_Skill_Type;
    [SerializeField] Sprite[] skill_Type_Icon;


    [Header("ȿ�� ����")]
    [SerializeField] GameObject Effect_obj;
    [SerializeField] Text Effect_Txt;



    [Header("���Ӱ��� ������")]

    //�κ� ���� ����
    public int Robby_Num;
    private int Max_Robby_Num = 4;
    private Vector3 Default_Robby_Cursor = new Vector3(350, -65, 0);
    private Vector3 Move_Robby_Cursor = new Vector3(0, 120, 0);

    //���� ��ų ���� ����
    public int Fight_Num;
    private int Enemy_Num;
    private int Max_Fight_Num = 4;
    Color[] Skill_Type_Color = new Color[19];
    Color[] Skill_Icon_Color = new Color[19];
    private Vector3 Default_Fight_Cursor = new Vector3(660, -60, 0);
    private Vector3 Move_Fight_Cursor = new Vector3(0, 120, 0);
    PokemonAnimationEvent attackerAnimationEvent;
    PokemonAnimationEvent targetAnimationEvent;


    //���� ���� ����
    public int Item_Num;
    private Vector3 Default_Item_Cursor;
    private Vector3 Move_Item_Cursor;

    //���ϸ� ���� ����
    public int PokemonUI_Num;
    public int Pokemon_Alive_Num;
    public int Enemy_Alive_Num;
    public int selected_Pokemon = 0;
    public int enemy_Selected_Pokemon = 0;
    private Vector3 Default_Pokemon_Cursor;
    private Vector3 Move_Pokemon_Cursor = new Vector3(0, 140, 0);

    //���ϸ� ü�� ���� ����
    private Color GreenHp = new Color(2f / 255f, 226f / 255f, 0f / 255f);
    private Color OrangeHp = new Color(255f / 255f, 174f / 255f, 45f / 255f);
    private Color RedHp = new Color(255f / 255f, 50f / 255f, 37f / 255f);

    //�ɼ� ���� ����
    public int option_Num;
    private int maxOption_Num = 3;
    private Vector3 defalut_option_obj = new Vector3(900, 840, 0);
    private Vector3 move_option_obj = new Vector3(0, 140, 0);
    private Vector3 defalut_Selected_Zone = new Vector3(-50, 55, 0);
    private Vector3 defalut_Option_Cursor = new Vector3(-60, 0, 0);
    private Vector3 move_Option_Cursor = new Vector3(0, 50, 0);

    //���� ���� ����
    public int info_TopMenu_Num;
    private int max_Info_TopMenu_Num = 2;
    private int info_Selected_Num;
    private int max_Info_Selected_Num = 2;

    //ĳ�̿�
    private WaitForSeconds zero_Eight_Seconds = new WaitForSeconds(0.8f);
    private WaitForSeconds zero_Two_Seconds = new WaitForSeconds(0.2f);
    private WaitForSeconds One_Seconds = new WaitForSeconds(1f);
    private void Awake()
    {
        PlayerControl.Instance.gameObject.SetActive(false);
        battleManager = FindObjectOfType<BattleManager>();
        playerData = FindObjectOfType<PlayerData>();
        Pokemon_Alive_Num = playerData.player_Pokemon.Count;
        enemyPokemonList = EnemyData.Instance.SelectedEnemyPokemon;
        Enemy_Alive_Num = enemyPokemonList.Length;
        SummonEnemy(enemy_Selected_Pokemon);
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
        } //�κ񿡼� �Է�
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
                if (PlayerPokemon.SkillPP[Fight_Num] <= 0)
                {
                    return;
                }
                FightEnterKey();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                FightExitKey();
            }
        } // ����Ʈ �����϶� �Է�
        if (isItem)
        {

        } //����ĭ���� �Է�
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
                UpdateOptionUI();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PokemonExitKey();
            }
        } //���ϸ�ĭ���� �Է�
        if (isOption)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                OptionUpKey();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                OptionDownKey();
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                OptionEnterKey();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OptionExitKey();
            }
        } //���ϸ� �ɼ�â���� �Է�
        if (isInfo)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                InfoUpKey();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                InfoDownKey();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                InfoLeftKey();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                InfoRightKey();
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                InfoEnterKey();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                InfoExitKey();
            }
        }//���ϸ� ����â���� �Է�
    }
    #region StatsUI ���� �޼���
    public void UpdateStatsUI() // ���Ʒ� �÷��̾�,��� ���ϸ� ����â UI ������Ʈ
    {
        UpdatePlayerStatsUI();
        UpdateEnemyStatsUI();
        UpdateHpBar(PlayerPokemon, Player_Hpbar);
        UpdateHpBar(EnemyPokemon, Enemy_Hpbar);
    }
    public void UpdatePlayerStatsUI() //�÷��̾� ����â UI ������Ʈ
    {
        Player_Name.text = PlayerPokemon.Name;
        Player_Level.text = string.Format("Lv.{0}", PlayerPokemon.Level);
        Player_Hp.text = string.Format("{0} / {1}", PlayerPokemon.Hp, PlayerPokemon.MaxHp);
    }
    public void UpdateEnemyStatsUI() // ��� ���ϸ� ����â UI ������Ʈ
    {
        Enemy_Name.text = EnemyPokemon.Name;
        Enemy_Level.text = string.Format("Lv.{0}", EnemyPokemon.Level);

    }
    public void UpdateHpBar(PokemonStats Target, Slider Target_Slider) //�ڿ������� Hpbar�� ���������� �޼���
    {
        float targetHp_Value = (float)Target.Hp / Target.MaxHp;
        float durationTime = 1f;

        StartCoroutine(HpUpdate_Co(targetHp_Value, durationTime, Target_Slider));
    }
    private IEnumerator HpUpdate_Co(float targetHp_Value, float durationTime, Slider Target) //�ڿ������� HPbar�� ���������� �ڷ�ƾ
    {
        float elapsedTime = 0f;
        float startHpValue = Target.value;
        while (elapsedTime < durationTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / durationTime);
            float smoothedValue = Mathf.Lerp(startHpValue, targetHp_Value, t);
            Target.value = smoothedValue;
            SetColor_Slider(Target);
            yield return null;

        }
        Target.value = targetHp_Value;
    }
    #endregion
    #region Robby ���� �޼���
    public void UpdateRobbyUI() //�κ� 4ĭ â UI ������Ʈ
    {
        for (int i = 0; i < Max_Robby_Num; i++)
        {
            Robby_BackGround[i].color = Color.white;
            Robby_Txt[i].color = Color.black;
        }
        Robby_BackGround[Robby_Num].color = Color.black;
        Robby_Txt[Robby_Num].color = Color.white;
    }
    public void RobbyUpKey()
    {
        if (Robby_Num <= 0)
        {
            return;
        }
        Robby_Cursor.transform.position += Move_Robby_Cursor;
        Robby_Num--;
        UpdateRobbyUI();
    }
    public void RobbyDownKey()
    {
        if (Robby_Num >= Max_Robby_Num - 1)
        {
            return;
        }
        Robby_Cursor.transform.position -= Move_Robby_Cursor;
        Robby_Num++;
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
                    UpdateSkillUI();
                }
                break;
            case 1:
                {
                    isRobby = false;
                    isPokemon = true;
                    Robby_obj.SetActive(false);
                    Pokemon_obj.SetActive(true);
                    UpdatePokemonUI();
                }
                break;
            case 2:
                {
                    isRobby = false;
                    isItem = true;
                    Debug.Log("������ ��üĭ");
                }
                break;
            case 3:
                {
                    isRobby = false;
                    BattleRun();
                }
                break;
        }
    }
    #endregion
    #region Fight ���� �޼���
    public void UpdateSkillUI() // �÷��̾��� ��ų4ĭâ UI ������Ʈ
    {
        for (int i = 0; i < Max_Fight_Num; i++)
        {
            Skill_Name_txt[i].text = string.Format(PlayerPokemon.skills[i].Name);
            Skill_PP_Txt[i].text = string.Format("{0} / {1}", PlayerPokemon.SkillPP[i], PlayerPokemon.skills[i].MaxPP);
            Skill_Type_Image[i].sprite = Skill_Type_Sprite[(int)PlayerPokemon.skills[i].propertyType];
            Skill_Type_Image[i].color = Skill_Icon_Color[(int)PlayerPokemon.skills[i].propertyType];
            Skill_BackGround_Image[i].color = Skill_Type_Color[(int)PlayerPokemon.skills[i].propertyType];
        }
    }
    public void FightUpKey()
    {
        if (Fight_Num <= 0)
        {
            return;
        }
        PlayerSkill_Cursor.transform.position += Move_Fight_Cursor;
        Fight_Num--;
        UpdateSkillUI();
    }
    public void FightDownKey()
    {
        if (Fight_Num >= Max_Fight_Num - 1)
        {
            return;
        }
        PlayerSkill_Cursor.transform.position -= Move_Fight_Cursor;
        Fight_Num++;
        UpdateSkillUI();
    }
    public void FightEnterKey()
    {
        Enemy_Num = Random.Range(0, 4);
        //����ĭ ����
        if (PlayerPokemon.skills[Fight_Num].Priority > EnemyPokemon.skills[Enemy_Num].Priority)
        {
            FirstPlayerAttack();
        }
        else if (EnemyPokemon.skills[Enemy_Num].Priority > PlayerPokemon.skills[Fight_Num].Priority)
        {
            FirstEnemyAttack();
        }
        else
        {
            if (PlayerPokemon.Speed > EnemyPokemon.Speed) // ���� �ӵ��� �����ٸ�
            {
                FirstPlayerAttack();
            }
            else if (PlayerPokemon.Speed < EnemyPokemon.Speed) //��밡 �ӵ��� �����ٸ�
            {
                FirstEnemyAttack();
            }
            else if (PlayerPokemon.Speed == EnemyPokemon.Speed) //���ӽ� ����
            {
                int ran = Random.Range(0, 1);
                switch (ran)
                {
                    case 0:
                        {
                            FirstPlayerAttack();
                        }
                        break;
                    case 1:
                        {
                            FirstEnemyAttack();
                        }
                        break;
                }
            }
        }
    }
    public void Attack(PokemonStats Attacker, PokemonStats Target, int Num)
    {
        while (Attacker.SkillPP[Num] <= 0) // pp�� 0 �Ͻ� ��� ���ϵ���
        {
            Num = Random.Range(0, 4);
            return;
        }
        isFight = false;
        isAttack = true;
        PlayerSkill_obj.SetActive(false);
        initializeAnimation(Attacker, Target);
        Attacker.SkillPP[Num]--;
        Attacker.GetComponent<Animator>().SetTrigger($"Attack{Num + 1}");
        battleManager.OnDamage(Attacker.skills[Num], Attacker, Target);
        Text_Play(string.Format("{0}�� \n{1}!", Attacker.Name, Attacker.skills[Num].Name), 0.8f); //������ ����        
    }

    public void FirstPlayerAttack() //�÷��̾��� ����
    {

        StartCoroutine(FirstAttack_co(PlayerPokemon, EnemyPokemon, Fight_Num, Enemy_Num));
    }
    public void FirstEnemyAttack() // ������ ����
    {
        StartCoroutine(FirstAttack_co(EnemyPokemon, PlayerPokemon, Enemy_Num, Fight_Num));
    }
    private IEnumerator FirstAttack_co(PokemonStats FirstPokemon, PokemonStats otherPokemon, int firstAttack_Num, int otherAttack_Num) //���� �����̸� ���� �ڷ�ƾ
    {
        Attack(FirstPokemon, otherPokemon, firstAttack_Num);
        yield return new WaitUntil(() => isAttack == false);
        yield return One_Seconds;
        CheckDead();
        yield return zero_Two_Seconds;
        if (otherPokemon.isAlive)
        {
            Attack(otherPokemon, FirstPokemon, otherAttack_Num);
            yield return new WaitUntil(() => isAttack == false);
            yield return One_Seconds;
            CheckDead();
            yield return zero_Two_Seconds;
        }
        else
        {
            EndTurn();
        }
    }
    public void Be_Attacked(PokemonStats Target) //�ǰݸ�� �̺�Ʈ
    {
        Target.GetComponent<Animator>().SetTrigger("Be_Attacked");
    }
    public void initializeAnimation(PokemonStats Attacker, PokemonStats Target) // �ִϸ��̼� �̺�Ʈ�� ���
    {
        attackerAnimationEvent = Attacker.GetComponent<PokemonAnimationEvent>();
        targetAnimationEvent = Target.GetComponent<PokemonAnimationEvent>();

        attackerAnimationEvent.onHitEvent.RemoveAllListeners();
        attackerAnimationEvent.onAttackEvent.RemoveAllListeners();
        attackerAnimationEvent.onDirectAttack.RemoveAllListeners();

        targetAnimationEvent.onHitEvent.RemoveAllListeners();
        targetAnimationEvent.onAttackEvent.RemoveAllListeners();
        targetAnimationEvent.onDirectAttack.RemoveAllListeners();
        if (attackerAnimationEvent != null)
        {
            // onHitEvent �̺�Ʈ�� Be_Attacked �޼��带 ���
            attackerAnimationEvent.onHitEvent.AddListener(() => EndAttack());
            attackerAnimationEvent.onAttackEvent.AddListener(() => Be_Attacked(Target));  //��ƼŬ -> ���߻� �޼��� �� �ٲܰ�
            attackerAnimationEvent.onDirectAttack.AddListener(() => Be_Attacked(Target));
        }
        if (targetAnimationEvent != null)
        {
            // onHitEvent �̺�Ʈ�� Be_Attacked �޼��带 ���
            targetAnimationEvent.onHitEvent.AddListener(() => EndAttack());
            targetAnimationEvent.onAttackEvent.AddListener(() => Be_Attacked(Target)); //��ƼŬ -> ���߻� �޼��� �� �ٲܰ�
            targetAnimationEvent.onDirectAttack.AddListener(() => Be_Attacked(Target));
        }
    }
    public void FightExitKey() //ESCŰ �Է½� �κ�� �Ѿ��
    {
        isFight = false;
        isRobby = true;
        PlayerSkill_obj.SetActive(false);
        Robby_obj.SetActive(true);
    }
    public void EndAttack() // �Ѹ����� ������ ������ ����
    {
        isAttack = false;
        EnemyUI_obj.SetActive(true);
        PlayerUI_obj.SetActive(true);
        battleManager.PropertyRank = 1;
        battleManager.DamageRank = 1;
        UpdateStatsUI();
    }
    public void EndTurn() // �Ѵ� ������ ������ �������
    {
        EndAttack();
        PlayerSkill_Cursor.transform.localPosition = Default_Fight_Cursor;
        Robby_Cursor.transform.localPosition = Default_Robby_Cursor;
        Fight_Num = 0;
        Robby_Num = 0;
        isRobby = true;
        Robby_obj.SetActive(true);
        Update_PokemonData();
    }
    public void Update_PokemonData()
    {
        playerData.player_Pokemon_List[selected_Pokemon].Hp = PlayerPokemon.Hp;
        playerData.player_Pokemon_List[selected_Pokemon].SkillPP[0] = PlayerPokemon.SkillPP[0];
        playerData.player_Pokemon_List[selected_Pokemon].SkillPP[1] = PlayerPokemon.SkillPP[1];
        playerData.player_Pokemon_List[selected_Pokemon].SkillPP[2] = PlayerPokemon.SkillPP[2];
        playerData.player_Pokemon_List[selected_Pokemon].SkillPP[3] = PlayerPokemon.SkillPP[3];

        enemyPokemonList[enemy_Selected_Pokemon].Hp = EnemyPokemon.Hp;
        enemyPokemonList[enemy_Selected_Pokemon].SkillPP[0] = EnemyPokemon.SkillPP[0];
        enemyPokemonList[enemy_Selected_Pokemon].SkillPP[1] = EnemyPokemon.SkillPP[1];
        enemyPokemonList[enemy_Selected_Pokemon].SkillPP[2] = EnemyPokemon.SkillPP[2];
        enemyPokemonList[enemy_Selected_Pokemon].SkillPP[3] = EnemyPokemon.SkillPP[3];
    }
    #endregion
    #region Pokemon ���� �޼���
    public void PokemonUpKey()
    {
        if (PokemonUI_Num <= 0)
        {
            return;
        }
        PokemonUI_Num--;
        Pokemon_Cursor.transform.position += Move_Pokemon_Cursor;
        UpdatePokemonUI();
    }
    public void PokemonDownKey()
    {
        if (PokemonUI_Num >= playerData.player_Pokemon_List.Length - 1)
        {
            return;
        }
        PokemonUI_Num++;
        Pokemon_Cursor.transform.position -= Move_Pokemon_Cursor;
        UpdatePokemonUI();
    }
    public void PokemonEnterKey()
    {
        isPokemon = false;
        isOption = true;
        option_obj.SetActive(true);
    }
    public void PokemonExitKey()
    {
        isPokemon = false;
        isRobby = true;
        Pokemon_obj.SetActive(false);
        Robby_obj.SetActive(true);
    }
    public void UpdatePokemonUI()
    {
        PokemonUIClear();
        for (int i = 0; i < playerData.player_Pokemon_List.Length; i++) // 6�� �÷��̾� List�� Count������ �ٲ��ٰ� , Temp_pokemon�� PlayerList[i]��° ���ϸ����� �ٲ��ٰ�
        {
            Pokemon_Name[i].text = playerData.player_Pokemon_List[i].Name;
            Pokemon_Level[i].text = string.Format($"Lv.{playerData.player_Pokemon_List[i].Level}");
            Pokemon_Hp[i].text = string.Format($"{playerData.player_Pokemon_List[i].Hp}/{playerData.player_Pokemon_List[i].MaxHp}");
            Pokemon_Hp_Bar[i].value = (float)playerData.player_Pokemon_List[i].Hp / playerData.player_Pokemon_List[i].MaxHp;
            SetColor_Slider(Pokemon_Hp_Bar[i]);
            Pokemon_Icon[i].sprite = playerData.player_Pokemon_List[i].Icon;

            Pokemon_Slot[i].GetComponent<Image>().color = Color.white;
            Pokemon_Name[i].color = Color.black;
            Pokemon_Level[i].color = Color.black;
            Pokemon_Hp[i].color = Color.black;
        }
        Pokemon_Slot[PokemonUI_Num].GetComponent<Image>().color = Color.black;
        Pokemon_Name[PokemonUI_Num].color = Color.white;
        Pokemon_Level[PokemonUI_Num].color = Color.white;
        Pokemon_Hp[PokemonUI_Num].color = Color.white;
        Pokemon_Right_Image.sprite = playerData.player_Pokemon_List[PokemonUI_Num].Image;
        Pokemon_Right_Image.SetNativeSize();

    }
    public void PokemonUIClear()
    {
        for (int i = 0; i < 6; i++)
        {
            Pokemon_Slot[i].SetActive(false);

        }
        for (int i = 0; i < playerData.player_Pokemon_List.Length; i++) // 6�� �÷��̾� List�� Count������ �ٲ��ٰ�
        {
            Pokemon_Slot[i].SetActive(true);
        }
    }

    #endregion
    #region Option ���� �޼���
    public void OptionUpKey()
    {
        if (option_Num <= 0)
        {
            return;
        }
        option_Num--;
        option_Selected_Zone.transform.position += move_Option_Cursor;

        UpdateOptionUI();
    }
    public void OptionDownKey()
    {
        if (option_Num >= maxOption_Num - 1)
        {
            return;
        }
        option_Num++;
        option_Selected_Zone.transform.position -= move_Option_Cursor;
        UpdateOptionUI();
    }
    public void OptionEnterKey()
    {
        switch (option_Num)
        {
            case 0:
                {
                    //���ϸ� ��ü
                    StartCoroutine(ChangePokemon_co());
                }
                break;
            case 1:
                {
                    info_Selected_Num = PokemonUI_Num;
                    UpdateInfoUI();
                    option_obj.SetActive(false);
                    Info_obj.SetActive(true);
                    isOption = false;
                    isInfo = true;
                    //���ϸ� ����â Ȯ������ �Ѿ��
                }
                break;
            case 2:
                {
                    OptionExitKey();
                }
                break;
        }
    }
    public void OptionExitKey()
    {
        option_Selected_Zone.transform.localPosition = defalut_Selected_Zone;
        option_Num = 0;
        UpdateOptionUI();
        isOption = false;
        isPokemon = true;
        option_obj.SetActive(false);
    }
    public void UpdateOptionUI()
    {
        option_obj.transform.position = defalut_option_obj;
        for (int i = 0; i < PokemonUI_Num; i++)
        {
            option_obj.transform.position -= move_option_obj;
        }
        for (int i = 0; i < maxOption_Num; i++)
        {
            option_Text[i].color = Color.black;
        }
        option_Text[option_Num].color = Color.white;
    }
    #endregion
    #region Info ���� �޼���
    public void InfoUpKey()
    {
        if (info_Selected_Num <= 0)
        {
            return;
        }
        info_Selected_Num--;
        UpdateInfoUI();
    }
    public void InfoDownKey()
    {
        if (info_Selected_Num >= max_Info_Selected_Num - 1)
        {
            return;
        }
        info_Selected_Num++;
        UpdateInfoUI();
    }
    public void InfoLeftKey()
    {
        if (info_TopMenu_Num <= 0)
        {
            return;
        }
        info_TopMenu_Num--;
        UpdateInfoUI();
    }
    public void InfoRightKey()
    {
        if (info_TopMenu_Num >= max_Info_TopMenu_Num - 1)
        {
            return;
        }
        info_TopMenu_Num++;
        UpdateInfoUI();
    }
    public void InfoEnterKey()
    {

    }
    public void InfoExitKey()
    {
        isInfo = false;
        isPokemon = true;
        Info_obj.SetActive(false);
        info_TopMenu_Num = 0;
        info_Selected_Num = 0;
    }
    public void UpdateInfoUI()
    {
        Info_Name.text = string.Format($"{playerData.player_Pokemon[info_Selected_Num].Name}");
        Info_Level.text = string.Format($"Lv.{playerData.player_Pokemon[info_Selected_Num].Level}");

        Info_Hp.text = string.Format($"HP\n{playerData.player_Pokemon[info_Selected_Num].Hp} / {playerData.player_Pokemon[info_Selected_Num].MaxHp}");
        Info_Attack.text = string.Format($"����\n{playerData.player_Pokemon[info_Selected_Num].Attack}");
        Info_SpAttack.text = string.Format($"Ư������\n{playerData.player_Pokemon[info_Selected_Num].SpAttack}");
        Info_Defence.text = string.Format($"{playerData.player_Pokemon[info_Selected_Num].Defence}\n���");
        Info_SpDefence.text = string.Format($"{playerData.player_Pokemon[info_Selected_Num].SpDefence}\nƯ�����");
        Info_Speed.text = string.Format($"{playerData.player_Pokemon[info_Selected_Num].Speed}\n���ǵ�");

        for (int i = 0; i < playerData.player_Pokemon[info_Selected_Num].skills.Count; i++)
        {
            Info_Skill_Name[i].text = string.Format($"{playerData.player_Pokemon[info_Selected_Num].skills[i].Name}");
            Info_Skill_Type[i].sprite = skill_Type_Icon[(int)playerData.player_Pokemon[info_Selected_Num].skills[i].propertyType];
            Info_Skill_PP[i].text = string.Format($"{playerData.player_Pokemon[info_Selected_Num].SkillPP[i]}/{playerData.player_Pokemon[info_Selected_Num].skills[i].MaxPP}");
        }

        info_Right_Image.sprite = playerData.player_Pokemon[info_Selected_Num].Image;
        info_Right_Image.SetNativeSize();

        for (int i = 0; i < info_TopMenu_Icon.Length; i++)
        {
            info_TopMenu_Icon[i].color = Color.white;
            info_Pokemon_Status[i].SetActive(false);
        }
        info_Pokemon_Status[info_TopMenu_Num].SetActive(true);
        info_TopMenu_Icon[info_TopMenu_Num].color = Color.black;



    }
    #endregion
    #region Run ���� �޼���
    public void BattleRun()
    {
        int ran = Random.Range(0, 100);
        if (ran < 95)
        {
            ExitBattle();
            //��Ʋ����
        }
        else
        {
            ExitBattle();
            //�ϴ� �ӽ� ���Ŀ� ���� �ҿ���
        }
    }
    #endregion
    #region �ؽ�Ʈ ����
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


    public void SummonEnemy(int num)
    {
        GameObject obj = Instantiate(enemyPokemonList[num].gameObject, enemy_Zone.transform.position, Quaternion.identity);
        obj.transform.LookAt(player_Zone.transform.position);
        obj.transform.tag = "EnemyPokemon";
    }
    public void ChangeEnemyPokemon()
    {
        EnemyPokemon.transform.position = new Vector3(-999, -999, -999);
        EnemyPokemon.transform.tag = "None";
        enemy_Selected_Pokemon++;
        SummonEnemy(enemy_Selected_Pokemon);
        if (PlayerPokemon != null)
        {
            Invoke("Enemy_Change_Setting", 0.8f);
        }
    }
    public void CheckDead()
    {
        if (PlayerPokemon.Hp == 0)
        {
            PlayerPokemon.isAlive = false;
            playerData.player_Pokemon[selected_Pokemon].isAlive = false;
            Pokemon_Alive_Num--;
        }
        if (EnemyPokemon.Hp == 0)
        {
            EnemyPokemon.isAlive = false;
            enemyPokemonList[enemy_Selected_Pokemon].isAlive = false;
            Enemy_Alive_Num--;
        }
        if (!PlayerPokemon.isAlive)
        {
            if (Pokemon_Alive_Num > 0)
            {
                //���ϸ� ui ��� ��ü �����ϰ� ���ּ���
            }
            else
            {
                Text_Play("������ ����������", 0.8f);
                ExitBattle();
            }

        }
        if (!EnemyPokemon.isAlive)
        {
            Text_Play("����ġ�� ȹ���ߴ�!", 0.8f);
            PlayerPokemon.Exp += 50 * EnemyPokemon.Level;
            PlayerPokemon.CheckLevelUp();
            if (Enemy_Alive_Num > 0)
            {
                Invoke("ChangeEnemyPokemon", 0.9f);
            }
            else
            {
                ExitBattle();
            }
        }
        //Text_Play($"{Target.Name}��/�� ��������!");
        //��Ʋ����
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
    } //ü�¹� �� ������Ʈ
    public void ExitBattle()
    {
        SaveManager.instance.SavePlayerPokemonList(playerData.player_Pokemon);
        SceneManager.LoadSceneAsync("MainField");

    }
    public void FindPokemon()
    {
        GameObject Enemy = GameObject.FindGameObjectWithTag("EnemyPokemon");
        EnemyPokemon = Enemy.GetComponent<PokemonStats>();
        GameObject Player = GameObject.FindGameObjectWithTag("PlayerPokemon");
        PlayerPokemon = Player.GetComponent<PokemonStats>();
    }
    public IEnumerator ChangePokemon_co()
    {
        option_obj.SetActive(false);
        Pokemon_obj.SetActive(false);
        isOption = false;
        isRobby = true;
        PlayerPokemon.transform.position = new Vector3(999, 999, 999);
        PlayerPokemon.transform.tag = "None";
        yield return null;
        Text_Play($"���ƿ� {PlayerPokemon.Name}", 0.8f);
        yield return zero_Eight_Seconds;

        selected_Pokemon = PokemonUI_Num;
        Text_Play($"���� {playerData.player_Pokemon[selected_Pokemon].Name}!", 0.4f);
        player_Ani.SetTrigger("Start");

    }
    public void StartBattle()
    {
        PlayerUI_obj.SetActive(true);
        EnemyUI_obj.SetActive(true);
        Robby_obj.SetActive(true);
        FindPokemon();
        PlayerPokemon.Setting_LevelStats();
        EnemyPokemon.Setting_LevelStats();
        Player_Hpbar.value = (float)PlayerPokemon.Hp / PlayerPokemon.MaxHp;
        Enemy_Hpbar.value = (float)EnemyPokemon.Hp / EnemyPokemon.MaxHp;
        UpdateStatsUI();
        UpdateSkillUI();
        SetColor_Slider(Player_Hpbar);
        SetColor_Slider(Enemy_Hpbar);
    } //��Ʋ ���۵ɶ�

    public void Enemy_Change_Setting()
    {
        FindPokemon();
        EnemyPokemon.Setting_LevelStats();
        Enemy_Hpbar.value = (float)EnemyPokemon.Hp / EnemyPokemon.MaxHp;
        UpdateStatsUI();
    }
    public void SetSkillTypeColor()
    {
        //��ųŸ�Կ� ���� �÷�
        Skill_Type_Color[0] = new Color(223 / 255f, 223 / 255f, 223 / 255f);
        Skill_Type_Color[1] = new Color(243 / 255f, 123 / 255f, 151 / 255f);
        Skill_Type_Color[2] = new Color(205 / 255f, 135 / 255f, 241 / 255f);
        Skill_Type_Color[3] = new Color(236 / 255f, 133 / 255f, 77 / 255f);
        Skill_Type_Color[4] = new Color(158 / 255f, 200 / 255f, 255 / 255f);
        Skill_Type_Color[5] = new Color(172 / 255f, 219 / 255f, 82 / 255f);
        Skill_Type_Color[6] = new Color(192 / 255f, 178 / 255f, 137 / 255f);
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
        //��ų Ÿ�Կ� ���� ������ �÷�
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
