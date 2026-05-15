using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Buoyant_Object : MonoBehaviour
{
    public Rigidbody rb;
    public Transform SeaFace;
    public float depthforceoffect = 3;
    public float BuoyantPointCount = 1;
    public float WaterDrag;
    public float WaterAngular;
    private void Update()
    {
        rb.AddForceAtPosition(Physics.gravity / BuoyantPointCount, transform.position, ForceMode.Acceleration);
        float WaveHeight = SeaFace.position.y + WaveManager.Instance.GetWaveHeight(transform.position.x);
        if(transform.position.y < WaveHeight)
        {
            float depthforce = Math.Clamp(WaveHeight - transform.position.y, 0, 1) * depthforceoffect;
            rb.AddForceAtPosition(new Vector3(0,depthforce, 0), transform.position, ForceMode.Acceleration);
            rb.AddForce(-rb.velocity * depthforce * WaterDrag * Time.deltaTime,ForceMode.VelocityChange);
            rb.AddTorque(-rb.angularVelocity * depthforce * WaterAngular * Time.deltaTime,ForceMode.VelocityChange);
        }
    }
}
