using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] rmObjects = GameObject.FindGameObjectsWithTag("RM");

        foreach (GameObject obj in rmObjects)
        {
            obj.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
