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

    void ThrowObject(Vector3 throwDirection)
    {
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

    void OnCollisionEnter(Collision collision)
    {
        if (isThrown)
        {
            // Calculate the reflection direction for the object to follow a parabolic path
            Vector3 reflectionDirection = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            rb.velocity = reflectionDirection * CalculateThrowForce();
        }
    }
}

