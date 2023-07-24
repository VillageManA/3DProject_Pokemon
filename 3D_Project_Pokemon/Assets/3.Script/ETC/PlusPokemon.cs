using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusPokemon : MonoBehaviour
{
    PlayerData playerData;
    MainFieldText mainfieldText;
    [SerializeField] PokemonStats[] SettingPokemon;
    [SerializeField] GameObject Pokemon_Text_obj;
    [SerializeField] Text[] PokemonName;
    [SerializeField] GameObject Selected_Zone;



    private int Pokenum = 0;
    private bool isOpen = false;

    private Vector3 defalut_Selected_Zone = new Vector3(0, 160, 0);
    private Vector3 move_Selected_Zone = new Vector3(0, -65, 0);

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        mainfieldText = FindObjectOfType<MainFieldText>();
        for (int i = 0; i < SettingPokemon.Length; i++)
        {
            SettingPokemon[i].Level = 5;
            SettingPokemon[i].Setting_LevelStats();
            SettingPokemon[i].Hp = SettingPokemon[i].MaxHp;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (isOpen)
                {
                    return;
                }
                PlayerControl.Instance.GetComponent<PlayerInput>().enabled = false;
                UpdatePlusUI();
                isOpen = true;
                Pokemon_Text_obj.SetActive(true);

                StartCoroutine(WaitForInput());
            }
        }
    }

    private IEnumerator WaitForInput()
    {


        // Input 플래그가 false이면 입력을 받을 때까지 기다립니다.
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // 위 방향키를 누르면 포켓몬 번호가 감소하도록 합니다.
                Pokenum--;
                if (Pokenum < 0)
                {
                    Pokenum = SettingPokemon.Length - 1;
                }
                AudioManager.Instance.PlaySfx(Define.SFX.Move);

                UpdatePlusUI();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // 아래 방향키를 누르면 포켓몬 번호가 증가하도록 합니다.
                Pokenum++;
                if (Pokenum >= SettingPokemon.Length)
                {
                    Pokenum = 0;
                }
                AudioManager.Instance.PlaySfx(Define.SFX.Move);

                UpdatePlusUI();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                // 엔터 키를 누르면 선택한 포켓몬을 추가합니다.
                AudioManager.Instance.PlaySfx(Define.SFX.Click);
                PlustPokemon_(Pokenum);
                break; // 입력 처리 후 반복문을 빠져나옵니다.
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                AudioManager.Instance.PlaySfx(Define.SFX.Click);
                // ESC 키를 누르면 선택을 취소합니다.
                break; // 입력 처리 후 반복문을 빠져나옵니다.
            }

            yield return null;
        }

        // Input 처리가 끝난 후에 실행할 코드를 여기에 추가할 수 있습니다.

        // 입력을 다시 받을 수 있도록 플래그를 초기화합니다.
        isOpen = false;
        Pokemon_Text_obj.SetActive(false);
        PlayerControl.Instance.GetComponent<PlayerInput>().enabled = true;
    }
    public void UpdatePlusUI()
    {
        for (int i = 0; i < SettingPokemon.Length; i++)
        {
            PokemonName[i].text = SettingPokemon[i].Name;
            PokemonName[i].color = Color.black;
        }
        PokemonName[Pokenum].color = Color.white;
        Selected_Zone.transform.localPosition = defalut_Selected_Zone;

        for (int i = 0; i < Pokenum; i++)
        {
            Selected_Zone.transform.position += move_Selected_Zone;
        }
    }
    public void PlustPokemon_(int num)
    {
        if (playerData.player_Pokemon.Count < 6)
        {
            playerData.AddPokemon(SettingPokemon[num]);
            mainfieldText.TextPlay($"{SettingPokemon[num].Name}이(가) 추가되었단다.");
        }
        else
        {
            mainfieldText.TextPlay("포켓몬이 꽉차서 받을 수 없구나.");
        }
    }
}
