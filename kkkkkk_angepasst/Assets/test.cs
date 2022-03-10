using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Material Mat1;
    public Material Mat2;
    public Material Mat3;
    public Material Mat4;
    public Material Mat5;
    public Material Mat6;
    public Material Mat7;
    public Material Mat8;
    public Material Mat9;
    public Material Mat10;


    SampleMessageListener Listen;
    void Start()
    {
        GameObject Rain = GameObject.Find("RainPrefab");
        Listen = Rain.GetComponent<SampleMessageListener>();
    }

    void Update()
    {

        float Box = Listen.intensity;

        if (Box < 0.1) 
        {
            RenderSettings.skybox = Mat1;
        }

        else if (Box >= 0.1 && Box < 0.2) 
        {
            RenderSettings.skybox = Mat2;
        }

        else if (Box >= 0.2 && Box < 0.3)
        {
            RenderSettings.skybox = Mat3;
        }

        else if (Box >= 0.3 && Box < 0.4)
        {
            RenderSettings.skybox = Mat4;
        }

        else if (Box >= 0.4 && Box < 0.5)
        {
            RenderSettings.skybox = Mat5;
        }

        else if (Box >= 0.5 && Box < 0.6)
        {
            RenderSettings.skybox = Mat6;
        }

        else if (Box >= 0.6 && Box < 0.7)
        {
            RenderSettings.skybox = Mat7;
        }

        else if (Box >= 0.7 && Box < 0.8)
        {
            RenderSettings.skybox = Mat8;
        }

        else if (Box >= 0.8 && Box < 0.9)
        {
            RenderSettings.skybox = Mat9;
        }

        else if (Box >= 0.9)
        {
            RenderSettings.skybox = Mat10;
        }

        else
        {
            //no op
        }

    }
}
