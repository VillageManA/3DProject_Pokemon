using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTrainer : MonoBehaviour
{
    [SerializeField] PokemonStats[] EnemyPokemonList;
    PlayerData playerdata;
    GameObject exclamation_Mark;

    private void Awake()
    {
        playerdata = FindObjectOfType<PlayerData>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Confirm_Player_co(other));
        }
    }

    private IEnumerator Confirm_Player_co(Collider other)
    {
        //exclamation_Mark.SetActive(true);
        //exclamation_Mark.transform.position = gameObject.transform.position + Vector3.up * 2f;
        Debug.Log("´À³¦Ç¥¶¹´Ù");
        yield return new WaitForSeconds(0.2f);
        Debug.Log("´À³¦Ç¥²¨Á³´Ù");
        //exclamation_Mark.SetActive(false);

        while (Vector3.Distance(gameObject.transform.position, other.gameObject.transform.position) > 0.5)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, other.transform.position, 0.05f);
            yield return null;
        }

        Debug.Log("ÇÃ·¹ÀÌ¾î Ã£¾Ò´ç");
        yield return new WaitForSeconds(1f);
        //SaveManager.instance.SavePlayerPokemonList(playerdata.player_Pokemon);

        SceneManager.LoadSceneAsync("Battle");
    }

}
