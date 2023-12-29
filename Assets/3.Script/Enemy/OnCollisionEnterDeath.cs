using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterDeath : MonoBehaviour
{
    public string targetTag;
    public Enemy enemy;
    public string Katana = "Katana";


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(targetTag))
        {
            enemy.Dead(collision.contacts[0].point);
            //collision.contacts[0].point <- ������ ù��° Point�� �����´�
        }

        if(collision.gameObject.CompareTag(Katana))
        {
            Debug.Log("īŸ��īŸ��");
            enemy.Dead(collision.contacts[0].point);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Katana))
        {
            Debug.Log("Ʈ����īŸ��īŸ��");
            enemy.Dead(other.transform.position);
        }
    }


}
