using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KatSpawner : MonoBehaviour
{
    public float spawnDelay = 3f;
    private float nextSpw = 1;
    public float katSpwnHeight = -10;
    public float speedOfKat = 1f;

    public bool gameStarted = true;
    public int[] SpwPos;
    public bool[] SpwPosTaken;
    public GameObject[] Kats;
    public bool[] KatsTaken;
    

    void Pick()
    {
        int randomKat = Random.Range(0, Kats.Length);
        int randomSpw = Random.Range(0, SpwPos.Length);
        
        GameObject clone = Instantiate(Kats[randomKat], new Vector3(SpwPos[randomSpw],katSpwnHeight,0), Quaternion.identity);
        Rigidbody2D katclone = clone.GetComponent<Rigidbody2D>();

        katclone.velocity = new Vector2(0, speedOfKat);

        
        
        

    }


    void Update()
    {
        if (Time.time > nextSpw)
        { 
            if (gameStarted == true)
            {
                Pick();
                nextSpw = Time.time + spawnDelay;
            }
        }
        

    }
   

}
