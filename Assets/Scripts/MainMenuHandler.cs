using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuHandler : MonoBehaviour
{
    public Text highScore;
    private void Start()
    {
        SetHighScore();
    }
    public void SetHighScore()
    { 
        highScore.text = PlayerPrefs.GetInt("highscore").ToString();
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("game");
    }
}
