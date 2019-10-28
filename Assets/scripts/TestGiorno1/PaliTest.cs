using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaliTest : MonoBehaviour
{
    private void Start()
    {
        TestPaly();
    }

    public void TestPaly()
    {
        string[] osso = new string[4];
        osso[0] = "o";
        osso[1] = "s";
        osso[2] = "s";
        osso[3] = "o";

        string Ossoresult = osso[0] + osso[1] + osso[2] + osso[3];
        string Ossoreverse = osso[3] + osso[2] + osso[1] + osso[0];

        string[] boh = new string[3];
        boh[0] = "b";
        boh[1] = "o";
        boh[2] = "h";

        for (int i = 0; i < osso[3].Length; i++)
        { 
            Debug.Log(Ossoresult);
        }

        for (int i = osso[0].Length; i >= 0; i--)
        {
            Debug.Log(Ossoreverse);
        }

        if (Ossoresult == Ossoreverse)
        {
            Debug.Log("è palindromo");
        }
        else if(Ossoresult != Ossoreverse)
        {
            Debug.Log("non è palindromo");
        }

        
    }
}
