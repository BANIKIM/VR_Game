using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; //XRGrabInteractable ����ϱ� ���ؼ� ����

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet; //�Ѿ�
    public Transform spawnPoint; // �Ѿ˳����� ��
    public float fireSpeed = 20f; // �Ѿ� �ӵ�


    private void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }


    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 5);
    }
}
