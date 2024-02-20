using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicTrajectory : MonoBehaviour
{
     private Vector3 initialGrabPosition;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnGrabBegin()
    {
        initialGrabPosition = transform.position;
    }

    private void OnGrabEnd()
    {
        // Calculate trajectory and apply force
        Vector3 releasePosition = transform.position;
        Vector3 throwDirection = releasePosition - initialGrabPosition;

        // Calculate initial velocity based on the release position and initial grab position
        // Use physics calculations to determine the required velocity to follow the parabolic trajectory
        // Apply the calculated velocity as a force to the Rigidbody
        rb.AddForce(throwDirection.normalized * CalculateThrowVelocity(throwDirection), ForceMode.VelocityChange);
    }

    private float CalculateThrowVelocity(Vector3 throwDirection)
    {
        // Implement parabolic trajectory calculation logic here
        // Example: Calculate the required velocity based on the throw direction and distance
        // You may need to adjust this logic based on your specific requirements
        return throwDirection.magnitude * 2f;
    }
}
