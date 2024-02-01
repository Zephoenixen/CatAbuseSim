using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handmover : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.z <= -10f)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
        }
    }
    void Handtime()
    {
        transform.position += new Vector3(0, -20, 0);

        Debug.Log("hands");
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(0,0,-4);

            
        
    }
}
    
