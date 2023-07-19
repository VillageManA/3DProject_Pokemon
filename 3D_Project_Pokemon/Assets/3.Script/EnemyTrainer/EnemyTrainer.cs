using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyTrainer : MonoBehaviour
{
    [SerializeField] PokemonStats[] EnemyPokemonList;
    PlayerData playerdata;
    GameObject exclamation_Mark;
    MainFieldText mainFieldText;
    [SerializeField] int EnemyTrainerNum;
    [SerializeField] int[] pokemonLevel;
    [SerializeField] string enemyTrainer_Text1;
    [SerializeField] string enemyTrainer_Text2;
    private void Awake()
    {
        playerdata = FindObjectOfType<PlayerData>();
        mainFieldText = FindObjectOfType<MainFieldText>();
        for(int i=0; i<EnemyPokemonList.Length; i++)
        {
            EnemyPokemonList[i].Level = pokemonLevel[i];
            EnemyPokemonList[i].Setting_LevelStats();

        }

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
        if(other.gameObject.TryGetComponent(out Animator ani))
        {
            ani.SetBool("Run", false);
            ani.SetBool("Move", false);
        }
        if (other.gameObject.TryGetComponent(out PlayerInput playerinput))
        {
            playerinput.enabled = false;
        }
        //exclamation_Mark.SetActive(true);
        //exclamation_Mark.transform.position = gameObject.transform.position + Vector3.up * 2f;
        //exclamation_Mark.transform.LookAt(other.gameObject.transform);
        Debug.Log("´À³¦Ç¥¶¹´Ù");
        yield return new WaitForSeconds(0.2f);
        Debug.Log("´À³¦Ç¥²¨Á³´Ù");
        //exclamation_Mark.SetActive(false);

        while (Vector3.Distance(gameObject.transform.position, other.gameObject.transform.position) > 0.5)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, other.transform.position, 0.05f);
            yield return null;
        }

        yield return StartCoroutine(mainFieldText.Text_Play(enemyTrainer_Text1,enemyTrainer_Text2));
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.EndBattle[EnemyTrainerNum] = true;
        SaveManager.instance.SavePlayerPokemonList(playerdata.player_Pokemon);

        //Ä³½Ì
        EnemyData enemyData = EnemyData.Instance;
        enemyData.SelectedEnemyPokemon = EnemyPokemonList;
        for (int i=0; i< enemyData.SelectedEnemyPokemon.Length; i++)
        {
            enemyData.SelectedEnemyPokemon[i].Hp = enemyData.SelectedEnemyPokemon[i].MaxHp;
        }
        playerinput.enabled = true;
        SceneManager.LoadSceneAsync("Battle");
    }

}
