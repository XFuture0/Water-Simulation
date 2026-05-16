using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Buoyant_Object : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform SeaFace;
    [SerializeField] private float depthforceoffect = 3;
    [SerializeField] private float BuoyantPointCount = 1;
    [SerializeField] private float WaterDrag;
    [SerializeField] private float WaterAngular;
    private void Update()
    {
        rb.AddForceAtPosition(Physics.gravity / BuoyantPointCount, transform.position, ForceMode.Acceleration);
        float WaveHeight = SeaFace.position.y + WaveManager.Instance.GetWaveHeight(new Vector2(transform.position.x, transform.position.z));
        if(transform.position.y < WaveHeight)
        {
            float depthforce = Math.Clamp(WaveHeight - transform.position.y, 0, 1) * depthforceoffect;
            rb.AddForceAtPosition(new Vector3(0,depthforce, 0), transform.position, ForceMode.Acceleration);
            rb.AddForce(-rb.velocity * depthforce * WaterDrag * Time.deltaTime,ForceMode.VelocityChange);
            rb.AddTorque(-rb.angularVelocity * depthforce * WaterAngular * Time.deltaTime,ForceMode.VelocityChange);
        }
    }
}
