using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public float timetofade = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeIn(timetofade));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public SpriteRenderer spriteToFade;

    IEnumerator fadeIn(float duration)
    {
        float counter = 0;
        //Get current color
        Color spriteColor = spriteToFade.color;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(0, 1, counter / duration);
            Debug.Log(alpha);

            //Change alpha only
            spriteToFade.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame
            yield return null;
        }
        BroadcastMessage("FadeDone");
    }
}
