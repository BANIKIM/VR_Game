using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;// InputActionProperty 사용하기 위해서 선언

public class AnimateHandOnInput : MonoBehaviour
{

    public InputActionProperty pinchAnimationAction; //Activate Value
    public InputActionProperty gripAnimationAction; //Select Value

    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        handAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();//버튼 값을 받아온다.
        handAnimator.SetFloat("Trigger",triggerValue);

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);


    }
}
