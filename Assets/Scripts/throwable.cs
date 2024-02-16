using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwable : MonoBehaviour
{

    List<Vector3> trackingPos = new List<Vector3>();
    public float velocity = 1000f;

    bool pickedUp = false;
    GameObject parentHand;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp == true)
        {
            rb.useGravity = false;

            transform.position = parentHand.transform.position; //match parent
            transform.rotation = parentHand.transform.rotation;

            if (trackingPos.Count > 15) //delete the oldest tracked position
            {
                trackingPos.RemoveAt(0);

            } 
            trackingPos.Add(transform.position); //and the current position
            float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
            
            if (triggerRight < 0.1f) //have we released the trigger 
            {
                pickedUp = false; //Let GO!!
                Vector3 direction = trackingPos[trackingPos.Count - 1] - trackingPos[0];
                rb.AddForce(direction * velocity);
                rb.useGravity = true;
                rb.isKinematic = false;
                GetComponent<Collider>().isTrigger = false;
                

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        float triggerRight = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        if (other.gameObject.tag == "hand" && triggerRight > 0.9f)
        {
            pickedUp = true;
            parentHand = other.gameObject; //set parent object instead 

        }
    }
}
