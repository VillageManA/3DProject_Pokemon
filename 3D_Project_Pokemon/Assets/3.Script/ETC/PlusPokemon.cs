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


        // Input �÷��װ� false�̸� �Է��� ���� ������ ��ٸ��ϴ�.
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // �� ����Ű�� ������ ���ϸ� ��ȣ�� �����ϵ��� �մϴ�.
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
                // �Ʒ� ����Ű�� ������ ���ϸ� ��ȣ�� �����ϵ��� �մϴ�.
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
                // ���� Ű�� ������ ������ ���ϸ��� �߰��մϴ�.
                AudioManager.Instance.PlaySfx(Define.SFX.Click);
                PlustPokemon_(Pokenum);
                break; // �Է� ó�� �� �ݺ����� �������ɴϴ�.
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                AudioManager.Instance.PlaySfx(Define.SFX.Click);
                // ESC Ű�� ������ ������ ����մϴ�.
                break; // �Է� ó�� �� �ݺ����� �������ɴϴ�.
            }

            yield return null;
        }

        // Input ó���� ���� �Ŀ� ������ �ڵ带 ���⿡ �߰��� �� �ֽ��ϴ�.

        // �Է��� �ٽ� ���� �� �ֵ��� �÷��׸� �ʱ�ȭ�մϴ�.
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
            mainfieldText.TextPlay($"{SettingPokemon[num].Name}��(��) �߰��Ǿ��ܴ�.");
        }
        else
        {
            mainfieldText.TextPlay("���ϸ��� ������ ���� �� ������.");
        }
    }
}
