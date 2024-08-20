using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkbox : MonoBehaviour
{
    void laneReset()
    {
        switch (transform.position.x)
        {
            case -9:
                SendMessageUpwards("Posreset", 1);
                break;
            case -3:
                SendMessageUpwards("Posreset", 2);
                break;
            case 3:
                SendMessageUpwards("Posreset", 3);
                break;
            case 9:
                SendMessageUpwards("Posreset", 4);
                break;
        }
    }
    void katReset(Collider2D collision)
    {
        switch(collision.gameObject.name)
        {
            case "Fernando":
                SendMessageUpwards("Katreset", 1);
                break;
            case "Ost":
                SendMessageUpwards("Katreset", 2);
                break;
            case "Kattemad":
                SendMessageUpwards("Katreset", 3);
                break;
            case "Patooty":
                SendMessageUpwards("Katreset", 4);
                break;
            case "Milk":
                SendMessageUpwards("Katreset", 5);
                break;
            case "Bernard":
                SendMessageUpwards("Katreset", 6);
                break;
            case "Storemis":
                SendMessageUpwards("Katreset", 7);
                break;
        }

    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        laneReset();
        katReset(collision);
    }
}
