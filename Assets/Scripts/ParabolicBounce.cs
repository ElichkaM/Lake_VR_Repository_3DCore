using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicBounce : MonoBehaviour
{
Vector3 gravity = new Vector3 (0, 9.8f, 0);
Vector3 velocity = new Vector3 (5, 15, 7);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update velocity via Newtons law
    velocity += gravity * Time.deltaTime;
   
     // Update position
     transform.position += velocity * Time.deltaTime;
    }
}
