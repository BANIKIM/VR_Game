using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player_Move_speed_UP : MonoBehaviour
{

    public OnTriggerEnterDeath Left;
    public OnTriggerEnterDeath Right;
    public ContinuousMoveProviderBase Move;


    // Update is called once per frame
    void Update()
    {
        if(Left.katana || Right.katana) // 카타나를 들면 속도업
        {
            Move.moveSpeed = 4;
        }
        else // 카타나를 내려놓으면 속도를 줄임
        {
            Move.moveSpeed = 2;
        }
    }
}
