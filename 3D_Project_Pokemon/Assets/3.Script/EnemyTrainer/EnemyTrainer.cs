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

    private void Awake()
    {
        playerdata = FindObjectOfType<PlayerData>();
        mainFieldText = FindObjectOfType<MainFieldText>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.EndBattle)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(Confirm_Player_co(other));
            }
        }
    }

    private IEnumerator Confirm_Player_co(Collider other)
    {
        other.GetComponent<PlayerInput>().enabled = false;
        other.GetComponent<Animator>().SetBool("Run", false);
        other.GetComponent<Animator>().SetBool("Move", false);
        //exclamation_Mark.SetActive(true);
        //exclamation_Mark.transform.position = gameObject.transform.position + Vector3.up * 2f;
        //exclamation_Mark.transform.LookAt(other.gameObject.transform);
        Debug.Log("느낌표떴다");
        yield return new WaitForSeconds(0.2f);
        Debug.Log("느낌표꺼졌다");
        //exclamation_Mark.SetActive(false);

        while (Vector3.Distance(gameObject.transform.position, other.gameObject.transform.position) > 0.5)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, other.transform.position, 0.05f);
            yield return null;
        }

        yield return StartCoroutine(mainFieldText.Text_Play("포켓몬 세계에선 마주치면 \n배틀을 하는게 섭리야!"));
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.EndBattle = true;
        SaveManager.instance.SavePlayerPokemonList(playerdata.player_Pokemon);
        EnemyData.Instance.SelectedEnemyPokemon = EnemyPokemonList;
        other.GetComponent<PlayerInput>().enabled = true;
        SceneManager.LoadSceneAsync("Battle");
    }

}
