using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int scoreLeft = 0;
    public int scoreRight = 0;

    public int pointsToIncreaseSpeed = 3;
    public float speedIncreaseAmount = 0.5f;

    public int winningScore = 15;

    public Ball ball;

    public Text scoreText;

    private void Update()
    {
        float screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        if (ball.transform.position.x + 0.25f < screenLeft)
        {
            AddScore("Right");
            ball.ResetPosition();
        }
        else if (ball.transform.position.x - 0.25f > screenRight)
        {
            AddScore("Left");
            ball.ResetPosition();
        }

        RestartScene();
    }

    public void AddScore(string player)
    {
        if (player == "Left")
        {
            scoreLeft++;
        }
        else if (player == "Right")
        {
            scoreRight++;
        }
        
        if ((scoreLeft + scoreRight) % pointsToIncreaseSpeed == 0)
        {
            ball.IncreaseSpeed(speedIncreaseAmount);
        }

        UpdateScoreText();
    }

    private void RestartScene()
    {
        if (scoreLeft >= winningScore)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else if (scoreRight >= winningScore)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"{scoreLeft} X {scoreRight}";
    }

    
}
