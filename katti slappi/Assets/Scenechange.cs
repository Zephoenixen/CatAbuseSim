using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.RightArrow)) { SceneManager.LoadScene("Game Scene(Post Bonk)"); }
      if (Input.GetKeyDown(KeyCode.UpArrow)) { SceneManager.LoadScene("Game Scene(Post Bonk)"); }
      if (Input.GetKeyDown(KeyCode.DownArrow)) { SceneManager.LoadScene("Game Scene(Post Bonk)"); }
      if (Input.GetKeyDown(KeyCode.LeftArrow)) { SceneManager.LoadScene("Game Scene(Post Bonk)"); }
    }
}
