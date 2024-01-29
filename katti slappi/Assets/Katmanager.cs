
using System.Linq;
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
    public Vector3 Vel = new Vector3(0, 2, 0);
    public Vector3 Bonk = new Vector3(0, -7, 0);
    // Arrays hvori vi har positionerne kattene kan blive sat i og om de er i brug eller ej, og hvor vi har kattene og om de er i brug
    public bool[] PosAvaliable;
    public int[] Pos;
    public bool[] KatAvaliable;
    // Rigidbodysne fra kattene sådan vi kan få dem til at gå op
    public Rigidbody2D Ferb;
    public Rigidbody2D Osrb;
    public Rigidbody2D Parb;
    public Rigidbody2D Plrb;
    //Cooldown sådan at vi ikke har 5 tusinde katte på en gang
    bool cooldown;
    // Start is called before the first frame update
    void Start()
    {

        //Flytter kattene langt væk fra skærmen
        Patooty.transform.position = Katstpos;
        Ost.transform.position = Katstpos;
        Fernando.transform.position = Katstpos;
        Placeholder1.transform.position = Katstpos;

        
    }
    // Katmover står for at bevæge kattene ind i de rigtige felter når cooldown er slut
    void KatMover()
    {
        //Position randomizer gør at den prøver at vælge tilfældige felter
        int RandoPos = Random.Range(0, Pos.Length);
        //Tjekker om feltet er åbent
        if ((PosAvaliable[RandoPos] == true))
        {
            //Kat randomizer er Position randomizer men for kattene
            int RandoKat = Random.Range(0, KatAvaliable.Length);
            //Tjekker om katten er i brug
            if ((KatAvaliable[RandoKat] == true))
            {
                //Både Kat og Pos avaliable bliver slået fra sådan både felt og kat er i brug
                PosAvaliable[RandoPos] = false;
                KatAvaliable[RandoKat] = false;
                //Debuglog for at tjekke det virker
                Debug.Log("bev�gelse");
                //De her 4 felter står for at rykke dem og give dem velocitet sådan de går op
                if (RandoKat == 0)
                {
                    Fernando.transform.position = new Vector2(Pos[RandoPos], -9);
                    Ferb.velocity = Vel; 
                    cooldown = true;
                }
                else if (RandoKat == 1)
                {
                    Ost.transform.position = new Vector2(Pos[RandoPos], -9);
                    Osrb.velocity = Vel; 
                    cooldown = true;
                }
                else if (RandoKat == 2)
                {
                    Patooty.transform.position = new Vector2(Pos[RandoPos], -9);
                    Parb.velocity = Vel;
                    cooldown = true;
                }
                else if (RandoKat == 3)
                {
                    Placeholder1.transform.position = new Vector2(Pos[RandoPos], -9);
                    Plrb.velocity = Vel; 
                    cooldown = true;
                }
                //Den her advarer om at katmover er i stykker fordi den burde aldrig vælge en randokat større end 3
                else { Debug.Log("KatMover Broke"); }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown = false) { KatMover(); }
        //De her tjekker om man trykker på rigtige knap og om der er en kat der før den slår katten i feltet
        if ((Input.GetKeyDown(KeyCode.DownArrow)) && (PosAvaliable[2] = false))
        {
            ;
        }
        if (!PosAvaliable.All(x => x)) {; }

        //if (dead.All(dead[] == true))


    }
}
