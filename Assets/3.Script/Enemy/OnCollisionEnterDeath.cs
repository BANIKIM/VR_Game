using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterDeath : MonoBehaviour
{
    public string targetTag;
    public Enemy enemy;



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(targetTag))
        {
            enemy.Dead(collision.contacts[0].point);
            //collision.contacts[0].point <- ������ ù��° Point�� �����´�
        }
    }

}
