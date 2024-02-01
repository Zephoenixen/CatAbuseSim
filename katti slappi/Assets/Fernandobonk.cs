using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fernandobonk : MonoBehaviour
{
    // Sprites der bliver skiftet imellem
    public SpriteRenderer prebonk;
    public SpriteRenderer postbonk;
    public SpriteRenderer nohammer;
    public SpriteRenderer amgry;
    public SpriteRenderer Gameover;

    //Objecter der bliver rykket rundt p�
    public GameObject Wham;
    public GameObject Hands;
    public GameObject Camera;

    //Lyd effekter
    public AudioSource growlsfx;
    public AudioSource bonksfx;
    public AudioSource snapsfx;

    //Baggrundsfarve efter gameover kommer
    public Color gameovercolor;

    //FadeDone modtager et signal fra et andet script og starter s� Bonking Inumeratoren
    void FadeDone()
    {

        StartCoroutine(Bonking());

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SceneManager.LoadScene("Menu Screen");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SceneManager.LoadScene("Menu Screen");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SceneManager.LoadScene("Menu Screen");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SceneManager.LoadScene("Menu Screen");
        }
    }
    IEnumerator Bonking()
    {
        //Dette trin for Wham visual effekten til at v�re p� sk�rmen, �ndrer spriten til at v�re i bonket tilstand, og afspiller Bonk Sfx
        Wham.transform.position = new Vector3(-0.82f, 4.44f, 0);
        BroadcastMessage("Sound", "Bonk", SendMessageOptions.DontRequireReceiver);
        prebonk.sprite = postbonk.sprite;

        //Dette trin venter og dern�st fjerner Wham visual effekten
        yield return new WaitForSeconds(0.5f);
        Wham.transform.position = new Vector3(-0.82f, 4.44f, -60);

        //Dette trin venter lidt l�ngere for at �ndre spriten for at fjerne hammeren, og starter Growl Sfx s�dan den spiller i tide til at det giver mening
        yield return new WaitForSecondsRealtime(1.5f);
        prebonk.sprite = nohammer.sprite;
        BroadcastMessage("Sound", "Growl");

        //Dette trin venter liges� langt som det sidste for at �ndre sprite til vred tilstand, og sende signal til h�nderne at de skal bev�ge sig
        yield return new WaitForSeconds(1.5f);
        prebonk.sprite = amgry.sprite;
        
        BroadcastMessage("Handtime",SendMessageOptions.DontRequireReceiver);

        //Dette trin v�nter indtil h�nderne stopper og rotere cameraet s�dan det ligner din nak bliver br�kket og spiller Snap sfx
        yield return new WaitForSeconds(3f);
        Camera.transform.Rotate(0, 60, 0);
        BroadcastMessage("Sound", "Snap", SendMessageOptions.DontRequireReceiver);

        //Dette trin rykker cameraet lidt l�ngere for at g�re man ikke kan se nogle sprites og �ndrer baggrunds farven til at matche resten af spillet og viser dern�st en game over sk�rm
        yield return new WaitForSeconds(0.5f);
        Camera.transform.Rotate(0, 40, 0);
        Camera.GetComponent<Camera>().backgroundColor = gameovercolor;
        Gameover.color = new Color(1,1,1,1);



        yield break;
    }
    void Sound(string Soundtype)
    {
        if (Soundtype == "Growl")
        {
            growlsfx.Play();
        }
        else if (Soundtype == "Bonk")
        {
            bonksfx.Play();
        }
        else if (Soundtype == "Snap")
        {
            snapsfx.Play();
        }
        else
        {
            Debug.Log("Sound broke");
        }
    }
}

