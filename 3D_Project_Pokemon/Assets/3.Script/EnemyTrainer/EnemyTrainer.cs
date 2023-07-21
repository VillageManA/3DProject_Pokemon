using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyTrainer : MonoBehaviour
{
    [SerializeField] PokemonStats[] EnemyPokemonList;
    PlayerData playerdata;
    Animator Enemy_ani;
    [SerializeField] GameObject exclamation_Mark;
    MainFieldText mainFieldText;
    [SerializeField] int EnemyTrainerNum;
    [SerializeField] int[] pokemonLevel;
    [SerializeField] string enemyTrainer_Text1;
    [SerializeField] string enemyTrainer_Text2;
    private void Awake()
    {
        playerdata = FindObjectOfType<PlayerData>();
        mainFieldText = FindObjectOfType<MainFieldText>();
        Enemy_ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.EndBattle[EnemyTrainerNum])
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(Confirm_Player_co(other));
            }
        }
    }

    private IEnumerator Confirm_Player_co(Collider other)
    {
        AudioManager.Instance.PlayBgm("MeetTrainer");
        if (other.gameObject.TryGetComponent(out Animator ani))
        {
            ani.SetBool("Run", false);
            ani.SetBool("Move", false);
        }
        if (other.gameObject.TryGetComponent(out PlayerInput playerinput))
        {
            playerinput.enabled = false;
        }
        exclamation_Mark.SetActive(true);
        exclamation_Mark.transform.position = gameObject.transform.position + Vector3.up * 2f;
        exclamation_Mark.transform.LookAt(other.gameObject.transform);
        exclamation_Mark.transform.Rotate(60,0,0);
        yield return new WaitForSeconds(0.75f);
        exclamation_Mark.SetActive(false);
        Enemy_ani.SetBool("Move", true);

        while (Vector3.Distance(gameObject.transform.position, other.gameObject.transform.position) > 0.5)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, other.transform.position, 0.05f);
            yield return null;
        }

        Enemy_ani.SetBool("Move", false);
        yield return StartCoroutine(mainFieldText.Text_Play(enemyTrainer_Text1,enemyTrainer_Text2));
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.EndBattle[EnemyTrainerNum] = true;
        SaveManager.instance.SavePlayerPokemonList(playerdata.player_Pokemon);

        //Ä³½Ì
        EnemyData.Instance.SelectedEnemyPokemon = EnemyPokemonList;
        for (int i=0; i< EnemyData.Instance.SelectedEnemyPokemon.Length; i++)
        {
            EnemyData.Instance.SelectedEnemyPokemon[i].Level = pokemonLevel[i];
            EnemyData.Instance.SelectedEnemyPokemon[i].Setting_LevelStats();
            EnemyData.Instance.SelectedEnemyPokemon[i].Hp = EnemyData.Instance.SelectedEnemyPokemon[i].MaxHp;
        }
        playerinput.enabled = true;
        SceneManager.LoadSceneAsync("Battle");
    }

}
