using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI ScoreText;
    public GameObject gameOverScreen;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager= GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();   
    }

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore += 1;
        ScoreText.text = playerScore.ToString();
        Debug.Log(ScoreText.text);

    }

    public void restartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void gameOver()
    {
        audioManager.Stop();
        gameOverScreen.SetActive(true);
    }

    public void Exitgame() 
    {

        Application.Quit();
    }


}
