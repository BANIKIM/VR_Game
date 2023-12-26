using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Die : MonoBehaviour
{
    public GameObject Timemanager;
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {

            Debug.Log("����");
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Ʈ���� ����");

            SceneManager.LoadScene(1);
        }
    }
}
