using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkbox : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(transform.position.x == -9)
        {
            SendMessageUpwards("Posreset", -9f);
        }
        else if (transform.position.x == -3)
        {
            SendMessageUpwards("Posreset", -3f);
        }
        else if (transform.position.x == 3)
        {
            SendMessageUpwards("Posreset", 3f);
        }
        else if (transform.position.x == 9)
        {
            SendMessageUpwards("Posreset", 9f);
        }
        if (collision.gameObject.CompareTag("Fernando")) 
        { 
            SendMessageUpwards("Katreset", 1f);
        }
        else if (collision.gameObject.CompareTag("Ost"))
        {
            SendMessageUpwards("Katreset", 2f);
        }
        else if (collision.gameObject.CompareTag("Patooty"))
        {
            SendMessageUpwards("Katreset", 3f);
        }
        else if (collision.gameObject.CompareTag("Kattemad"))
        {
            SendMessageUpwards("Katreset", 4f);
        }
        else if (collision.gameObject.CompareTag("Milk"))
        {
            SendMessageUpwards("Katreset", 5f);
        }
        else if (collision.gameObject.CompareTag("Bernard"))
        {
            SendMessageUpwards("Katreset", 6f);
        }
        else if (collision.gameObject.CompareTag("Storemis"))
        {
            SendMessageUpwards("Katreset", 7f);
        }
    }
}
