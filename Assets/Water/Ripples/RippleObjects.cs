using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleObjects : MonoBehaviour
{
    private bool inWater;
    public ParticleSystem particleSystem;
    private void FixedUpdate()
    {
        RaycastHit ray;
        Physics.Raycast(transform.position + Vector3.up * 0.5f, Vector3.down, out ray, 1f, LayerMask.GetMask("Water"));

        if(!ray.collider)
        {
            inWater = false;
        }
        else
        {
            if(inWater) return;
            Debug.Log("Water");
            
            particleSystem.Emit(1);
            inWater = true;
        }
        Debug.DrawRay(transform.position + Vector3.up * 0.5f, Vector3.down, Color.red);
    }
}
