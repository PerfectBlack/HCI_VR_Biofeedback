/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using System.IO;

/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class SampleMessageListener : MonoBehaviour
{
    [Tooltip("Max BPM")]
    public int MaxBPM = 0;
    [Tooltip("Min BPM")]
    public int MinBPM = 0;
    [Tooltip("Max GSR")]
    private int MaxGSR = LoadingListen.GSRHigh;
    //public int MaxGSR;
    [Tooltip("Min GSR")]
    private int MinGSR = LoadingListen.GSRLow;
    //public int MinGSR;

  

    public int ThreshholdGSR;
    public int Threshholdint;

    string filename;
    int saveSensorBPM;
    int saveSensorGSR;
    string saveTime;
    int inttmp;

    float GSRintensity;
    float GSRintensityMili;

    public float intensityMili = 0;
    public float intensity;

    public void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Teilnehmer Logs/");
        Debug.Log("1");
        filename = "Teilnehmer Logs_" + System.DateTime.Now.Ticks.ToString();
       

    }



   
    // Invoked when a line of data is received from the serial device.
    public void OnMessageArrived(string msg)
    {
        int msgInt = int.Parse(msg);
        
        int SensorBPM = 0;
        int SensorGSR = 0;

        if (msgInt != 0)
        {
            SensorGSR = msgInt;
            inttmp = msgInt;


        }
        if(msgInt == 0)
        {
            SensorGSR = inttmp;
        }
         
        
        

        

        //int[] ArrayBPM = new int[10];

        int[] ArrayGSR = new int[10];
        double[] ArrayGSRMili = new double[100];



        //ArrayBPM[0] = MinBPM;
        ArrayGSR[0] = MaxGSR;
        ArrayGSRMili[0] = MaxGSR;


        //int ThreshholdBPM = MaxBPM - MinBPM;
        ThreshholdGSR = MaxGSR - MinGSR;
        Threshholdint = SensorGSR - MinGSR;

        
        //int StepsBPM = ThreshholdBPM / 10;
        int StepsGSR = ThreshholdGSR / 10;
        double StepsGSRMili = ThreshholdGSR / 100;

        //double BPMintensity = 0 ;
        



        /*   for (int i= 0; i < 9; i++)
           {
               ArrayBPM[i + 1] = ArrayBPM[i] + StepsBPM;
           }
   */

        for (int j = 0; j < 9; j++)
        {
            ArrayGSR[j + 1] = ArrayGSR[j] - StepsGSR;
        }
        for (int o = 0; o < 99; o++)
        {
           ArrayGSRMili[o + 1] = ArrayGSRMili[o] - StepsGSRMili;
        }


        /*
                    if (SensorBPM < ArrayBPM[1]) 
                    { BPMintensity = 0; }
                    else if (ArrayBPM[1] < SensorBPM && ArrayBPM[2] > SensorBPM)
                    { BPMintensity = 0.1; }
                    else if (ArrayBPM[2] < SensorBPM && ArrayBPM[3] > SensorBPM)
                    { BPMintensity = 0.2; }
                    else if (ArrayBPM[3] < SensorBPM && ArrayBPM[4] > SensorBPM)
                    { BPMintensity = 0.3; }
                    else if (ArrayBPM[4] < SensorBPM && ArrayBPM[5] > SensorBPM)
                    { BPMintensity = 0.4; }
                    else if (ArrayBPM[5] < SensorBPM && ArrayBPM[6] > SensorBPM)
                    { BPMintensity = 0.55; }
                    else if (ArrayBPM[6] < SensorBPM && ArrayBPM[7] > SensorBPM)
                    { BPMintensity = 0.7; }
                    else if (ArrayBPM[7] < SensorBPM && ArrayBPM[8] > SensorBPM)
                    { BPMintensity = 0.8; }
                    else if (ArrayBPM[8] < SensorBPM && ArrayBPM[9] > SensorBPM)
                    { BPMintensity = 0.9; }
                    else if (ArrayBPM[9] < SensorBPM )
                    { BPMintensity = 1; }
                    else
                    {
                        // no op
                    }

    */

        if (SensorGSR > ArrayGSR[1])
        { GSRintensity = 0f; }
        else if (ArrayGSR[1] > SensorGSR && ArrayGSR[2] < SensorGSR)
        { GSRintensity = 0.2f; }
        else if (ArrayGSR[2] > SensorGSR && ArrayGSR[3] < SensorGSR)
        { GSRintensity = 0.3f; }
        else if (ArrayGSR[3] > SensorGSR && ArrayGSR[4] < SensorGSR)
        { GSRintensity = 0.4f; }
        else if (ArrayGSR[4] > SensorGSR && ArrayGSR[5] < SensorGSR)
        { GSRintensity = 0.5f; }
        else if (ArrayGSR[5] > SensorGSR && ArrayGSR[6] < SensorGSR)
        { GSRintensity = 0.6f; }
        else if (ArrayGSR[6] > SensorGSR && ArrayGSR[7] < SensorGSR)
        { GSRintensity = 0.7f; }
        else if (ArrayGSR[7] > SensorGSR && ArrayGSR[8] < SensorGSR)
        { GSRintensity = 0.8f; }
        else if (ArrayGSR[8] > SensorGSR && ArrayGSR[9] < SensorGSR)
        { GSRintensity = 0.9f; }
        else if (ArrayGSR[9] > SensorGSR)
        { GSRintensity = 1f; }
        else
        {
            // no op
        }


        if (SensorGSR > ArrayGSRMili[1])
        {
            GSRintensityMili = 0f;
        }
        else if (ArrayGSRMili[1] > SensorGSR && ArrayGSRMili[2] < SensorGSR)
        { GSRintensityMili = 0.01f; }
        else if (ArrayGSRMili[2] > SensorGSR && ArrayGSRMili[3] < SensorGSR)
        { GSRintensityMili = 0.02f; }
        else if (ArrayGSRMili[3] > SensorGSR && ArrayGSRMili[4] < SensorGSR)
        { GSRintensityMili = 0.03f; }
        else if (ArrayGSRMili[4] > SensorGSR && ArrayGSRMili[5] < SensorGSR)
        { GSRintensityMili = 0.04f; }
        else if (ArrayGSRMili[5] > SensorGSR && ArrayGSRMili[6] < SensorGSR)
        { GSRintensityMili = 0.05f; }
        else if (ArrayGSRMili[6] > SensorGSR && ArrayGSRMili[7] < SensorGSR)
        { GSRintensityMili = 0.06f; }
        else if (ArrayGSRMili[7] > SensorGSR && ArrayGSRMili[8] < SensorGSR)
        { GSRintensityMili = 0.07f; }
        else if (ArrayGSRMili[8] > SensorGSR && ArrayGSRMili[9] < SensorGSR)
        { GSRintensityMili = 0.08f; }
        else if (ArrayGSRMili[9] > SensorGSR && ArrayGSRMili[10] < SensorGSR)
        { GSRintensityMili = 0.09f; }
        else if (ArrayGSRMili[10] > SensorGSR && ArrayGSRMili[11] < SensorGSR)
        { GSRintensityMili = 0.10f; }
        else if (ArrayGSRMili[11] > SensorGSR && ArrayGSRMili[12] < SensorGSR)
        { GSRintensityMili = 0.11f; }
        else if (ArrayGSRMili[12] > SensorGSR && ArrayGSRMili[13] < SensorGSR)
        { GSRintensityMili = 0.12f; }
        else if (ArrayGSRMili[13] > SensorGSR && ArrayGSRMili[14] < SensorGSR)
        { GSRintensityMili = 0.13f; }
        else if (ArrayGSRMili[14] > SensorGSR && ArrayGSRMili[15] < SensorGSR)
        { GSRintensityMili = 0.14f; }
        else if (ArrayGSRMili[15] > SensorGSR && ArrayGSRMili[16] < SensorGSR)
        { GSRintensityMili = 0.15f; }
        else if (ArrayGSRMili[16] > SensorGSR && ArrayGSRMili[17] < SensorGSR)
        { GSRintensityMili = 0.16f; }
        else if (ArrayGSRMili[17] > SensorGSR && ArrayGSRMili[18] < SensorGSR)
        { GSRintensityMili = 0.17f; }
        else if (ArrayGSRMili[18] > SensorGSR && ArrayGSRMili[19] < SensorGSR)
        { GSRintensityMili = 0.18f; }
        else if (ArrayGSRMili[19] > SensorGSR && ArrayGSRMili[20] < SensorGSR)
        { GSRintensityMili = 0.19f; }
        else if (ArrayGSRMili[20] > SensorGSR && ArrayGSRMili[21] < SensorGSR)
        { GSRintensityMili = 0.20f; }
        else if (ArrayGSRMili[21] > SensorGSR && ArrayGSRMili[22] < SensorGSR)
        { GSRintensityMili = 0.21f; }
        else if (ArrayGSRMili[22] > SensorGSR && ArrayGSRMili[23] < SensorGSR)
        { GSRintensityMili = 0.22f; }
        else if (ArrayGSRMili[23] > SensorGSR && ArrayGSRMili[24] < SensorGSR)
        { GSRintensityMili = 0.23f; }
        else if (ArrayGSRMili[24] > SensorGSR && ArrayGSRMili[25] < SensorGSR)
        { GSRintensityMili = 0.24f; }
        else if (ArrayGSRMili[25] > SensorGSR && ArrayGSRMili[26] < SensorGSR)
        { GSRintensityMili = 0.25f; }
        else if (ArrayGSRMili[26] > SensorGSR && ArrayGSRMili[27] < SensorGSR)
        { GSRintensityMili = 0.26f; }
        else if (ArrayGSRMili[27] > SensorGSR && ArrayGSRMili[28] < SensorGSR)
        { GSRintensityMili = 0.27f; }
        else if (ArrayGSRMili[28] > SensorGSR && ArrayGSRMili[29] < SensorGSR)
        { GSRintensityMili = 0.28f; }
        else if (ArrayGSRMili[29] > SensorGSR && ArrayGSRMili[30] < SensorGSR)
        { GSRintensityMili = 0.29f; }
        else if (ArrayGSRMili[30] > SensorGSR && ArrayGSRMili[31] < SensorGSR)
        { GSRintensityMili = 0.30f; }
        else if (ArrayGSRMili[31] > SensorGSR && ArrayGSRMili[32] < SensorGSR)
        { GSRintensityMili = 0.31f; }
        else if (ArrayGSRMili[32] > SensorGSR && ArrayGSRMili[33] < SensorGSR)
        { GSRintensityMili = 0.32f; }
        else if (ArrayGSRMili[33] > SensorGSR && ArrayGSRMili[34] < SensorGSR)
        { GSRintensityMili = 0.33f; }
        else if (ArrayGSRMili[34] > SensorGSR && ArrayGSRMili[35] < SensorGSR)
        { GSRintensityMili = 0.34f; }
        else if (ArrayGSRMili[35] > SensorGSR && ArrayGSRMili[36] < SensorGSR)
        { GSRintensityMili = 0.35f; }
        else if (ArrayGSRMili[36] > SensorGSR && ArrayGSRMili[37] < SensorGSR)
        { GSRintensityMili = 0.36f; }
        else if (ArrayGSRMili[37] > SensorGSR && ArrayGSRMili[38] < SensorGSR)
        { GSRintensityMili = 0.37f; }
        else if (ArrayGSRMili[38] > SensorGSR && ArrayGSRMili[39] < SensorGSR)
        { GSRintensityMili = 0.38f; }
        else if (ArrayGSRMili[39] > SensorGSR && ArrayGSRMili[40] < SensorGSR)
        { GSRintensityMili = 0.39f; }
        else if (ArrayGSRMili[40] > SensorGSR && ArrayGSRMili[41] < SensorGSR)
        { GSRintensityMili = 0.40f; }
        else if (ArrayGSRMili[41] > SensorGSR && ArrayGSRMili[42] < SensorGSR)
        { GSRintensityMili = 0.41f; }
        else if (ArrayGSRMili[42] > SensorGSR && ArrayGSRMili[43] < SensorGSR)
        { GSRintensityMili = 0.42f; }
        else if (ArrayGSRMili[43] > SensorGSR && ArrayGSRMili[44] < SensorGSR)
        { GSRintensityMili = 0.43f; }
        else if (ArrayGSRMili[44] > SensorGSR && ArrayGSRMili[45] < SensorGSR)
        { GSRintensityMili = 0.44f; }
        else if (ArrayGSRMili[45] > SensorGSR && ArrayGSRMili[46] < SensorGSR)
        { GSRintensityMili = 0.45f; }
        else if (ArrayGSRMili[46] > SensorGSR && ArrayGSRMili[47] < SensorGSR)
        { GSRintensityMili = 0.46f; }
        else if (ArrayGSRMili[47] > SensorGSR && ArrayGSRMili[48] < SensorGSR)
        { GSRintensityMili = 0.47f; }
        else if (ArrayGSRMili[48] > SensorGSR && ArrayGSRMili[49] < SensorGSR)
        { GSRintensityMili = 0.48f; }
        else if (ArrayGSRMili[49] > SensorGSR && ArrayGSRMili[50] < SensorGSR)
        { GSRintensityMili = 0.49f; }
        else if (ArrayGSRMili[50] > SensorGSR && ArrayGSRMili[51] < SensorGSR)
        { GSRintensityMili = 0.50f; }
        else if (ArrayGSRMili[51] > SensorGSR && ArrayGSRMili[52] < SensorGSR)
        { GSRintensityMili = 0.51f; }
        else if (ArrayGSRMili[52] > SensorGSR && ArrayGSRMili[53] < SensorGSR)
        { GSRintensityMili = 0.52f; }
        else if (ArrayGSRMili[53] > SensorGSR && ArrayGSRMili[54] < SensorGSR)
        { GSRintensityMili = 0.53f; }
        else if (ArrayGSRMili[54] > SensorGSR && ArrayGSRMili[55] < SensorGSR)
        { GSRintensityMili = 0.54f; }
        else if (ArrayGSRMili[55] > SensorGSR && ArrayGSRMili[56] < SensorGSR)
        { GSRintensityMili = 0.55f; }
        else if (ArrayGSRMili[56] > SensorGSR && ArrayGSRMili[57] < SensorGSR)
        { GSRintensityMili = 0.56f; }
        else if (ArrayGSRMili[57] > SensorGSR && ArrayGSRMili[58] < SensorGSR)
        { GSRintensityMili = 0.57f; }
        else if (ArrayGSRMili[58] > SensorGSR && ArrayGSRMili[59] < SensorGSR)
        { GSRintensityMili = 0.58f; }
        else if (ArrayGSRMili[59] > SensorGSR && ArrayGSRMili[60] < SensorGSR)
        { GSRintensityMili = 0.59f; }
        else if (ArrayGSRMili[60] > SensorGSR && ArrayGSRMili[61] < SensorGSR)
        { GSRintensityMili = 0.60f; }
        else if (ArrayGSRMili[61] > SensorGSR && ArrayGSRMili[62] < SensorGSR)
        { GSRintensityMili = 0.61f; }
        else if (ArrayGSRMili[62] > SensorGSR && ArrayGSRMili[63] < SensorGSR)
        { GSRintensityMili = 0.62f; }
        else if (ArrayGSRMili[63] > SensorGSR && ArrayGSRMili[64] < SensorGSR)
        { GSRintensityMili = 0.63f; }
        else if (ArrayGSRMili[64] > SensorGSR && ArrayGSRMili[65] < SensorGSR)
        { GSRintensityMili = 0.64f; }
        else if (ArrayGSRMili[65] > SensorGSR && ArrayGSRMili[66] < SensorGSR)
        { GSRintensityMili = 0.65f; }
        else if (ArrayGSRMili[66] > SensorGSR && ArrayGSRMili[67] < SensorGSR)
        { GSRintensityMili = 0.66f; }
        else if (ArrayGSRMili[67] > SensorGSR && ArrayGSRMili[68] < SensorGSR)
        { GSRintensityMili = 0.67f; }
        else if (ArrayGSRMili[68] > SensorGSR && ArrayGSRMili[69] < SensorGSR)
        { GSRintensityMili = 0.68f; }
        else if (ArrayGSRMili[69] > SensorGSR && ArrayGSRMili[70] < SensorGSR)
        { GSRintensityMili = 0.69f; }
        else if (ArrayGSRMili[70] > SensorGSR && ArrayGSRMili[71] < SensorGSR)
        { GSRintensityMili = 0.70f; }
        else if (ArrayGSRMili[71] > SensorGSR && ArrayGSRMili[72] < SensorGSR)
        { GSRintensityMili = 0.71f; }
        else if (ArrayGSRMili[72] > SensorGSR && ArrayGSRMili[73] < SensorGSR)
        { GSRintensityMili = 0.72f; }
        else if (ArrayGSRMili[73] > SensorGSR && ArrayGSRMili[74] < SensorGSR)
        { GSRintensityMili = 0.73f; }
        else if (ArrayGSRMili[74] > SensorGSR && ArrayGSRMili[75] < SensorGSR)
        { GSRintensityMili = 0.74f; }
        else if (ArrayGSRMili[75] > SensorGSR && ArrayGSRMili[76] < SensorGSR)
        { GSRintensityMili = 0.75f; }
        else if (ArrayGSRMili[76] > SensorGSR && ArrayGSRMili[77] < SensorGSR)
        { GSRintensityMili = 0.76f; }
        else if (ArrayGSRMili[77] > SensorGSR && ArrayGSRMili[78] < SensorGSR)
        { GSRintensityMili = 0.77f; }
        else if (ArrayGSRMili[78] > SensorGSR && ArrayGSRMili[79] < SensorGSR)
        { GSRintensityMili = 0.78f; }
        else if (ArrayGSRMili[79] > SensorGSR && ArrayGSRMili[80] < SensorGSR)
        { GSRintensityMili = 0.79f; }
        else if (ArrayGSRMili[80] > SensorGSR && ArrayGSRMili[81] < SensorGSR)
        { GSRintensityMili = 0.80f; }
        else if (ArrayGSRMili[81] > SensorGSR && ArrayGSRMili[82] < SensorGSR)
        { GSRintensityMili = 0.81f; }
        else if (ArrayGSRMili[82] > SensorGSR && ArrayGSRMili[83] < SensorGSR)
        { GSRintensityMili = 0.82f; }
        else if (ArrayGSRMili[83] > SensorGSR && ArrayGSRMili[84] < SensorGSR)
        { GSRintensityMili = 0.83f; }
        else if (ArrayGSRMili[84] > SensorGSR && ArrayGSRMili[85] < SensorGSR)
        { GSRintensityMili = 0.84f; }
        else if (ArrayGSRMili[85] > SensorGSR && ArrayGSRMili[86] < SensorGSR)
        { GSRintensityMili = 0.85f; }
        else if (ArrayGSRMili[86] > SensorGSR && ArrayGSRMili[87] < SensorGSR)
        { GSRintensityMili = 0.86f; }
        else if (ArrayGSRMili[87] > SensorGSR && ArrayGSRMili[88] < SensorGSR)
        { GSRintensityMili = 0.87f; }
        else if (ArrayGSRMili[88] > SensorGSR && ArrayGSRMili[89] < SensorGSR)
        { GSRintensityMili = 0.88f; }
        else if (ArrayGSRMili[89] > SensorGSR && ArrayGSRMili[90] < SensorGSR)
        { GSRintensityMili = 0.89f; }
        else if (ArrayGSRMili[90] > SensorGSR && ArrayGSRMili[91] < SensorGSR)
        { GSRintensityMili = 0.90f; }
        else if (ArrayGSRMili[91] > SensorGSR && ArrayGSRMili[92] < SensorGSR)
        { GSRintensityMili = 0.91f; }
        else if (ArrayGSRMili[92] > SensorGSR && ArrayGSRMili[93] < SensorGSR)
        { GSRintensityMili = 0.92f; }
        else if (ArrayGSRMili[93] > SensorGSR && ArrayGSRMili[94] < SensorGSR)
        { GSRintensityMili = 0.93f; }
        else if (ArrayGSRMili[94] > SensorGSR && ArrayGSRMili[95] < SensorGSR)
        { GSRintensityMili = 0.94f; }
        else if (ArrayGSRMili[95] > SensorGSR && ArrayGSRMili[96] < SensorGSR)
        { GSRintensityMili = 0.95f; }
        else if (ArrayGSRMili[96] > SensorGSR && ArrayGSRMili[97] < SensorGSR)
        { GSRintensityMili = 0.96f; }
        else if (ArrayGSRMili[97] > SensorGSR && ArrayGSRMili[98] < SensorGSR)
        { GSRintensityMili = 0.97f; }
        else if (ArrayGSRMili[98] > SensorGSR && ArrayGSRMili[99] < SensorGSR)
        { GSRintensityMili = 0.98f; }
        else if (ArrayGSRMili[99] > SensorGSR)
        { GSRintensityMili = 1f; }
        else
        {
            //no op
        }



        intensity = GSRintensity;
        intensityMili = GSRintensityMili;
        Debug.Log("Intensity Mili: "+intensityMili);
        //  intensity = (float)((BPMintensity + GSRintensity) / 2);

        //  intensity = (float.Parse(msg))/100;

        for (int j = 0; j < 9; j++)
        {
            Debug.Log(ArrayGSR[j]);
        }

        Debug.Log("SensorGSR: " + SensorGSR);


        Debug.Log("Message arrived: " + GSRintensity);

        Time();

        Debug.Log("2");

        saveSensorGSR = SensorGSR;
        saveSensorBPM = SensorBPM;
        CreateTextFile();
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
    public void CreateTextFile()
    {
        Debug.Log("3");
        string path = Application.streamingAssetsPath + "/Teilnehmer Logs/" + filename + ".csv";

        File.AppendAllText(path, saveTime + "," + saveSensorGSR + "," + saveSensorBPM + "\n");

        Debug.Log("4");

    }
    public void Time()
    {
        string hours;                                                                                                       
        string minutes;
        string seconds;

        hours = System.DateTime.Now.Hour.ToString();
       minutes = System.DateTime.Now.Minute.ToString();
        seconds = System.DateTime.Now.Second.ToString();

        saveTime = hours + ":" + minutes + ":" + seconds;
    }
}
