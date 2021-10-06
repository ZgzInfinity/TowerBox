using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text textScore;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void setScore()
    {
        addScore();
        updateScore();
    }

    private void addScore()
    {
        score++;
    }

    private void updateScore()
    {
        textScore.text = score.ToString();
    }
}
