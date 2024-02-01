using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fernandobonk : MonoBehaviour
{

    public SpriteRenderer prebonk;
    public SpriteRenderer postbonk;
    public SpriteRenderer nohammer;
    public SpriteRenderer amgry;
    public GameObject Wham;
    public GameObject Hands;
    public GameObject Camera;
    void FadeDone()
    {

        StartCoroutine(Bonking());

    }
    IEnumerator Bonking()
    {
        Wham.transform.position = new Vector3(-0.82f, 4.44f, 0);
        BroadcastMessage("Sound", "Bonk", SendMessageOptions.DontRequireReceiver);
        prebonk.sprite = postbonk.sprite;

        yield return new WaitForSeconds(0.5f);
        Wham.transform.position = new Vector3(-0.82f, 4.44f, -60);

        yield return new WaitForSecondsRealtime(1.5f);
        prebonk.sprite = nohammer.sprite;

        yield return new WaitForSeconds(1.5f);
        prebonk.sprite = amgry.sprite;
        BroadcastMessage("Sound", "Growl");

        BroadcastMessage("Handtime",SendMessageOptions.DontRequireReceiver);

        yield return new WaitForSeconds(3f);
        Camera.transform.Rotate(0, 60, 0);
        BroadcastMessage("Sound", "Snap", SendMessageOptions.DontRequireReceiver);

        yield return new WaitForSeconds(0.5f);
        Camera.transform.Rotate(0, 40, 0);

        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("Menu Screen");

        yield break;
    }
}

