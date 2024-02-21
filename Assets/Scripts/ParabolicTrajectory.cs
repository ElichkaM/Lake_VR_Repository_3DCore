using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicTrajectory : MonoBehaviour
{
        [SerializeField] private float throwMultiplier = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("hand"))
        {
            ThrowObject();
        }
    }

    private void ThrowObject()
    {
        // Get the velocity of the controller at the time of collision
        Vector3 controllerVelocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);

        // Calculate throw velocity based on controller velocity
        Vector3 throwVelocity = controllerVelocity.normalized * controllerVelocity.magnitude * throwMultiplier;

        // Apply throw velocity to the object's Rigidbody
        rb.velocity = throwVelocity;
    }

}
