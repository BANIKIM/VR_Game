using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super_Hot_sound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip super;
    public AudioClip hot;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Super()
    {
        audioSource.PlayOneShot(super);
    }

    public void Hot()
    {
        audioSource.PlayOneShot(hot);
    }


}
