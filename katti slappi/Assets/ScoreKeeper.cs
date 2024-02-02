using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    int scoretoShow;
    public void HighScoreKeeper(int highScore)
    {
        
        DontDestroyOnLoad(gameObject);
        
        if (highScore > scoretoShow) 
        {
            scoretoShow = highScore;
        }
    }

    private void Update()
    {
        print(scoretoShow);
    }
}
