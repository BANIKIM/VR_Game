using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butten_Debris : MonoBehaviour
{
    public GameObject debris;
    public Scene_change scene_Change;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Left Hand") || other.gameObject.CompareTag("Right Hand"))
        {
            transform.gameObject.SetActive(false);
            debris.SetActive(true);
            scene_Change.Scene_ch();
        }
    }
}
