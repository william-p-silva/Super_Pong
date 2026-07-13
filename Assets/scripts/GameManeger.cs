using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    public int ScorePlayerBlue = 0;
    public int ScorePlayerRed = 0;
    public int PointsToIncreaseSpeed = 4;
    public float SpeedIncrement = 0.1f;
    public int MaxScore = 2;


    public Ball Ball;
    public Text Score;



    private void Update()
    {
        float screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float screenRitgh = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        if (Ball.transform.position.x + 0.15f < screenLeft)
        {
            AddScore(player: 2);
            Ball.ResetPosition();

        }
        else if (Ball.transform.position.x - 0.15f > screenRitgh)
        {
            AddScore(player: 1);
            Ball.ResetPosition();
        }
        if (ScorePlayerBlue >= MaxScore || ScorePlayerRed >= MaxScore)
        {
            VictoryGame();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void AddScore(int player)
    {
        if (player == 1)
        {
            ScorePlayerBlue++;
        }
        else if (player == 2)
        {
            ScorePlayerRed++;
        }
        if ((ScorePlayerBlue + ScorePlayerRed) % PointsToIncreaseSpeed == 0)
        {
            Ball.Speed += SpeedIncrement;
        }

        Score.text = $"{ScorePlayerBlue} x {ScorePlayerRed}";
    }

    private void VictoryGame()
    {
        if (ScorePlayerBlue > ScorePlayerRed)
        {
            Score.text = $"O jogoador azul ganhou o Jogo com {ScorePlayerBlue}";
        }
        else if (ScorePlayerBlue < ScorePlayerRed)
        {
            Score.text = $"O jogoador vermelho ganhou o Jogo com {ScorePlayerRed}";
        }
        else if (ScorePlayerBlue == ScorePlayerRed)
        {
            Score.text = $"Os jogaroes empataram com ${ScorePlayerBlue} pontos";
        }
        Ball.IsMoving = false;
    }

}
