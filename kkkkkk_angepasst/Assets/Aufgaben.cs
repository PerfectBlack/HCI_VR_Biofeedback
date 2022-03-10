using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Aufgaben : MonoBehaviour
{
    public TextMeshPro text;
    
    string[] Aufgabe = { "23*32 = ?", "5+5+5+5+5+5+6= ?", "123*321 = ?", "10+2*5/2= ?", "654/34 = ?", "66*6 = ?", "45*3*2 = ?","5+12= ?",  "10+2*5/2= ?", "976431*2 = ?", "9*9+9= ?", "12+32-54+12-17 = ?", "40^2 = ? ", "11+22+33+44+5= ?", "2,349*7 = ?", "23,543*3 = ?" };

    int i = 0;
    int k;
    // Start is called before the first frame update
    void Start()
    {

        text = GetComponent<TextMeshPro>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            i++;

            if (i < 10)
            {
                text.text = Aufgabe[i];
            }
            else if( i>= 15)
            {
                k = i % 15;
                text.text = Aufgabe[k];
            }

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(1);
        }
    }



    
}
