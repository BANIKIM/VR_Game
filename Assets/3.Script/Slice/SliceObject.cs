using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice; //물체를 자르기 위해서 가져온 에셋
using UnityEngine.InputSystem;

public class SliceObject : MonoBehaviour
{
    public Transform planeDebug;
    public GameObject target;
    public bool slice = false; //자를까요?
    public Material crossSectionMaterial;
    public float cutForce = 1500;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(slice)
        {
            Debug.Log("먼데");
            Slice(target);
            slice = false;
        }
    }

    //자른다
    public void Slice(GameObject target)
    {
        SlicedHull hull = target.Slice(planeDebug.position, planeDebug.up);

        if(hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);//CreateUpperHull(자를오브젝트,단면도 머테리얼)
            SetupSlicedComponent(upperHull);
            GameObject loverHull = hull.CreateLowerHull(target, crossSectionMaterial);//자른 밑부분
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
