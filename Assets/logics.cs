using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logics : MonoBehaviour
{
    public bird isBirdAlive;
    public int playerScore = 0;
    public Text scoreText;
    public int highScore = 0;
    public Text hIGHSCORE;
    public GameObject gameOverScene;

    public void checkHighScore()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
        }
    }

    [ContextMenu("Add Score")]
    public void AddScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        isBirdAlive.birdIsAlive = false; 
        gameOverScene.SetActive(true);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            RestartGame();
        }
    }
}
