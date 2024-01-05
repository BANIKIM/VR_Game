using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(transform.gameObject);
        }


        if (collision.gameObject.CompareTag("Gun"))
        {
            Debug.Log("Gun!");
            transform.GetComponent<SphereCollider>().enabled = false;
            transform.GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(transform.gameObject,2f);
        }
    }
}
