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
    // Start is called before the first frame update
    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }
    public void Bonker(float Identifier) 
    { 

    if(Identifier == 1) 
        { 
            if (transform.position.x == Leftmostlane)
            {
                Debug.Log("BONK");
                rb.velocity = new Vector3(0,bonkvel,0);
                if (tag == "Ferrrrrrnando")
                {
                    SceneManager.LoadScene("Main Menu");
                }
            }
        }
    else if(Identifier == 2)
        {
            if(transform.position.x == Middleleftlane)
            {
                Debug.Log("BONK");
                rb.velocity = new Vector3(0, bonkvel, 0);
                if (tag == "Ferrrrrrnando")
                {
                    SceneManager.LoadScene("Main Menu");
                }
            }
        }
    else if (Identifier == 3)
        {
            if(transform.position.x == Middlerightlane)
            {
                Debug.Log("BONK");
                rb.velocity = new Vector3(0, bonkvel, 0);
                if (tag == "Ferrrrrrnando")
                {
                    SceneManager.LoadScene("Main Menu");
                }
            }
        }
    else if (Identifier == 4)
        {

            if(transform.position.x == Rightmostlane)
            {
                Debug.Log("BONK");
                rb.velocity = new Vector3(0, bonkvel, 0);
                if (tag == "Ferrrrrrnando")
                {
                    SceneManager.LoadScene("Main Menu");
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Kats")) 
        { 
            SceneManager.LoadScene("Main Menu"); 
        }

        else if (CompareTag("Ferrrrrrnando")) 
        { 
            rb.velocity = new Vector3(0, bonkvel, 0); 
        }
    }
}
