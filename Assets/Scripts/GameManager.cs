using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Blocks[] blocks { get; private set; }
    public int level = 1;
    public int score;
    public int lives = 3;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        NewGame();
        UIManager.Instance.UpdateLives(lives);
        UIManager.Instance.UpdateScore(score);
    }

    private void NewGame()
    {
        score = 0;
        lives = 3;

        UIManager.Instance.UpdateLives(lives);
        UIManager.Instance.UpdateScore(score);

        LoadLevel(1);
    }

    private void LoadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level" + level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = Object.FindFirstObjectByType<Ball>();
        this.paddle = Object.FindFirstObjectByType<Paddle>();
        this.blocks = Object.FindObjectsByType<Blocks>(FindObjectsSortMode.None);

    }

    private void ResetLevel()
    {

        this.ball.ResetBall();
        this.paddle.ResetPaddle();
    }

    private void GameOver()
    {
        NewGame();
    }

    public void Miss()
    {
        this.lives--;

        UIManager.Instance.UpdateLives(lives);


        if (this.lives > 0)
        {
            ResetLevel(); // Só reseta bola e paddle ao perder uma vida
        }
        else
        {
            GameOver(); // Reinicia tudo só quando as vidas acabam
        }
    }

    public void Hit(Blocks blocks)
    {
        score += blocks.points;

        UIManager.Instance.UpdateScore(score);

        if (Cleared())
        {
            LoadLevel(this.level + 1);
        }
    }

    private bool Cleared()
    {
        for (int i = 0; i < this.blocks.Length; i++)
        {
            if (this.blocks[i].gameObject.activeInHierarchy && !this.blocks[i].unbreakable)
            {
                return false;
            }
        }

        return true;
    }
}

