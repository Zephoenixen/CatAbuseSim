using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text highScore;

    public Text playerScore;
    
    private void Awake()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        playerScore.text = PlayerPrefs.GetInt("PlayerScore", 0).ToString();
    }
}
