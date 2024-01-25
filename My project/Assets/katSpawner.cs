using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatSpawner : MonoBehaviour
{
    public float spawnDelay = 3f;
    private float nextSpw = 1;
    public float katSpwnHeight = -10;

    public bool gameStarted = true;
    public int[] spwPos;
    public GameObject[] Kats;
    public List<GameObject> SpawnsClear;
  
    private void Start()
    {
        
    }

    void Pick()
    {
        int randomKat = Random.Range(0, Kats.Length);
        int randomSpw = Random.Range(0, spwPos.Length);
        GameObject clone = Instantiate(Kats[randomKat], new Vector3(spwPos[randomSpw],katSpwnHeight,0), Quaternion.identity);
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
