using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // NavMeshAgent 사용하기 위해 선언

public class Enemy : MonoBehaviour
{

    private NavMeshAgent agent;
    public Animator animator;
    public Transform playerTarget;
    public Transform playerHead;
    public float stopDistance = 5; // 멈추는 거리
    public FireBulletOnActivate gun;


    private Quaternion localRotationGun;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        SetupRagdoll();

        localRotationGun = gun.spawnPoint.localRotation;
    }

    private void Update()
    {
        agent.SetDestination(playerTarget.position);
        // SetDestination 위치 타겟팅

        //거리 계산
        float distance = Vector3.Distance(playerTarget.position, transform.position);
        if(distance<stopDistance)
        {
            agent.isStopped = true;
            //isStopped 네비메쉬 에이전트 일시정지
            animator.SetBool("Shoot", true);
        }
    }

    //총던지기, 죽을때 총 놓치기
    public void ThrowGun()
    {
        gun.spawnPoint.localRotation = localRotationGun;

        gun.transform.parent = null;
        Rigidbody rb = gun.GetComponent<Rigidbody>();
        rb.velocity = BallisticVelocityVector(gun.transform.position, playerHead.position, 45);
        rb.angularVelocity = Vector3.zero;
    }



    //총던지는 계산식....
    Vector3 BallisticVelocityVector(Vector3 source, Vector3 target, float angle)
    {
        Vector3 direction = target - source;
        float h = direction.y;
        direction.y = 0;
        float distance = direction.magnitude;
        float a = angle * Mathf.Deg2Rad;
        direction.y = distance * Mathf.Tan(a);
        distance += h / Mathf.Tan(a);

        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * direction.normalized;
    }



    public void ShootEnemy()
    {
        Vector3 playerHeadPosition = playerHead.position - Random.Range(0, 0.4f) * Vector3.up;
        gun.spawnPoint.forward = (playerHeadPosition - gun.spawnPoint.position).normalized;
        gun.FireBullet();
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

        foreach (var item in Physics.OverlapSphere(hitPosition,0.3f))
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if(rb)
            {
                rb.AddExplosionForce(1000, hitPosition, 0.3f);
            }
        }

        ThrowGun();
        animator.enabled = false; //애니메이터 비활성화
        agent.enabled = false;//네비메쉬 비활성화
        this.enabled = false;
    }
    
}
