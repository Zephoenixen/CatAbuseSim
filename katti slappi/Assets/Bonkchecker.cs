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

    public int physTagCompare = 0;

    void Checkbonk(bool State)
    {
        if(State == true)
        bonked = false;
    }
    

    void bonk()
    {
        bonked=true;
        rb.velocity = new Vector3(0, (2+Katmanager.Vel.y)*-1.5f, 0);
        SendMessageUpwards("Score", Scoreworth);
        SendMessageUpwards("Sound", "Bonk");
        StartCoroutine(Bonkedsprite());
        if (tag == "Fernando")
            {
            SceneManager.LoadScene("Bonk Scene");
            }

    }
    public void Bonker(float Identifier) 
    { 
        if(!bonked)
            switch (Identifier)
            {
                case 1:
                    if (transform.position.x == Leftmostlane)
                    {
                        bonk();
                    }
                    break;
                case 2:
                    if (transform.position.x == Middleleftlane)
                    {
                        bonk();
                    }
                    break;
                case 3:
                    if (transform.position.x == Middlerightlane)
                    {
                        bonk();
                    }
                    break;
                case 4:
                    if (transform.position.x == Rightmostlane)
                    {
                        bonk();
                    }
                    break;
            }
    }

   void collisionSwitch()
    {
        switch (physTagCompare)
        {
            case 0:
                Debug.Log("Collision tag not detected");
                break;
            case 1:
                rb.velocity = new Vector3(0, (2f + Katmanager.Vel.y) * -1.5f, 0);
                SendMessageUpwards("Score", 50);
                bonked = true;
                physTagCompare = 0;
                break;
            case 2:
                SceneManager.LoadScene("Scratch Scene");
                physTagCompare = 0;
                break;
            case 3:
                rb.velocity = new Vector2(0, 0);
                transform.position = new Vector2(-10, -10);
                bonked = true;
                physTagCompare = 0;
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("triggerBox"))
        {
            physTagCompare = 3;
        }
        else if (CompareTag("Fernando"))
        {
            physTagCompare = 1;
        }
        else if (collision.gameObject.CompareTag("Killbox"))
        {
            physTagCompare = 2;
        }
        collisionSwitch();

    }
    IEnumerator Bonkedsprite()
    {
        GetComponent<SpriteRenderer>().sprite = overridesprite.sprite;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().sprite = originalsprite.sprite;
        yield return null;
    }
}
