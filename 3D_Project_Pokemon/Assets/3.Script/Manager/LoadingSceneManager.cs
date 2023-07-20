using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public GameObject transitionScreen; // 전환 화면 오브젝트
    public GameObject ballImage; // 흰색 볼 이미지 오브젝트
    public float transitionDuration = 1.0f; // 전환 시간
    public float ballScaleSpeed = 5.0f; // 볼 이미지 줄어드는 속도

    private bool isTransitioning = false;

    public void LoadScene(string sceneName)
    {
        if (!isTransitioning)
        {
            StartCoroutine(Transition(sceneName));
        }
    }

    private IEnumerator Transition(string sceneName)
    {
        isTransitioning = true;

        // 전환 화면을 표시합니다.
        transitionScreen.SetActive(true);

        // 볼 이미지 크기 준비
        ballImage.SetActive(true);
        ballImage.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(0.2f);
        // 다음 씬을 비동기적으로 로드합니다.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false; // 씬 로드를 지연시킵니다.

        float timer = 0f;
        float initialScale = ballImage.transform.localScale.x;

        // 씬 로딩이 완료될 때까지 기다립니다.
        while (!asyncLoad.isDone)
        {
            // 시간에 따라 볼의 크기를 조절합니다.
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / transitionDuration); // 전환 시간에 따른 보간값 (0~1 사이)
            float scale = Mathf.Lerp(initialScale, 0.1f, t);
            ballImage.transform.localScale = Vector3.one * scale;

            if (t >= 1f)
            {
                // 전환 화면을 비활성화하고 변수를 초기화합니다.
                asyncLoad.allowSceneActivation = true;
                transitionScreen.SetActive(false);
                ballImage.SetActive(false);
                ballImage.transform.localScale = Vector3.one * initialScale;
                isTransitioning = false;
            }

            yield return null;
        }
    }
}
