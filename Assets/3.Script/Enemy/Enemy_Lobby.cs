using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lobby : MonoBehaviour
{


    public Animator animator;
    public bool Die = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SetupRagdoll();
    }

    private void Update()
    {
        if(Die)
        {
            Dead(transform.position);
        }
    }

    public void SetupRagdoll()
    {
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = true;
        }
    }

    public void Dead(Vector3 hitPosition)
    {
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.isKinematic = false;
        }

        foreach (var item in Physics.OverlapSphere(hitPosition, 0.3f))
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(1000, hitPosition, 0.3f);
            }
        }

        animator.enabled = false; //애니메이터 비활성화
        Die = true;
        this.enabled = false;
    }
}
