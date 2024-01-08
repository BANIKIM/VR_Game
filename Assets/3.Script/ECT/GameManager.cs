using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshProUGUI 선언사용

public class GameManager : MonoBehaviour
{
    public GameObject Enemys;
    public bool Gameset = false;
    public TimeManager timeManager;
    public GameObject fog;
    public GameObject end;

    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        Enemys = GameObject.FindGameObjectWithTag("Enemys");
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
            Gameover();
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

        //timeManager.enabled = false;
        //Time.timeScale = 0;
        Endfog();
    }

    public void Endfog()
    {
        fog.SetActive(false);
        end.SetActive(true);
    }
}
