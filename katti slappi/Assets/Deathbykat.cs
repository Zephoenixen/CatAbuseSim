using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathbykat : MonoBehaviour
{

    public Color backgroundcolor;
    public Camera Camera;
    public SpriteRenderer Scratch1, Scratch2, Gameover, Press;
    public AudioSource Scratch;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cameraflash());
    }
    void Sound(string sound)
    {
        Scratch.Play();
    }



    // Update is called once per frame
    IEnumerator Cameraflash()
    {
        yield return new WaitForSeconds(1);
        Camera.backgroundColor = Color.white;
        Scratch1.color = Color.white;
        SendMessage("Sound", "Scratch");

        yield return new WaitForSeconds(0.2f);
        Camera.backgroundColor = backgroundcolor;
        Scratch1.color = new Color(0, 0, 0, 0);

        yield return new WaitForSeconds(0.4f);
        Camera.backgroundColor = Color.white;
        Scratch2.color = Color.white;
        SendMessage("Sound", "Scratch");

        yield return new WaitForSeconds(0.2f);
        Camera.backgroundColor = backgroundcolor;
        Scratch2.color = new Color(0, 0,0,0);

        yield return new WaitForSeconds(0.4f);
        Camera.backgroundColor = Color.white;
        Scratch1.color = Color.white;
        SendMessage("Sound", "Scratch");

        yield return new WaitForSeconds(0.2f);
        Camera.backgroundColor = backgroundcolor;
        Scratch1.color = new Color(0,0,0,0);

        yield return new WaitForSeconds(0.1f);
        Gameover.color = Color.white;
        Press.color = new Color(0, 0, 0, 0);

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu Screen");

    }
}
