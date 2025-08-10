using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup1 : MonoBehaviour
{
    


    void Start()
    {
       
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetButton("Submit"))
            {
                this.gameObject.SetActive(false);
              
            }
        }
    }
}
