using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShoot : MonoBehaviour
{
    public GameObject head;
    private bool destroy = false;
    private AudioSource audioSource;
    public AudioClip debris;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {
            head.transform.GetComponent<SkinnedMeshRenderer>().enabled = false;
            if(!destroy)
            {
                audioSource.PlayOneShot(debris);
                head.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(head.gameObject.transform.GetChild(0).gameObject, 3f);
                destroy = true;
            }
    

        }
    }
}
