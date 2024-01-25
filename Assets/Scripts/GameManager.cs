using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;

    public Text scoreText;

    public GameObject playButton;

    public GameObject gameOver;

    private int score;

    private void Awake()
    {

        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOver.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1f;

        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            // dont forget game object to delete the Game object
            Destroy(pipes[i].gameObject);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;

        player.enabled = false;
    }

    public void GameOver()
    {
        Debug.Log("GAMEOVER");

        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }


    public void IncreaseScore()
    {
        score++;

        Debug.Log(score);

        scoreText.text = score.ToString();
    }
}
