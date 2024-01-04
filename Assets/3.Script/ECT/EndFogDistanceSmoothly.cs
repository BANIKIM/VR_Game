using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFogDistanceSmoothly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogEndDistance = 50;
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.fogEndDistance = Mathf.Lerp(RenderSettings.fogEndDistance, 0, 0.01f);
    }
}
