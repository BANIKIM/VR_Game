using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShoot : MonoBehaviour
{
    public GameObject head;
    private bool destroy = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {
            head.transform.GetComponent<SkinnedMeshRenderer>().enabled = false;
            if(!destroy)
            {
                head.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(head.gameObject.transform.GetChild(0).gameObject, 3f);
                destroy = true;
            }
    

        }
    }
}
