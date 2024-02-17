using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicBounce : MonoBehaviour
{
    public float gravity = -9.81f; // Gravity force

    private Rigidbody rb;
    private Vector3 initialPosition;
    private bool isThrown = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void Update()
    {
    }

    void ThrowObject()
    {
        Vector3 throwDirection = (transform.position - initialPosition).normalized;
        rb.velocity = throwDirection * CalculateThrowForce();

        // Apply gravity to the object
        rb.useGravity = true;
        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);

        isThrown = true;
    }

    float CalculateThrowForce()
    {
        // Calculate throw force based on the velocity of the object's Rigidbody component
        return rb.velocity.magnitude;
    }
}

