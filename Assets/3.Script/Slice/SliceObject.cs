using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice; //��ü�� �ڸ��� ���ؼ� ������ ����
using UnityEngine.InputSystem;

public class SliceObject : MonoBehaviour
{


    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;
    public Material crossSectionMaterial;
    public float cutForce = 1500;

    private void Start()
    {
        
    }

/*    private void Update()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
            Debug.Log(hasHit);
            GameObject tartget = hit.transform.gameObject;
            Slice(tartget);
        }
    }*/

    private void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if(hasHit)
        {
            
            GameObject tartget = hit.transform.gameObject;
            //tartget.transform.GetComponent<Enemy>().SodeDead();
            
            Slice(tartget, hit.point);
        }
    }

    //�ڸ���
    public void Slice(GameObject target, Vector3 pos)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(pos, planeNormal);
        Debug.Log("Hull��");
        Debug.Log(hull);
        if (hull != null)
        {
            Debug.Log(hull);
            Debug.Log("if��");

            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);//CreateUpperHull(�ڸ�������Ʈ,�ܸ鵵 ���׸���)
            SetupSlicedComponent(upperHull);
            GameObject loverHull = hull.CreateLowerHull(target, crossSectionMaterial);//�ڸ� �غκ�
            SetupSlicedComponent(loverHull);

            Destroy(target);
        }
    }


    public void SetupSlicedComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(cutForce, slicedObject.transform.position,1);
    }
    
}
