using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Enemys;
    public bool Gameset = false;
    public TimeManager timeManager;


    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
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
            timeManager.enabled = false;
            Time.timeScale = 0;
            Debug.Log("게임 종료");
        }

    }

    public void SetEnemys()
    {
        Enemys = GameObject.FindGameObjectWithTag("Enemys");
    }
}
