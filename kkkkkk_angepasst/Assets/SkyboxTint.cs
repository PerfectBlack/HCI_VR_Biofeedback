using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTint : MonoBehaviour
{

    public Color[] tints = { new Color(133 / 255.0f, 133 / 255.0f, 133 / 255.0f), new Color(155 / 255.0f, 155 / 255.0f, 155 / 255.0f), new Color(175 / 255.0f, 175 / 255.0f, 175 / 255.0f), new Color(200 / 255.0f, 200 / 255.0f, 200 / 255.0f), new Color(235 / 255.0f, 235 / 255.0f, 235 / 255.0f), new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f) };

    Renderer rend;

    [SerializeField] Material skybox;

    SampleMessageListener Listen;
    // Start is called before the first frame update
    void Start()
    {

        GameObject Rain = GameObject.Find("RainPrefab");
        Listen = Rain.GetComponent<SampleMessageListener>();

    }

    // Update is called once per frame
    void Update()
    {
        float Box = Listen.intensityMili;

        

    }
}


