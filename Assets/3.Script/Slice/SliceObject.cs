using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice; //��ü�� �ڸ��� ���ؼ� ������ ����
using UnityEngine.InputSystem;

public class SliceObject : MonoBehaviour
{
    public Transform planeDebug;
    public GameObject target;
    public bool slice = false; //�ڸ����?
    public Material crossSectionMaterial;
    public float cutForce = 1500;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(slice)
        {
            Debug.Log("�յ�");
            Slice(target);
            slice = false;
        }
    }

    //�ڸ���
    public void Slice(GameObject target)
    {
        SlicedHull hull = target.Slice(planeDebug.position, planeDebug.up);

        if(hull != null)
        {
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
