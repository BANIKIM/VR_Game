using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShoot : MonoBehaviour
{
    public GameObject head;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {
            Destroy(head);
        }
    }
}
