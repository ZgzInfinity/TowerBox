using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public BoxSpawner boxSpawner;
    public bool isGameActive;

    public TMP_Text textScore;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
        isGameActive = true;
    }

    public int Score
    {
        get { return score; } 
    }

    public void setScore()
    {
        addScore();
        updateScore();
        checkGameState();
    }

    private void checkGameState()
    {
        if (isGameActive)
        {
            StartCoroutine(SpawnBoxCoRoutine());
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        CameraManager.Instance.ResetCameraPosition();
        StartCoroutine(ResetSceneCoRoutine());
    }

    private void addScore()
    {
        score++;
    }

    private void updateScore()
    {
        textScore.text = score.ToString();
    }

    private IEnumerator ResetSceneCoRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator SpawnBoxCoRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        boxSpawner.spawnBox();
    }

    private void CheckHighScore()
    {
        if (score > PlayerPrefs.GetInt("TopScore"))
        {
            PlayerPrefs.SetInt("TopScore", score);
        }
    }
}
