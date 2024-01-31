using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bonkchecker : MonoBehaviour
{
    public int Leftmostlane = -9;
    public int Rightmostlane = 9;
    public int Middleleftlane = -3;
    public int Middlerightlane = 3;
    public int bonkvel = -7;
    public Rigidbody2D rb;
    

       void bonk()
    {
        Debug.Log("BONK");
        rb.velocity = new Vector3(0, bonkvel, 0);
        if (tag == "Ferrrrrrnando")
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
    public void Bonker(float Identifier) 
    { 

    if(Identifier == 1) 
        { 
            if (transform.position.x == Leftmostlane)
            {
                bonk();
            }
        }
    else if(Identifier == 2)
        {
            if(transform.position.x == Middleleftlane)
            {
                bonk();
            }
        }
    else if (Identifier == 3)
        {
            if(transform.position.x == Middlerightlane)
            {
                bonk();
            }
        }
    else if (Identifier == 4)
        {

            if(transform.position.x == Rightmostlane)
            {
                bonk();  
            }
        }
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Fernando")) 
        { 
            rb.velocity = new Vector3(0, bonkvel, 0); 
        }
        else
        {
            if (collision.gameObject.CompareTag("Killbox"))
                {
                SceneManager.LoadScene("Main Menu");
            }   
        }
        if (collision.gameObject.CompareTag("triggerBox"))
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = new Vector2(-10, -10);
        }
    }
}
