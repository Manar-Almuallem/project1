using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookOnPlayer : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 5f; // Add this line to control mouse sensitivity

    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X") * _sensitivity;
        transform.Rotate(0f, _mouseX, 0f); // Yaw (left/right)
    }
}
