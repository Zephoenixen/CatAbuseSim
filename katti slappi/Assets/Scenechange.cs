using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.RightArrow)) { SceneManager.LoadScene("Game Scene(Post Bonk)");  }
      if (Input.GetKeyDown(KeyCode.UpArrow)) { SceneManager.LoadScene("Game Scene(Post Bonk)"); }
      if (Input.GetKeyDown(KeyCode.DownArrow)) { SceneManager.LoadScene("Game Scene(Post Bonk)"); }
      if (Input.GetKeyDown(KeyCode.LeftArrow)) { SceneManager.LoadScene("Game Scene(Post Bonk)"); }
    }
}
