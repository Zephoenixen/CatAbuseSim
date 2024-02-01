using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathbykat : MonoBehaviour
{
    public Color backgroundcolor;
    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cameraflash());
    }

    // Update is called once per frame
IEnumerator Cameraflash()
    {
        yield return new WaitForSeconds(1);
        Camera.backgroundColor = Color.white;
        yield return new WaitForSeconds(0.2f);
        Camera.backgroundColor = backgroundcolor;
        yield return new WaitForSeconds(0.4f);
        Camera.backgroundColor = Color.white;
        yield return new WaitForSeconds(0.2f);
        Camera.backgroundColor = backgroundcolor;
        yield return new WaitForSeconds(0.4f);
        Camera.backgroundColor = Color.white;
        yield return new WaitForSeconds(0.2f);
        Camera.backgroundColor = backgroundcolor;
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Menu Screen");
    }
}
