using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 5f;

    private float _xRotation = 0f; // tracks vertical rotation

    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y") * _sensitivity;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f); // prevent over-rotation

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f); // apply pitch
    }
}



