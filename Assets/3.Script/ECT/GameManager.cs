using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshProUGUI 선언사용
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Enemys;
    public bool Gameset = false;
    public TimeManager timeManager;
    public GameObject fog;
    public GameObject end;
    public GameObject maincamera;
    public GameObject Start_UI;
    public GameObject fogmanager;

    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        Enemys = GameObject.FindGameObjectWithTag("Enemys");
        maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        Start_UI = GameObject.FindGameObjectWithTag("Gameset");
        SetEnemys();
        fogmanager.SetActive(true);
    }


    private void Update()
    {
        
        bool allEnemiesDead = true;

        for (int i = 0; i < Enemys.transform.childCount; i++)
        {
            if (Enemys.transform.GetChild(i).GetComponent<Enemy>() == null)
            {
                if (!Enemys.transform.GetChild(i).GetComponent<Enemy_Lobby>().Die)
                {
                    allEnemiesDead = false;
                    break;
                }
            }
            else
            {
                if (!Enemys.transform.GetChild(i).GetComponent<Enemy>().Die)
                {
                    allEnemiesDead = false;
                    break;
                }
            }

        }

        if (allEnemiesDead)
        {
            Gameset = true;
            maincamera.transform.GetComponent<Animator>().enabled = true;
            Start_UI.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if(RenderSettings.fogEndDistance< 40)
        {
            maincamera.transform.GetComponent<Animator>().enabled = false;
            for (int i = 0; i < maincamera.transform.childCount; i++)
            {
                maincamera.transform.GetChild(i).gameObject.SetActive(false);
            }

        }

        if (RenderSettings.fogEndDistance < 5 && Gameset)
        {
            if(SceneManager.GetActiveScene().name == "Stage1")
            {
                LoadingSceneController.LoadScene("SciFi_Warehouse");
            }
            else if(SceneManager.GetActiveScene().name == "SciFi_Warehouse")
            {
                LoadingSceneController.LoadScene("Stage3");

            }
            else if(SceneManager.GetActiveScene().name == "Stage3")
            {
                LoadingSceneController.LoadScene("Stage4");
            }
            else
            {
                Debug.Log("클리어");
            }

        }
    }

    public void SetEnemys() // 적 캐릭터 활성화
    {
        for (int i = 0; i < Enemys.transform.childCount; i++)
        {
            Enemys.transform.GetChild(i).gameObject.SetActive(true);
        }
    }


    public void Gameover()
    {
        Endfog();
    }

    public void Endfog()
    {
        fog.SetActive(false);
        end.SetActive(true);
    }
}
