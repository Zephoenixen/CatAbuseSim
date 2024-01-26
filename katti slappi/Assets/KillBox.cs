using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Kats")) 
        {
            killPlayer();
        }
    }

    void killPlayer()
    {
        
    }
}
