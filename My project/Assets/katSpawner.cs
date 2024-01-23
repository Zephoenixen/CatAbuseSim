using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatSpawner : MonoBehaviour
{
    public float spawnDelay = 3f;
    public GameObject[] Kattis;
    public int[] spwPos;
    // Start is called before the first frame update
    void Start()
    {
        Pick();
    }

   void Pick() 
    { 
        int randomIndex = Random.Range(0, Kattis.Length);
        int randomIndex2 = Random.Range(0, spwPos.Length);
        GameObject clone = Instantiate(Kattis[randomIndex],transform.position, Quaternion.identity);
    }
    
    
    
    // Update is called once per frame
    void Update()
    {
     
    }

}
