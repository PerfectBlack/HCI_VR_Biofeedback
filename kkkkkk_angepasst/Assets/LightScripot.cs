using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScripot : MonoBehaviour
{

    public Light mylight;

    SampleMessageListener Listen;
    float Lightintensity;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Rain = GameObject.Find("RainPrefab");
        Listen = Rain.GetComponent<SampleMessageListener>();
        mylight = GetComponent<Light>();
        
    }

    // Update is called once per frame
    void Update()
    {

        float Threshhold = Listen.ThreshholdGSR;

        float ProzentGSRint = Listen.Threshholdint;




        Lightintensity = ProzentGSRint/Threshhold;
        if(Lightintensity < 0f) {
            Lightintensity = 0f;

        }
        if (Lightintensity >1f)
        {
            Lightintensity = 1f;

        }

        float RealInt = ( Lightintensity);


        mylight.intensity = RealInt;

        Debug.Log("milliInt: " + RealInt);


    }

}
