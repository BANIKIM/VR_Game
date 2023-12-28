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
        if(Left.katana || Right.katana) // īŸ���� ��� �ӵ���
        {
            Move.moveSpeed = 4;
        }
        else // īŸ���� ���������� �ӵ��� ����
        {
            Move.moveSpeed = 2;
        }
    }
}
