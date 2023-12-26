using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : MonoBehaviour
{
    public GameObject Timemanager;
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {

            Timemanager.gameObject.SetActive(false);
            Debug.Log("¸ÂÀ½");
            Time.timeScale = 0;
        }
    }
}
