using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movertransform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z !<= -15)
        {
            transform.position += new Vector3(0, 0, 4f*Time.deltaTime);
        }
    }
}
