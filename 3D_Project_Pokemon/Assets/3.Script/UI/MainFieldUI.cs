using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainFieldUI : MonoBehaviour
{
    public bool isMainField = true;
    public bool isOpen;
    public bool isRobby;
    public bool isPokemon;
    public bool isOption;
    public bool isChange;
    public bool isInfo;

    [SerializeField] PlayerData playerData;

    [Header("로비 관련")]
    [SerializeField] GameObject Robby_obj;
    [SerializeField] GameObject Robby_Cursor;
    [SerializeField] Image[] Robby_Icon_BackGround;

    [Header("포켓몬 관련")]
    [SerializeField] GameObject Pokemon_obj;
    [SerializeField] GameObject Pokemon_Cursor;
    [SerializeField] Image Pokemon_Right_Image;
    [SerializeField] GameObject[] Pokemon_Slot;
    [SerializeField] Text[] Pokemon_Name;
    [SerializeField] Text[] Pokemon_Level;
    [SerializeField] Text[] Pokemon_Hp;
    [SerializeField] Slider[] Pokemon_Hp_Bar;
    [SerializeField] Image[] Pokemon_Icon;

    [Header("교체 관련")]
    [SerializeField] GameObject Change_obj;
    [SerializeField] GameObject Change_Slot;
    [SerializeField] Text Change_Name;
    [SerializeField] Text Change_Level;
    [SerializeField] Text Change_Hp;
    [SerializeField] Slider Change_Hp_Bar;
    [SerializeField] Image Change_Icon;

    [Header("옵션 관련")]
    [SerializeField] GameObject option_obj;
    [SerializeField] GameObject option_Selected_Zone;
    [SerializeField] GameObject option_Cursor;
    [SerializeField] Text[] option_Text;

    [Header("상태창 관련")]
    [SerializeField] GameObject Info_obj;
    [SerializeField] GameObject[] info_Pokemon_Status;
    [SerializeField] Image[] info_TopMenu_Icon;
    [SerializeField] Text Info_Name;
    [SerializeField] Text Info_Level;
    [SerializeField] Image info_Right_Image;

    [Header("상태창 스텟")]
    [SerializeField] Text Info_Hp;
    [SerializeField] Text Info_Attack;
    [SerializeField] Text Info_Defence;
    [SerializeField] Text Info_SpAttack;
    [SerializeField] Text Info_SpDefence;
    [SerializeField] Text Info_Speed;

    [Header("상태창 스킬")]
    [SerializeField] Text[] Info_Skill_Name;
    [SerializeField] Text[] Info_Skill_PP;
    [SerializeField] Image[] Info_Skill_Type;
    [SerializeField] Sprite[] skill_Type_Icon;

    //로비 관련 변수
    public int Robby_Num;
    private int maxRobby_Num = 6;
    private Vector3 move_Right_Robby_Cursor = new Vector3(400, 0, 0);
    private Vector3 move_Down_Robby_Cursor = new Vector3(0, -330, 0);
    private Vector3 Icon_Three_Position = new Vector3(1340, 820, 0);
    private Vector3 Icon_Four_Position = new Vector3(140, 490, 0);
    private Vector3 defalut_Robby_Cursor;

    //포켓몬 관련 변수
    public int PokemonUI_Num;
    public int Pokemon_Alive_Num;
    public int Enemy_Alive_Num;
    public int selected_Pokemon = 0;
    public int enemy_Selected_Pokemon = 0;
    private Vector3 Default_Pokemon_Cursor;
    private Vector3 Move_Pokemon_Cursor = new Vector3(0, 140, 0);

    //포켓몬 체력 관련 변수
    private Color GreenHp = new Color(2f / 255f, 226f / 255f, 0f / 255f);
    private Color OrangeHp = new Color(255f / 255f, 174f / 255f, 45f / 255f);
    private Color RedHp = new Color(255f / 255f, 50f / 255f, 37f / 255f);

    //교체 관련 변수
    public int Change_Num;
    private int max_Change_Num;
    private Vector3 move_Change_Slot = new Vector3(0, 140, 0);
    private Vector3 defalut_Change_Slot = new Vector3(440,880,0);
    //옵션 관련 변수
    public int option_Num;
    private int maxOption_Num = 3;
    private Vector3 defalut_option_obj = new Vector3(900, 840, 0);
    private Vector3 move_option_obj = new Vector3(0, 140, 0);
    private Vector3 defalut_Selected_Zone = new Vector3(-50, 55, 0);
    private Vector3 defalut_Option_Cursor = new Vector3(-60, 0, 0);
    private Vector3 move_Option_Cursor = new Vector3(0, 50, 0);

    //인포 관련 변수
    public int info_TopMenu_Num;
    private int max_Info_TopMenu_Num = 2;
    private int info_Selected_Num;
    private int max_Info_Selected_Num;


    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
    }
    private void Update()
    {
        if (isMainField)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isRobby = true;
                isOpen = true;
                isMainField = false;
                Robby_obj.SetActive(true);
                PlayerControl.Instance.GetComponent<PlayerInput>().enabled = false;
                PlayerControl.Instance.GetComponent<Animator>().SetBool("Run", false);
                PlayerControl.Instance.GetComponent<Animator>().SetBool("Move", false);
                return;
            }
        }
        if (!isOpen)
        {
            return;
        }
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
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                RobbyLeftKey();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                RobbyRightKey();
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                RobbyEneterKey();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                RobbyExitKey();
            }
        }//로비상태 입력
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
        } //포켓몬칸에서 입력
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
        }//옵션칸에서 입력
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
        }//인포칸에서 입력
        if (isChange)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ChangeUPKey();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ChangeDownKey();
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                ChangeEnterKey();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ChangeExitKey();
            }
        }//체인지칸에서 입력
    }
    #region 로비 관련
    public void RobbyUpKey()
    {
        if (Robby_Num - 4 < 0)
        {
            return;
        }
        Robby_Cursor.transform.position -= move_Down_Robby_Cursor;
        Robby_Num -= 4;
        UpdateRobbyUI();
    }
    public void RobbyDownKey()
    {

        if (Robby_Num + 4 >= maxRobby_Num)
        {
            return;
        }
        Robby_Cursor.transform.position += move_Down_Robby_Cursor;
        Robby_Num += 4;
        UpdateRobbyUI();
    }
    public void RobbyLeftKey()
    {
        if (Robby_Num <= 0)
        {
            return;
        }
        if (Robby_Num == 4)
        {
            Robby_Cursor.transform.position = Icon_Three_Position;
        }
        else
        {
            Robby_Cursor.transform.position -= move_Right_Robby_Cursor;
        }
        Robby_Num--;
        UpdateRobbyUI();
    }
    public void RobbyRightKey()
    {
        if (Robby_Num >= maxRobby_Num - 1)
        {
            return;
        }
        if (Robby_Num == 3)
        {
            Robby_Cursor.transform.position = Icon_Four_Position;
        }
        else
        {
            Robby_Cursor.transform.position += move_Right_Robby_Cursor;
        }
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
                    isPokemon = true;
                    Robby_obj.SetActive(false);
                    Pokemon_obj.SetActive(true);
                    UpdatePokemonUI();
                }
                break;
            case 1:
                {

                }
                break;
            case 2:
                {

                }
                break;
            case 3:
                {

                }
                break;
            case 4:
                {

                }
                break;
            case 5:
                {

                }
                break;

        }
    }
    public void RobbyExitKey()
    {
        isRobby = false;
        isMainField = true;
        Robby_obj.SetActive(false);
        PlayerControl.Instance.GetComponent<PlayerInput>().enabled = true;
    }
    public void UpdateRobbyUI()
    {
        for (int i = 0; i < maxRobby_Num; i++)
        {
            Robby_Icon_BackGround[i].color = Color.white;
        }
        Robby_Icon_BackGround[Robby_Num].color = Color.black;
    }



    #endregion
    #region 포켓몬 관련
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
        for (int i = 0; i < playerData.player_Pokemon.Count; i++) // 6을 플레이어 List의 Count까지로 바꿔줄것 , Temp_pokemon을 PlayerList[i]번째 포켓몬으로 바꿔줄것
        {
            Pokemon_Name[i].text = playerData.player_Pokemon[i].Name;
            Pokemon_Level[i].text = string.Format($"Lv.{playerData.player_Pokemon[i].Level}");
            Pokemon_Hp[i].text = string.Format($"{playerData.player_Pokemon[i].Hp}/{playerData.player_Pokemon[i].MaxHp}");
            Pokemon_Hp_Bar[i].value = (float)playerData.player_Pokemon[i].Hp / playerData.player_Pokemon[i].MaxHp;
            SetColor_Slider(Pokemon_Hp_Bar[i]);
            Pokemon_Icon[i].sprite = playerData.player_Pokemon[i].Icon;

            Pokemon_Slot[i].GetComponent<Image>().color = Color.white;
            Pokemon_Name[i].color = Color.black;
            Pokemon_Level[i].color = Color.black;
            Pokemon_Hp[i].color = Color.black;
        }
        Pokemon_Slot[PokemonUI_Num].GetComponent<Image>().color = Color.black;
        Pokemon_Name[PokemonUI_Num].color = Color.white;
        Pokemon_Level[PokemonUI_Num].color = Color.white;
        Pokemon_Hp[PokemonUI_Num].color = Color.white;
        Pokemon_Right_Image.sprite = playerData.player_Pokemon[PokemonUI_Num].Image;
        Pokemon_Right_Image.SetNativeSize();

    }
    public void PokemonUIClear()
    {
        for (int i = 0; i < 6; i++)
        {
            Pokemon_Slot[i].SetActive(false);

        }
        for (int i = 0; i < playerData.player_Pokemon_List.Length; i++) // 6을 플레이어 List의 Count까지로 바꿔줄것
        {
            Pokemon_Slot[i].SetActive(true);
        }
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

    #endregion
    #region 옵션 관련
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
                    isOption = false;
                    isChange = true;
                    Change_Num = PokemonUI_Num;
                    max_Change_Num = playerData.player_Pokemon.Count;
                    Change_Slot.transform.position = defalut_Change_Slot - (move_Change_Slot * Change_Num);
                    option_obj.SetActive(false);
                    Pokemon_Slot[PokemonUI_Num].SetActive(false);
                    Pokemon_Cursor.SetActive(false);
                    Change_obj.SetActive(true);
                    UpdateChangeUI();
                    //포켓몬 교체
                }
                break;
            case 1:
                {
                    max_Info_Selected_Num = playerData.player_Pokemon.Count;
                    info_Selected_Num = PokemonUI_Num;
                    UpdateInfoUI();
                    option_obj.SetActive(false);
                    Info_obj.SetActive(true);
                    isOption = false;
                    isInfo = true;
                    //포켓몬 상태창 확인으로 넘어가기
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
    #region 인포 관련
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
        Info_Attack.text = string.Format($"공격\n{playerData.player_Pokemon[info_Selected_Num].Attack}");
        Info_SpAttack.text = string.Format($"특수공격\n{playerData.player_Pokemon[info_Selected_Num].SpAttack}");
        Info_Defence.text = string.Format($"{playerData.player_Pokemon[info_Selected_Num].Defence}\n방어");
        Info_SpDefence.text = string.Format($"{playerData.player_Pokemon[info_Selected_Num].SpDefence}\n특수방어");
        Info_Speed.text = string.Format($"{playerData.player_Pokemon[info_Selected_Num].Speed}\n스피드");

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
    #region 체인지 관련
    public void ChangeUPKey()
    {
        if (Change_Num <= 0)
        {
            return;
        }
        Change_Slot.transform.position += move_Change_Slot;
        Change_Num--;
    }
    public void ChangeDownKey()
    {
        if (Change_Num >= max_Change_Num - 1)
        {
            return;
        }
        Change_Slot.transform.position -= move_Change_Slot;
        Change_Num++;
    }
    public void ChangeEnterKey()
    {
        SwapElements<PokemonStats>(playerData.player_Pokemon, Change_Num, PokemonUI_Num);
        ChangeExitKey();
    }
    public void ChangeExitKey()
    {
        Change_obj.SetActive(false);
        Pokemon_Slot[PokemonUI_Num].SetActive(true);
        Pokemon_Cursor.SetActive(true);
        isChange = false;
        isPokemon = true;
        UpdatePokemonUI();
    }
    public void UpdateChangeUI()
    {
        Change_Icon.sprite = playerData.player_Pokemon[PokemonUI_Num].Icon;
        Change_Hp_Bar.value = (float)playerData.player_Pokemon[PokemonUI_Num].Hp / playerData.player_Pokemon[PokemonUI_Num].MaxHp;
        Change_Hp.text = string.Format($"{playerData.player_Pokemon[PokemonUI_Num].Hp}/{playerData.player_Pokemon[PokemonUI_Num].MaxHp}");
        Change_Level.text = string.Format($"Lv.{playerData.player_Pokemon[PokemonUI_Num].Level}");
        Change_Name.text = playerData.player_Pokemon[PokemonUI_Num].Name;
    }
    #endregion

    public void SwapElements<T>(List<T> list, int index1, int index2)
    {
        // 인덱스가 리스트 범위 내에 있는지 확인
        if (index1 < 0 || index1 >= list.Count || index2 < 0 || index2 >= list.Count)
        {
            return; // 유효하지 않은 인덱스면 교환하지 않음
        }

        T temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }
}
