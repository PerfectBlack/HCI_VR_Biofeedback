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
public class LoadingListen : MonoBehaviour
{
    int GSRRaw = 0;
    int GSRLast = 10000;
    public static int GSRHigh;
    public static int GSRLow;

    public void Start()
    {
      


    }




    // Invoked when a line of data is received from the serial device.
    public void OnMessageArrived(string msg)
    {
        GSRRaw = int.Parse(msg);

        

        if(GSRRaw > 50 && GSRRaw < 600)
        {
            if (GSRLast == 10000) {
                GSRLast = GSRRaw;
                GSRHigh = GSRRaw;
                GSRLow = GSRRaw;
            }
            if ((GSRRaw - 5) > GSRLast)
            {
                GSRRaw = GSRLast;
                Debug.Log("Müll");
            }
            
            if(GSRHigh < GSRRaw)
            {
                GSRHigh = GSRRaw;
            }
            if (GSRLow > GSRRaw)
            {
                GSRLow = GSRRaw;
            }

            if (GSRRaw != GSRLast)
            {
                GSRLast = GSRRaw;
            }
                
        }



        Debug.Log("Raw: "+GSRRaw);
        Debug.Log("Last: "+GSRLast);
        Debug.Log("Höchst Stand: " + GSRHigh);
        Debug.Log("Niedrigster Stand: "+ GSRLow);
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
   
}
