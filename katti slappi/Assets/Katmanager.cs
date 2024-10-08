
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Katmanager : MonoBehaviour
{
    //Liste af ting der skal bruges
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
    // Kattene i et array
    public GameObject[] Kats;
    // Rigidbodysne fra kattene sådan vi kan få dem til at gå op
    public Rigidbody2D[] KatRb2D;

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
                //De her 3 felter står for at rykke dem og give dem velocitet sådan de går op
                Kats[RandoKat].transform.position = new Vector2(Pos[RandoPos], -9);
                KatRb2D[RandoKat].velocity = Vel;
                Kats[RandoKat].SendMessage("Checkbonk", true);
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
        PosAvaliable[posreset-1] = true;
    }
    //Den her sætter det katte bool array vædier til false når katte kommer ud af skærmen sådan at de kan spawne andre steder
    public void Katreset(int katreset)
    {
        KatAvaliable[katreset-1] = true;
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
