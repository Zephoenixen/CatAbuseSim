using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handmover : MonoBehaviour
{
    void handtime()
    {
        transform.position = new Vector3(-0.2f, 1.3f, 0);
        while (transform.position.z > -15)
        {
            transform.position += new Vector3(0, 0, -0.4f);
        }
    }
}
