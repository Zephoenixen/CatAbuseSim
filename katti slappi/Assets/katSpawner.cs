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
    public List<int> SpawnsClear;
    public List <int> KatsClear;
  
    private void Start()
    {
        SpawnsClear.Clear();
        KatsClear.Clear();
        for (int i = 0; i < spwPos.Length; i++) 
        {
            print("Spawn Count " + i);
            SpawnsClear.Add(i);

        }
        for (int i = 0; i < Kats.Length; i++)
        {
            print("Kat Count " + i);
            KatsClear.Add(i);
        }
    }

    void Pick()
    {
        int randomKat = Random.Range(0, KatsClear.Count);
        int randomSpw = Random.Range(0, SpawnsClear.Count);
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
