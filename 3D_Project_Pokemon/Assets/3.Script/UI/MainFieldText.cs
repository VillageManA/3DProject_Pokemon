using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainFieldText : MonoBehaviour
{
    [SerializeField] Text Main_Text;
    [SerializeField] GameObject main_obj;
    private bool isWaitingForInput = false;

    private void OnEnable()
    {
        if (PlayerControl.Instance != null)
        {
            if (!PlayerControl.Instance.gameObject.activeSelf)
            {
                PlayerControl.Instance.gameObject.SetActive(true);
            }
        }
    }

    public IEnumerator Text_Play(string str)
    {
        PlayerControl.Instance.GetComponent<PlayerInput>().enabled = false;
        PlayerControl.Instance.GetComponent<Animator>().SetBool("Run",false);
        PlayerControl.Instance.GetComponent<Animator>().SetBool("Move",false);
        main_obj.SetActive(true);
        Main_Text.text = str;
        isWaitingForInput = true;

        yield return new WaitForSeconds(0.1f);

        while (isWaitingForInput) // 스페이스키 입력 대기
        {
            yield return null;
        }

        PlayerControl.Instance.GetComponent<PlayerInput>().enabled = true;
        main_obj.SetActive(false);
    }

    public void TextPlay(string str)
    {
        StartCoroutine(Text_Play(str));
    }
    public void TextPlay(string str, string str2)
    {
        StartCoroutine(Text_Play(str,str2));
    }
    public IEnumerator Text_Play(string str , string str2)
    {
        PlayerControl.Instance.GetComponent<PlayerInput>().enabled = false;
        PlayerControl.Instance.GetComponent<Animator>().SetBool("Run", false);
        PlayerControl.Instance.GetComponent<Animator>().SetBool("Move", false);
        main_obj.SetActive(true);
        Main_Text.text = string.Format($"{str}\n{str2}");
        isWaitingForInput = true;

        yield return new WaitForSeconds(0.1f);

        while (isWaitingForInput) // 스페이스키 입력 대기
        {
            yield return null;
        }

        PlayerControl.Instance.GetComponent<PlayerInput>().enabled = true;
        main_obj.SetActive(false);
    }

    private void Update()
    {
        if (isWaitingForInput && Input.GetKeyDown(KeyCode.Return))
        {
            AudioManager.Instance.PlaySfx(Define.SFX.Click);
            isWaitingForInput = false;
        }
    }
}
