using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshProUGUI 선언사용

public class GameManager : MonoBehaviour
{
    public GameObject Enemys;
    public GameObject GameSet;
    public bool Gameset = false;
    public TimeManager timeManager;



    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        Enemys = GameObject.FindGameObjectWithTag("Enemys");
        GameSet = GameObject.FindGameObjectWithTag("UI");
    }

    private void Update()
    {
        
        bool allEnemiesDead = true;

        for (int i = 0; i < Enemys.transform.childCount; i++)
        {
            if (!Enemys.transform.GetChild(i).GetComponent<Enemy>().Die)
            {
                allEnemiesDead = false;
                break;
            }
        }

        if (allEnemiesDead)
        {
            Gameset = true;
            Invoke("Gameover", 3f);
            Debug.Log("게임 종료");
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
        for (int i = 0; i < GameSet.transform.childCount; i++)
        {
            GameSet.transform.GetChild(i).gameObject.SetActive(true);
        }      
        timeManager.enabled = false;
        Time.timeScale = 0;
    }
}
