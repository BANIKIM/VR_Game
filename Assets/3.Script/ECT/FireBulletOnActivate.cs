using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; //XRGrabInteractable 사용하기 위해서 선언

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet; //총알
    public Transform spawnPoint; // 총알나가는 곳
    public float fireSpeed = 20f; // 총알 속도
    public AudioSource source; //총소리
    public AudioClip Shootclip;
    public AudioClip Clickclip;
    public int bullets = 8;


    private void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }


    public void FireBullet(ActivateEventArgs arg = null)
    {
        if(bullets>0)
        {
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
            Destroy(spawnedBullet, 3);
            source.PlayOneShot(Shootclip);
            bullets--;
        }
        else
        {
            source.PlayOneShot(Clickclip);

        }

    }
}
