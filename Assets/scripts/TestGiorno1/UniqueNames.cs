using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueNames : MonoBehaviour
{
    public string[] tests = new string[] { "moreno", "anna", "davide", "edoardo", "moreno", "davide" };
    

    private void Start()
    {
        PrintUnique(tests);
    }

    void PrintUnique(string[] tests)
    {
        for (int i = 0; i < tests.Length; i++)
        {
            bool duplicate = false;
            for (int x = i+1; x < tests.Length; x++)
            {
                if(tests[i] == tests[x])
                {
                    duplicate = true;
                    break;
                }
            }

            if (!duplicate) Debug.Log(tests[i]);
        }
    }

    void PrintUnique2(string[] tests)
    {
        ArrayList good = new ArrayList();
        foreach (var item in tests)
        {
            if (!good.Contains(item))
            {
                Debug.Log(item);
                good.Add(item);
            }
        }
    }
  
}
