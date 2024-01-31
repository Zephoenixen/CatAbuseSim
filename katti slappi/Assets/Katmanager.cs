
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Katmanager : MonoBehaviour
{
    //Liste af ting der skal bruges
    public GameObject Ost;
    public GameObject Patooty;
    public GameObject Fernando;
    public GameObject Kattemad;
    public GameObject Milk;
    public GameObject Bernard;
    public GameObject Storemis;

    //CoolDown Manager
    public float cooldown = 3f;
    private float nextKat = 1f;

    //
    public float truePasses = 0;

    //
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
    public Rigidbody2D Karb;
    public Rigidbody2D Mirb;
    public Rigidbody2D Berb;
    public Rigidbody2D Strb;
    //Cooldown sådan at vi ikke har 5 tusinde katte på en gang

    // Start is called before the first frame update
    void Start()
    {





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
                nextKat = Time.time + cooldown;
                //Debuglog for at tjekke det virker
                Debug.Log("bev�gelse");
                //De her 4 felter står for at rykke dem og give dem velocitet sådan de går op
                if (RandoKat == 0)
                {
                    Fernando.transform.position = new Vector2(Pos[RandoPos], -9);
                    Ferb.velocity = Vel;

                }
                else if (RandoKat == 1)
                {
                    Ost.transform.position = new Vector2(Pos[RandoPos], -9);
                    Osrb.velocity = Vel;

                }
                else if (RandoKat == 2)
                {
                    Patooty.transform.position = new Vector2(Pos[RandoPos], -9);
                    Parb.velocity = Vel;

                }
                else if (RandoKat == 3)
                {
                    Kattemad.transform.position = new Vector2(Pos[RandoPos], -9);
                    Karb.velocity = Vel;

                }
                else if (RandoKat == 4)
                {
                    Milk.transform.position = new Vector2(Pos[RandoPos], -9);
                    Mirb.velocity = Vel;

                }
                else if (RandoKat == 5)
                {
                    Bernard.transform.position = new Vector2(Pos[RandoPos], -9);
                    Berb.velocity = Vel;

                }
                else if (RandoKat == 6)
                {
                    Storemis.transform.position = new Vector2(Pos[RandoPos], -9);
                    Strb.velocity = Vel;

                }
                //Den her advarer om at katmover er i stykker fordi den burde aldrig vælge en randokat større end 3
                else { Debug.Log("KatMover Broke"); }
            }
            else
            {
                nextKat = Time.time;
            }
        }
    }

    void PlayerInteraction()
    {
        //Input Manager
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            BroadcastMessage("Bonker", 1f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            BroadcastMessage("Bonker", 2f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            BroadcastMessage("Bonker", 3f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            BroadcastMessage("Bonker", 4f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Den her tjekker om man trykker på rigtige knap og om der er en kat der før den slår katten i feltet
        PlayerInteraction();

    if (Time.time > nextKat) 
        {

            foreach (bool i in PosAvaliable)
            {
                if (i == true)
                {
                    truePasses++;
                }
            }
            if (truePasses >= 1)
            {
                KatMover();
                truePasses = 0;
            }

        }
    }
    public void Posreset(float posreset)
    {
        if(posreset == -9f)
        {
            PosAvaliable[0] = true;
        }
        else if (posreset == -3f)
        {
            PosAvaliable[1] = true;
        }
        else if (posreset == 3f)
        {
            PosAvaliable[2] = true;
        }
        else if (posreset == 9f)
        {
            PosAvaliable[3] = true;
        }
    }
    public void Katreset(float katreset)
    {
        if(katreset == 1)
        {
            KatAvaliable[0] = true;
            Debug.Log("FERNRESET");
        }
        else if (katreset == 2)
        {
            KatAvaliable[1] = true;
        }
        else if (katreset == 3)
        {
            KatAvaliable[2] = true;
        }
        else if (katreset == 4)
        {
            KatAvaliable[3] = true;
        }
        else if (katreset == 5)
        {
            KatAvaliable[4] = true;
        }
        else if (katreset == 6)
        {
            KatAvaliable[5] = true;
        }
        else if (katreset == 7)
        {
            KatAvaliable[6] = true;
        }
    }
}
