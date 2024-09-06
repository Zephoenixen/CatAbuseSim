using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour 
{ 
    public float scrollSpeed;

    private new Renderer renderer;


    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.timeSinceLevelLoad * scrollSpeed, 1);
        Debug.Log(Time.timeSinceLevelLoad);
        Vector2 offset = new Vector2(x, 0);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
