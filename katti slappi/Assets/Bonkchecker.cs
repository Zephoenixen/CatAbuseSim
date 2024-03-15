using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bonkchecker : MonoBehaviour
{
    public bool bonked = false;
    public int Scoreworth = 1;
    public int Leftmostlane = -9;
    public int Rightmostlane = 9;
    public int Middleleftlane = -3;
    public int Middlerightlane = 3;
    public int bonkvel = -7;
    public Rigidbody2D rb;
    public SpriteRenderer originalsprite;
    public SpriteRenderer overridesprite;
    public GameObject scoreKeeper;
    public Katmanager Katmanager;

    void Checkbonk(bool State)
    {
        if(State == true)
        bonked = false;
    }
    

    void bonk()
    {
        bonked=true;
        Debug.Log("BONK");
        rb.velocity = new Vector3(0, (2+Katmanager.Vel.y)*-1.5f, 0);
        SendMessageUpwards("Score", Scoreworth, SendMessageOptions.DontRequireReceiver);
        SendMessageUpwards("Sound", "Bonk", SendMessageOptions.DontRequireReceiver);
        if (tag == "Fernando")
            {
            SceneManager.LoadScene("Bonk Scene");
            }
        StartCoroutine(Bonkedsprite());
    }
    public void Bonker(float Identifier) 
    { 

        if(Identifier == 1 && bonked==false) 
        { 
            if (transform.position.x == Leftmostlane && transform.position.y >= -10f)
            {
                bonk();
            }
        }
        else if(Identifier == 2 && bonked == false)
        {
            if(transform.position.x == Middleleftlane && transform.position.y >= -10f)
            {
                bonk();
            }
        }
        else if (Identifier == 3 && bonked == false)
        {
            if(transform.position.x == Middlerightlane && transform.position.y >= -10f)
            {
                bonk();
            }
        }
        else if (Identifier == 4 && bonked == false)
        {

            if(transform.position.x == Rightmostlane && transform.position.y >= -10f)
            {
                bonk();  
            }
        }
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Fernando")) 
        { 
            rb.velocity = new Vector3(0, (2f+Katmanager.Vel.y) * -1.5f,0);
            SendMessageUpwards("Score", 50);
        }
        else
        {
            if (collision.gameObject.CompareTag("Killbox"))
            {
                SceneManager.LoadScene("Scratch Scene");
            }   
        }
        if (collision.gameObject.CompareTag("triggerBox"))
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = new Vector2(-10, -10);
        }
    }
    IEnumerator Bonkedsprite()
    {
        GetComponent<SpriteRenderer>().sprite = overridesprite.sprite;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().sprite = originalsprite.sprite;
        yield return null;
    }
}
