
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
    AudioSource Audio;
    
    
    public int points;
    public ScoreKeeper ScoreKeeper;
    
    //Brugt til at ændre spillets hastighed baseret på hvor langt tid man har spillet
    private float timeVar;
    private float velTime;
    private float cooldownSpeeder;
    public float speedScale = 0.15f;
    public float cooldownScale = 0.05f;


    //CoolDown Manager sådan at vi dynamisk kan spawne katte
    public float cooldown = 3f;
    private float nextKat = 1f;

    // Bliver brugt til at tjekke om der nok positioner
    public float truePasses = 0;

    // Bevæger Katte op og ned
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

    private void Start()
    {
        cooldown = 3f;
        Audio = GetComponent<AudioSource>();
    }
    // Katmover står for at bevæge kattene ind i de rigtige felter når cooldown er slut
    void KatMover()
    {
        //Position randomizer gør at den prøver at vælge tilfældige felter
        int RandoPos = Random.Range(0, Pos.Length);
        //Tjekker om feltet er åbent
        if (!PosAvaliable[RandoPos] == true)
        {
            //gør at den prøver at finde en kat i tick'et efter
            nextKat = Time.timeSinceLevelLoad;
        }
        else
        {
            //Kat randomizer er Position randomizer men for kattene
            int RandoKat = Random.Range(0, KatAvaliable.Length);
            //Tjekker om katten er i brug
            if (!KatAvaliable[RandoKat] == true)
            {
                return;
            }
            else
            {
                //Både Kat og Pos avaliable bliver slået fra sådan både felt og kat er i brug
                PosAvaliable[RandoPos] = false;
                KatAvaliable[RandoKat] = false;
                //Gør at der går (cooldown) mængde tid til den næste kat spawner
                nextKat = Time.timeSinceLevelLoad + cooldown;
                //Debuglog for at tjekke det virker
                //Debug.Log("bevaegelse");
                //De her 4 felter står for at rykke dem og give dem velocitet sådan de går op
                switch (RandoKat)
                {
                    case 0:
                        Fernando.transform.position = new Vector2(Pos[RandoPos], -9);
                        Ferb.velocity = Vel;
                        Fernando.SendMessage("Checkbonk", true);
                        break;
                    case 1:
                        Ost.transform.position = new Vector2(Pos[RandoPos], -9);
                        Osrb.velocity = Vel;
                        Ost.SendMessage("Checkbonk", true);
                        break;
                    case 2:
                        Patooty.transform.position = new Vector2(Pos[RandoPos], -9);
                        Parb.velocity = Vel;
                        Patooty.SendMessage("Checkbonk", true);
                        break;
                    case 3:
                        Kattemad.transform.position = new Vector2(Pos[RandoPos], -9);
                        Karb.velocity = Vel;
                        Kattemad.SendMessage("Checkbonk", true);
                        break;
                    case 4:
                        Milk.transform.position = new Vector2(Pos[RandoPos], -9);
                        Mirb.velocity = Vel;
                        Milk.SendMessage("Checkbonk", true);
                        break;
                    case 5:
                        Bernard.transform.position = new Vector2(Pos[RandoPos], -9);
                        Berb.velocity = Vel;
                        Bernard.SendMessage("Checkbonk", true);
                        break;
                    case 6:
                        Storemis.transform.position = new Vector2(Pos[RandoPos], -9);
                        Strb.velocity = Vel;
                        Storemis.SendMessage("Checkbonk", true);
                        break;
                }
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


    public void Spawner()
    {
        if (Time.timeSinceLevelLoad > nextKat)
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

    //Den her sætter det positions bool array vædier til false når positionerne bliver tomme sådan at der kan komme nye katte, får sin info fra Checkbox
    public void Posreset(int posreset)
    {
        switch (posreset)
        {
            case 1:
                PosAvaliable[0] = true;
                break;
            case 2:
                PosAvaliable[1] = true;
                break;
            case 3:
                PosAvaliable[2] = true;
                break;
            case 4:
                PosAvaliable[3] = true;
                break;
        }
    }
    //Den her sætter det katte bool array vædier til false når katte kommer ud af skærmen sådan at de kan spawne andre steder
    public void Katreset(float katreset)
    {
        switch (katreset)
        {
            case 1:
                KatAvaliable[0] = true;
                break;
            case 2:
                KatAvaliable[1] = true;
                break;
            case 3:
                KatAvaliable[2] = true;
                break;
            case 4:
                KatAvaliable[3] = true;
                break;
            case 5:
                KatAvaliable[4] = true;
                break;
            case 6:
                KatAvaliable[5] = true;
                break;
            case 7:
                KatAvaliable[6] = true;
                break;
        }

    }

    public void Progression()
    {
        timeVar = Time.timeSinceLevelLoad * speedScale;
        cooldownSpeeder = Time.timeSinceLevelLoad * cooldownScale;
        Vel = new Vector3(0, 2 + velTime, 0);
        
        if (timeVar < 9) 
        {
            velTime = timeVar;
        }
        if (cooldown > 0.45f)
        {
            cooldown = cooldown-(cooldownSpeeder * (0.00001f));
        }
    }

    public void Sound(string Soundtype)
    {
        if(Soundtype == "Bonk")
        {
            Audio.Play();
        }
    }
    public void Score(int Points)
    {
        points += Points;

        PlayerPrefs.SetInt("PlayerScore", points);

        if (points > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", points);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Den her tjekker om man trykker på rigtige knap og om der er en kat der før den slår katten i feltet
        PlayerInteraction();
        //Den her spawner en spawner en kat efter en bestemt mængde tid
        Spawner();
        //Gør spillet hurtigere og sværere over tid, samt laver scores og highscores
        Progression();

    }
    
}
