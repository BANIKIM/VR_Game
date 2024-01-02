using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterDeath_Lobby : MonoBehaviour
{
    public string targetTag = "Weapon";
    public Enemy_Lobby enemy;
    public string Katana = "Katana";


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(targetTag))
        {
            enemy.Dead(collision.contacts[0].point);
            //collision.contacts[0].point <- 접촉한 첫번째 Point를 가져온다
        }

        if(collision.gameObject.CompareTag(Katana))
        {
            enemy.Dead(collision.contacts[0].point);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Katana))
        {
            enemy.Dead(other.transform.position);
        }
    }


}
