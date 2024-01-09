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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Left Hand") || other.gameObject.CompareTag("Right Hand"))
        {
            transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
            transform.gameObject.GetComponent<BoxCollider>().enabled = false;
            debris.SetActive(true);
            gameManager.Endfog();
        }
    }
}
