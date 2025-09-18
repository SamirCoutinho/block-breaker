using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Vidas")]
    public Image[] hearts; // arraste os 3 corações no inspector
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("Pontuação")]
    public TMP_Text scoreText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void UpdateLives(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
