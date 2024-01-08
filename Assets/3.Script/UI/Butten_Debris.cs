using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butten_Debris : MonoBehaviour
{
    public GameObject debris;
    public GameManager gameManager;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Left Hand") || other.gameObject.CompareTag("Right Hand"))
        {
            transform.gameObject.SetActive(false);
            debris.SetActive(true);
            gameManager.Endfog();
        }
    }
}
