using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestControllerInteraction : MonoBehaviour
{
    private bool isGrabbed = false;
    private Vector3 previousControllerPosition;

    private void Update()
    {
        // Check if the primary button (usually the trigger) is pressed
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (!isGrabbed)
            {
                // Pick up the object
                isGrabbed = true;

                // Save the previous controller position
                previousControllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);

                // Parent the object to the controller
                transform.parent = GameObject.Find("RightHandAnchor").transform;
            }
            else
            {
                // Throw the object
                isGrabbed = false;

                // Calculate the throw velocity based on the change in controller position
                Vector3 throwVelocity = (OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch) - previousControllerPosition) / Time.deltaTime;

                // Add force to the object
                GetComponent<Rigidbody>().velocity = throwVelocity;

                // Unparent the object from the controller
                transform.parent = null;
            }
        }
    }
}
