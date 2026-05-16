using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivityX = 2f;
    [SerializeField] private float mouseSensitivityY = 2f;
    [SerializeField] private float maxVerticalAngleY = 90f;
    private float rotationX = 0f; 
    private float rotationY = 0f; 
    private void Update()
    {
        float mouseX = InputManager.Instance.OnGetMouseX();
        float mouseY = InputManager.Instance.OnGetMouseY();
        rotationY += mouseX * mouseSensitivityX; 
        rotationX -= mouseY * mouseSensitivityY; 
        rotationX = Mathf.Clamp(rotationX, -maxVerticalAngleY, maxVerticalAngleY);
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
