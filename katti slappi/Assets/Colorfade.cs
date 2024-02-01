using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorfade : MonoBehaviour
{
    public SpriteRenderer Fernandounbonk;
    public Color startcolor, endcolor;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tick = 0f;
        while (Fernandounbonk.color != endcolor)
        {
            tick += Time.deltaTime * speed;
            Fernandounbonk.color = Color.Lerp(startcolor, endcolor, tick);
        }
    }
}
