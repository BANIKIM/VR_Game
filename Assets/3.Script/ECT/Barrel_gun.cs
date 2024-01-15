using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_gun : MonoBehaviour
{

    public GameObject Gun;
    public Transform spawnPoint; //�� �����ϴ°�
    private bool isgun;
    private float time;
    private int num;

    private void Update()
    {
        time += Time.deltaTime;
    }


    private void OnCollisionStay(Collision collision)
    {
        num = collision.contactCount;//����ִ� ������Ʈ Ȯ�ο�
        if(collision.gameObject.CompareTag("Gun"))
        {
            isgun = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gun") && num.Equals(4))
        {
            isgun = false;

            if (!isgun && time>0.1f )
            {
                GameObject spawnedBullet = Instantiate(Gun);
                spawnedBullet.transform.GetComponent<Rigidbody>().isKinematic = false;
                spawnedBullet.transform.GetComponent<Rigidbody>().useGravity = true;
                spawnedBullet.transform.position = spawnPoint.position;
                time = 0;
            }
        }
    }
}
