using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katmanager : MonoBehaviour
{
    //Liste af ting der skal bruges
    public GameObject Ost;
    public GameObject Patooty;
    public GameObject Fernando;
    public GameObject Placeholder1;

    public Vector2 Katstpos = new Vector2(-20, -20);
    public Vector3 Vel = new Vector3(0,2,0);
    public Vector3 Bonk = new Vector3(0, -7, 0);
    public bool[] PosAvaliable;
    public int[] Pos;
    public bool[] KatAvaliable;
    public Rigidbody2D Ferb;
    public Rigidbody2D Osrb;
    public Rigidbody2D Parb;
    public Rigidbody2D Plrb;
    // Start is called before the first frame update
    void Start()
    {

        //Flytter kattene langt væk fra skærmen
        Patooty.transform.position = Katstpos;
        Ost.transform.position = Katstpos;
        Fernando.transform.position = Katstpos;
        Placeholder1.transform.position = Katstpos;

        KatMover();
    }

    void KatMover() 
    {
        int RandoPos = Random.Range(0, Pos.Length);
       
        if ((PosAvaliable[RandoPos] == true))
        {
            int RandoKat = Random.Range(0, KatAvaliable.Length);
            
            if ((KatAvaliable[RandoKat] == true))
            {
                PosAvaliable[RandoPos] = false;
                KatAvaliable[RandoKat] = false;
                Debug.Log("bevægelse");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow)) && (PosAvaliable[2] = false))
        { 
            
        }
        //if (dead.All(dead[] == true))


    }
}
