using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterDeath : MonoBehaviour
{
    public bool katana = false;

    private void OnTriggerEnter(Collider other)
    {
        OnCollisionEnterDeath death = other.GetComponent<OnCollisionEnterDeath>();

        if (death != null)
        {
            death.enemy.Dead(transform.position);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Katana"))
        {
            katana = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Katana"))
        {
            katana = false;
        }
    }
}
