using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainFieldText : MonoBehaviour
{
    [SerializeField] Text Main_Text;

    public IEnumerator Text_Play(string str)
    {
        Main_Text.gameObject.SetActive(true);
        Main_Text.text = str;

        while (!Input.GetKeyDown(KeyCode.Space)) // 스페이스키 입력 대기
        {
            yield return null;
        }

        Main_Text.gameObject.SetActive(false);


    }

    public void StartTextCoroutine(string str)
    {
        StartCoroutine(Text_Play(str));
    }
}
