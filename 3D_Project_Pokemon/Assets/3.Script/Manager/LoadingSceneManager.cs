using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public GameObject transitionScreen; // ��ȯ ȭ�� ������Ʈ
    public GameObject ballImage; // ��� �� �̹��� ������Ʈ
    public float transitionDuration = 1.0f; // ��ȯ �ð�
    public float ballScaleSpeed = 5.0f; // �� �̹��� �پ��� �ӵ�

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

        // ��ȯ ȭ���� ǥ���մϴ�.
        transitionScreen.SetActive(true);

        // �� �̹��� ũ�� �غ�
        ballImage.SetActive(true);
        ballImage.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(0.2f);
        // ���� ���� �񵿱������� �ε��մϴ�.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false; // �� �ε带 ������ŵ�ϴ�.

        float timer = 0f;
        float initialScale = ballImage.transform.localScale.x;

        // �� �ε��� �Ϸ�� ������ ��ٸ��ϴ�.
        while (!asyncLoad.isDone)
        {
            // �ð��� ���� ���� ũ�⸦ �����մϴ�.
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / transitionDuration); // ��ȯ �ð��� ���� ������ (0~1 ����)
            float scale = Mathf.Lerp(initialScale, 0.1f, t);
            ballImage.transform.localScale = Vector3.one * scale;

            if (t >= 1f)
            {
                // ��ȯ ȭ���� ��Ȱ��ȭ�ϰ� ������ �ʱ�ȭ�մϴ�.
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
