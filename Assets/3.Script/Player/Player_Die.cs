using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Die : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("트리거 맞음");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
