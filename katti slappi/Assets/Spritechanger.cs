using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spritechanger : MonoBehaviour
{

    public SpriteRenderer prebonk;
    public SpriteRenderer postbonk;
    public SpriteRenderer nohammer;
    public GameObject Wham;
    public GameObject Hands;
    void FadeDone()
    {
        
        StartCoroutine(Bonking());

    }
    IEnumerator Bonking()
    {
        Wham.transform.position = new Vector3(-0.82f, 4.44f, 0);
        prebonk.sprite=postbonk.sprite;
        yield return new WaitForSeconds(0.5f);
        Wham.transform.position = new Vector3(-0.82f, 4.44f, -60);
        yield return new WaitForSecondsRealtime(1.5f);
        prebonk.sprite=nohammer.sprite;
        yield return new WaitForSeconds(1.5f);
        prebonk.sprite = postbonk.sprite;
        Hands.transform.position += new Vector3(0, -20, 0);
        Debug.Log("hands");
        while (Hands.transform.position.z > -15)
        {
            Hands.transform.position += new Vector3(0f, 0f, Time.deltaTime*0.0002f);
        }
            SendMessage("Movehand");
        yield break;
    }
    void Movehand()
    {
        //change prebonk to angry when get angry
        
        }
    }

