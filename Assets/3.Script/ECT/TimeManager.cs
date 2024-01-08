using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public VelocityEstimator head;
    public VelocityEstimator leftHand;
    public VelocityEstimator rightHand;
    public GameManager gameManager;

    public float sensitivity = 0.8f;
    public float minTimeScale = 0.05f;


    private float initialFixedDeltaTime;


    private void Start()
    {
        initialFixedDeltaTime = Time.fixedDeltaTime;
        gameManager = FindObjectOfType<GameManager>();
    }
    
    private void Update()
    {

       if(!gameManager.Gameset)
        {
            float velocityMagnitude =
                head.GetVelocityEstimate().magnitude +
                leftHand.GetVelocityEstimate().magnitude +
                rightHand.GetVelocityEstimate().magnitude;


            Time.timeScale = Mathf.Clamp01(minTimeScale + velocityMagnitude * sensitivity);
            Time.fixedDeltaTime = initialFixedDeltaTime * Time.timeScale;
        }
       else
        {
            Time.timeScale = 1;
        }

    }

}
