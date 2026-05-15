using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatController : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;
    [SerializeField] private float AngularSpeed = 50f;
    [SerializeField] private float maxForwardSpeed = 10f;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float forwardInput = Input.GetKey(KeyCode.W) ? 1f : 0f;
        float turnInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            turnInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            turnInput = 1f;
        }
        if (forwardInput > 0)
        {
            if(rb.velocity.magnitude < maxForwardSpeed)
            {
                rb.AddForce(-transform.right * Speed, ForceMode.Force);
            }
        }
        if (turnInput != 0)
        {
            rb.AddTorque(transform.up * turnInput * AngularSpeed * Time.fixedDeltaTime, ForceMode.Force);
        }
    }
}
