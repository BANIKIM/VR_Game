using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingSceneController : MonoBehaviour
{

    static string nextScene;
    [SerializeField] Image progressBar;
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LodingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
        
    }


    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);  // LoadSceneAsync 비동기 방식으로 불러온다
        op.allowSceneActivation = false;

        float timer = 0f;

        while (!op.isDone) // op.isDone 씬로딩이 끝났을때  isDone = 해당동작이 준비되었는지 확인
        {
            yield return null;

            if(op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);

                if(progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

}
