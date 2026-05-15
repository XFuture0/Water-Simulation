using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Buoyant_Object : MonoBehaviour
{
    private Rigidbody rb;
    public Transform SeaFace;
    public float depthforceoffect = 3;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(transform.position.y < SeaFace.position.y)
        {
            float depthforce = Math.Clamp(-(transform.position.y - SeaFace.position.y), 0, 1) * depthforceoffect;
            rb.AddForce(Vector3.up * depthforce, ForceMode.Acceleration);
        }
    }
}
