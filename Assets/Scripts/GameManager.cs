
/*
 * ------------------------------------------
 * -- Project: Tower Box --------------------
 * -- Author: Rubén Rodríguez Estebban ------
 * -- Date: 8/10/2021 -----------------------
 * ------------------------------------------
 */

using UnityEngine;
using TMPro;
using System.Collections;

/**
 * Script that controls the behaviour of the game
 */

public class GameManager : MonoBehaviour
{
    // Static instance
    public static GameManager Instance;

    // References to the gameplay and gameover UI panels
    public GameObject panelGameplay;
    public GameObject panelGameOver;

    // Reference to the box spawner
    public BoxSpawner boxSpawner;

    // Controls if the game is active or not 
    public bool isGameActive;

    // Reference to the score text
    public TMP_Text textScore;

    // Reference to game over and best score texts
    public TMP_Text textScoreGameOver;
    public TMP_Text textTopScore;

    // Score
    private int score = 0;

    // Reference to the game over sound
    public Sound gameOverSound;

    // Constructor
    private void Awake()
    {
        Instance = this;
        isGameActive = true;
    }

    // Get the score of the round
    public int Score
    {
        get { return score; } 
    }

    // Update the score
    public void SetScore()
    {
        // Check if the game is active
        if (isGameActive)
        {
            // Add a new point
            AddScore();
            // Set the score in the UI
            UpdateScore();
            // Check the game status
            CheckGameState();
        }
    }

    // Check the game status
    private void CheckGameState()
    {
        // Throws a new box
        StartCoroutine(SpawnBoxCoRoutine());
    }

    // Game over 
    public void GameOver()
    {
        // Check the game is active
        if (isGameActive)
        {
            // There is game over
            isGameActive = false;

            // Play game over sound
            AudioManager.Instance.PlaySound(gameOverSound);

            // Reset the camera position to the beginning
            CameraManager.Instance.ResetCameraPosition();

            // Check the score and updates it if the new score is higher
            CheckHighScore();

            // Show the game over panel
            StartCoroutine(ShowGameOverPanelCoRoutine());
        }
    }

    // Add score
    private void AddScore()
    {
        score++;
    }

    // Set the score in the UI
    private void UpdateScore()
    {
        textScore.text = score.ToString();
    }

    // Spawn a new ox
    private IEnumerator SpawnBoxCoRoutine()
    {
        // Wait one second a spawn a box
        yield return new WaitForSeconds(1.0f);
        boxSpawner.spawnBox();
    }

    // Check if the high score has been overcomed
    private void CheckHighScore()
    {
        // Check if the new score is the highest score
        if (score > PlayerPrefs.GetInt("TopScore"))
        {
            // Store the score as highest score
            PlayerPrefs.SetInt("TopScore", score);
        }
    }

    // Draw the game over panel
    private IEnumerator ShowGameOverPanelCoRoutine()
    {
        // Wait one and a half second
        yield return new WaitForSeconds(1.5f);

        // Set the final score reached 
        textScoreGameOver.text = score.ToString();

        // Get the highest score
        textTopScore.text = PlayerPrefs.GetInt("TopScore").ToString();

        // Deactive the gameplay UI panel
        panelGameplay.SetActive(false);

        // Active the gameplay UI panel
        panelGameOver.SetActive(true);
    }
}
