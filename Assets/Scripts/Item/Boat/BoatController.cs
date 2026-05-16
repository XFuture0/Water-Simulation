using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatController : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;
    [SerializeField] private float AngularSpeed = 50f;
    [SerializeField] private float MaxSpeed = 10f;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float ForwardInput = Input.GetKey(KeyCode.W) ? 1f : 0f;
        float AngularInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            AngularInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            AngularInput = 1f;
        }
        if (ForwardInput > 0)
        {
            if(rb.velocity.magnitude < MaxSpeed)
            {
                rb.AddForce(-transform.right * Speed, ForceMode.Force);
            }
        }
        if (AngularInput != 0)
        {
            rb.AddTorque(transform.up * AngularInput * AngularSpeed * Time.fixedDeltaTime, ForceMode.Force);
        }
    }
}
